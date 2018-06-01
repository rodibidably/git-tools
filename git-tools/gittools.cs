using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace git_tools
{
    class GitTools
    {
        // Properties
        public List<Repository> Repos;
        public int CurrFolderCount;
        public int RootFolderCount;
        private string _ErrorPathNotSelected = "Git location is not selected. Please browse to the Git install location (where git-cmd.exe is located).";
        private string _Path;
        public string Path { get => _Path; set => _Path = value; }
        // Constructors
        public GitTools()
        {
            _Path = "";
        }
        // Methods
        public void GetRepos(ref BackgroundWorker worker, string root, bool runFetch, bool runUnpulled, bool runUnpushed, bool runStashed, bool runUnmerged, bool recursive, bool showAll)
        {
            if (_Path != "")
            {
                Repos = new List<Repository>();
                CurrFolderCount = 0;
                RootFolderCount = 0;
                // Process root folder first
                ProcessFolder(root, root, runFetch, runUnpulled, runUnpushed, runStashed, runUnmerged, showAll);
                // Process sub-folders, recursively
                GitSummarySearch(ref worker, root, root, runFetch, runUnpulled, runUnpushed, runStashed, runUnmerged, recursive, showAll);
            }
        }
        private void GitSummarySearch(ref BackgroundWorker worker, string root, string path, bool runFetch, bool runUnpulled, bool runUnpushed, bool runStashed, bool runUnmerged, bool recursive, bool showAll)
        {
            // ON entry check if we need to stop
            if (worker.CancellationPending)
            {
                return;
            }
            else
            {
                RootFolderCount += Directory.GetDirectories(path).Length;
                // Run through selected path and load List<> with results for each sub-folder
                foreach (string subDir in Directory.GetDirectories(path))
                {
                    CurrFolderCount += 1;
                    worker.ReportProgress((CurrFolderCount * 100) / RootFolderCount);
                    // ProcessFolder will load the List<> and return True if it is a Repository
                    if (!ProcessFolder(root, subDir, runFetch, runUnpulled, runUnpushed, runStashed, runUnmerged, showAll) && recursive)
                    {
                        // Run recursively if the parent folder was NOT a Repository and recursive = true
                        GitSummarySearch(ref worker, root, subDir, runFetch, runUnpulled, runUnpushed, runStashed, runUnmerged, recursive, showAll);
                    }
                }
            }
        }
        public bool ProcessFolder(string root, string path, bool runFetch, bool runUnpulled, bool runUnpushed, bool runStashed, bool runUnmerged, bool showAll)
        {
            bool boolReturn = false;

            // Setup initial variables, to capture results of instances of RunCommand
            string stdOutput = "";
            string stdError = "";
            // Get initial Status (determine if Folder is a Repository)
            RunCommand("status", path, ref stdOutput, ref stdError);
            if (stdError == "" && stdOutput != "")
            {
                // If runFetch = true, then run Fetch (which slows down processing) to determine any changes on server
                if (runFetch)
                {
                    // This may Prompt User for Git credentials
                    RunCommand("fetch -q", path, ref stdOutput, ref stdError);
                    if (stdOutput != "" || stdError != "")
                    {
                        // There appears to never be any output ???
                        stdError = stdOutput;
                    }
                    // After fetch, run status again to get updated stdOutput
                    RunCommand("status", path, ref stdOutput, ref stdError);
                }
                // Parse values to write to List<>
                string folder = path.Substring(root.Length);
                string status = ParseOutput_Status(stdOutput);
                RunCommand("symbolic-ref HEAD", path, ref stdOutput, ref stdError);
                string branch = ParseOutput_Branch(stdOutput);
                // Split status into individual values for Counts
                bool untracked = false;
                bool newFiles = false;
                int? modified = null;
                int? deleted = null;
                bool unpulled = false;
                bool unpushed = false;
                bool stashed = false;
                bool unmerged = false;
                if (status.IndexOf("Untracked") >= 0)
                {
                    untracked = true;
                }
                if (status.IndexOf("new file") >= 0)
                {
                    // There appears to never be any data ???
                    newFiles = true;
                }
                if (status.IndexOf("modified") >= 0)
                {
                    modified = status.Select((c, i) => status.Substring(i)).Count(sub => sub.StartsWith("modified"));
                }
                if (status.IndexOf("deleted") >= 0)
                {
                    deleted = status.Select((c, i) => status.Substring(i)).Count(sub => sub.StartsWith("deleted"));
                }
                if (runUnpulled)
                {
                    RunCommand("log --pretty=format:'%h' ..@{u}", path, ref stdOutput, ref stdError);
                    if (stdOutput != "" || stdError != "")
                    {
                        unpulled = true;
                    }
                }
                if (runUnpushed)
                {
                    RunCommand("log --pretty=format:'%h' @{u}..", path, ref stdOutput, ref stdError);
                    if (stdOutput != "" || stdError != "")
                    {
                        unpushed = true;
                    }
                }
                if (runStashed)
                {
                    RunCommand("stash list", path, ref stdOutput, ref stdError);
                    if (stdOutput != "" || stdError != "")
                    {
                        stashed = true;
                    }
                }
                if (runUnmerged)
                {
                    RunCommand("branch --no-merged master", path, ref stdOutput, ref stdError);
                    if (stdOutput != "" || stdError != "")
                    {
                        unmerged = true;
                    }
                }
                RunCommand("remote get-url origin", path, ref stdOutput, ref stdError);
                string remote = stdOutput;
                bool diff = (untracked || newFiles || modified != null || deleted != null || unpulled || unpushed || stashed || unmerged || status != "nothing to commit, working tree clean");
                // Add Repository to List<>
                if (showAll || diff)
                {
                    Repos.Add(new Repository(folder, branch, status, diff, untracked, newFiles, modified, deleted, unpulled, unpushed, stashed, unmerged, remote));
                }
                boolReturn = true;
            }

            return boolReturn;
        }
        private string ParseOutput_Status(string stdOutput)
        {
            // Parse string to return Status in readable format
            string status = stdOutput.Substring(stdOutput.IndexOf("\n") + 1);
            if (status.IndexOf("Your branch is up to date with 'origin/master'.\n\n") == 0)
            {
                status = status.Substring(status.IndexOf("\n") + 2);
            }
            if (status.Substring(status.Length - 1) == "\n")
            {
                status = status.Substring(0, status.Length - 1);
            }

            return status;
        }
        private string ParseOutput_Branch(string stdOutput)
        {
            // Parse string to return only the Branch, cleanly
            string branch = stdOutput.Substring("refs/heads/".Length);
            branch = branch.Substring(0, branch.Length - 1);

            return branch;
        }
        public bool RunCommand(string command, string workingDirectory, ref string stdOutput, ref string stdError)
        {
            // Wrapper to run any command against Git, for a selected folder
            bool boolReturn = false;

            if (_Path == "")
            {
                stdError = _ErrorPathNotSelected;
            }
            else
            {
                ProcessStartInfo gitInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    FileName = _Path + @"\bin\git.exe",
                    UseShellExecute = false,
                    // Send Git the command (such as "fetch orign")
                    Arguments = command,
                    WorkingDirectory = workingDirectory
                };
                Process gitProcess = new Process()
                {
                    StartInfo = gitInfo
                };
                gitProcess.Start();
                // pick up STDERR
                stdError = gitProcess.StandardError.ReadToEnd();
                // pick up STDOUT
                stdOutput = gitProcess.StandardOutput.ReadToEnd();
                gitProcess.WaitForExit();
                gitProcess.Close();
                boolReturn = true;
            }

            return boolReturn;
        }
        public bool IsGitInstalled(string pathGit)
        {
            // Check selected path for existence of git install files
            bool boolReturn = false;
            _Path = "";

            if (Directory.Exists(pathGit))
            {
                if (File.Exists(pathGit + "\\git-cmd.exe"))
                {
                    _Path = pathGit;
                    boolReturn = true;
                }
            }

            return boolReturn;
        }
    }
}
