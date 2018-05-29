using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace git_tools
{
    class GitTools
    {
        // Properties
        private string _Path;
        public string Path { get => _Path; set => _Path = value; }
        // Constructors
        public GitTools()
        {
            _Path = "";
        }
        // Methods
        public bool GitInstalled(string pathGit)
        {
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
        public bool RunCommand(string command, string workingDirectory, ref string stdOutput, ref string stdError)
        {
            bool boolReturn = false;

            if (_Path != "")
            {
                ProcessStartInfo gitInfo = new ProcessStartInfo();
                gitInfo.CreateNoWindow = true;
                gitInfo.RedirectStandardError = true;
                gitInfo.RedirectStandardOutput = true;
                gitInfo.FileName = _Path + @"\bin\git.exe";
                gitInfo.UseShellExecute = false;
                Process gitProcess = new Process();
                // Send Git the command (such as "fetch orign")
                gitInfo.Arguments = command;
                gitInfo.WorkingDirectory = workingDirectory;
                gitProcess.StartInfo = gitInfo;
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
        public List<Repository> GetRepos(string root, bool localSummary, bool deepLookup)
        {
            //            blC.Trace(" ");
            List<Repository> Repos = new List<Repository>();
            ProcessFolder(root, root, localSummary, ref Repos);
            GitSummarySearch(root, root, localSummary, deepLookup, ref Repos);

            return Repos;
        }
        private void GitSummarySearch(string root, string path, bool localSummary, bool deepLookup, ref List<Repository> Repos)
        {
            foreach (string subDir in Directory.GetDirectories(path))
            {
                if (!ProcessFolder(root, subDir, localSummary, ref Repos) && deepLookup)
                {
                    GitSummarySearch(root, subDir, localSummary, deepLookup, ref Repos);
                }
            }
        }
        private bool ProcessFolder(string root, string path, bool localSummary, ref List<Repository> Repos)
        {
            bool boolReturn = false;

            string stdOutput = "";
            string stdError = "";
            RunCommand("status", path, ref stdOutput, ref stdError);
            if (stdError == "")
            {
                if (!localSummary)
                {
                    RunCommand("fetch -q", path, ref stdOutput, ref stdError);
                    if (stdOutput != "" || stdError != "")
                    {
                        stdOutput = stdOutput;
                    }
                    RunCommand("status", path, ref stdOutput, ref stdError);
                }
                // Parse stdOutput
                string folder = path.Substring(root.Length);
                // local branch_name=`git -C $f "`
                string status = stdOutput.Substring(stdOutput.IndexOf("\n") + 1);
                if (status.IndexOf("Your branch is up to date with 'origin/master'.\n\n") == 0)
                {
                    status = status.Substring(status.IndexOf("\n") + 2);
                }
                if (status.Substring(status.Length - 1) == "\n")
                {
                    status = status.Substring(0, status.Length - 1);
                }
                RunCommand("symbolic-ref HEAD", path, ref stdOutput, ref stdError);
                string branch = stdOutput.Substring("refs/heads/".Length);
                branch = branch.Substring(0, branch.Length - 1);
//                if (state != "nothing to commit, working tree clean\n")
//                {
//                    //RunGitCommand("rev-parse --abbrev-ref", subDir);
//                    //stdOutput = stdOutput;
//                    //RunGitCommand("log --pretty=format:'%h' ..@{u}", subDir);
//                    //stdOutput = stdOutput;
//                    //RunGitCommand("log --pretty=format:'%h' @{u}..", subDir);
//                    //stdOutput = stdOutput;
//                }
                Repos.Add(new Repository(folder, branch, status));
                boolReturn = true;
            }

            return boolReturn;
        }
    }
}
