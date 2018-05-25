using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace git_tools
{
    public partial class GitTools : Form
    {
        private string pathGit;
        string stdError = "";
        string stdOutput = "";
        DataTable tblGitData;
        public GitTools()
        {
            InitializeComponent();
        }
        private void GitTools_Load(object sender, EventArgs e)
        {
            pathGit = "C:\\Program Files\\Git";
            LoadGitTools();
            toolTips.SetToolTip(chkLocalSummary, "Checks only local changes (no Fetch first), which is faster.");
            toolTips.SetToolTip(chkDeepLookup, "Will look for Git repos recursivly within the directory tree (does not search sub folders under a Git repo). Can be slow for large trees.");
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdGit.InitialDirectory = pathGit;
            // Show the dialog.
            DialogResult result = ofdGit.ShowDialog();
            // Confirm result
            if (result == DialogResult.OK)
            {
                pathGit = Path.GetDirectoryName(ofdGit.FileName);
                LoadGitTools();
            }
        }
        private void lnkGitLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Directory.Exists(pathGit))
            {
                MessageBox.Show("Path does not exist. Please Browse for the Git installation directory.", "Path does not exist.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Process.Start(pathGit);
            }
        }
        private void lnkGitTools_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rodibidably/git-tools");
        }
        private void lnkGitSummaryRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Directory.Exists(lnkGitSummaryRoot.Text))
            {
                MessageBox.Show("Path does not exist. Please Browse for another Folder.", "Path does not exist.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Process.Start(lnkGitSummaryRoot.Text);
            }
        }
        private void btnGitSummary_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["LastPath"] != "")
            {
                fbdPath.SelectedPath = ConfigurationManager.AppSettings["LastPath"];
            }
            if (fbdPath.ShowDialog() == DialogResult.OK)
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["LastPath"].Value = fbdPath.SelectedPath;
                configuration.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");
//                ConfigurationManager.AppSettings["LastPath"] = fbdPath.SelectedPath;
                lnkGitSummaryRoot.Text = fbdPath.SelectedPath;
                lblGitSummaryOptions.Text = chkLocalSummary.Text + "=" + chkLocalSummary.Checked;
                lblGitSummaryOptions.Text += " | " + chkDeepLookup.Text + "=" + chkDeepLookup.Checked;
                tblGitData = new DataTable();
                tblGitData.Columns.Add("Folder", typeof(string));
                tblGitData.Columns.Add("Branch", typeof(string));
                tblGitData.Columns.Add("Status", typeof(string));
                if (!tabNav.TabPages.Contains(tabGitSummary))
                {
                    tabNav.TabPages.Add(tabGitSummary);
                    tabNav.SelectedTab = tabGitSummary;
                }
                ProcessFolder(lnkGitSummaryRoot.Text);
                GitSummarySearch(lnkGitSummaryRoot.Text);
                dgvGitSummary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvGitSummary.DataSource = tblGitData;
            }
        }
        private void btnGitBranchStatus_Click(object sender, EventArgs e)
        {
            // 
            if (!tabNav.TabPages.Contains(tabGitBranchStatus))
            {
                tabNav.TabPages.Add(tabGitBranchStatus);
                tabNav.SelectedTab = tabGitBranchStatus;
            }
        }
        private void GitSummarySearch(string directory)
        {
            foreach (string subDir in Directory.GetDirectories(directory))
            {
                if (!ProcessFolder(subDir) && chkDeepLookup.Checked)
                {
                    GitSummarySearch(subDir);
                }
            }
        }
        private bool ProcessFolder(string path)
        {
            bool boolReturn = false;

            RunGitCommand("status", path);
            if (stdError == "")
            {
                // Parse stdOutput
                string folder = path.Substring(lnkGitSummaryRoot.Text.Length);
                // local branch_name=`git -C $f "`
                string state = stdOutput.Substring(stdOutput.IndexOf("\n") + 1);
                if (state.IndexOf("Your branch is up to date with 'origin/master'.\n\n") == 0)
                {
                    state = state.Substring(state.IndexOf("\n") + 2);
                }
                if (state.Substring(state.Length - 1) == "\n")
                {
                    state = state.Substring(0, state.Length - 1);
                }
                RunGitCommand("symbolic-ref HEAD", path);
                string branch = stdOutput.Substring("refs/heads/".Length);
                branch = branch.Substring(0, branch.Length - 1);
                if (state != "nothing to commit, working tree clean\n")
                {
                    //RunGitCommand("rev-parse --abbrev-ref", subDir);
                    //stdOutput = stdOutput;
                    if (!chkLocalSummary.Checked)
                    {
                        RunGitCommand("fetch -q", path);
                        stdOutput = stdOutput;
                    }
                    //RunGitCommand("log --pretty=format:'%h' ..@{u}", subDir);
                    //stdOutput = stdOutput;
                    //RunGitCommand("log --pretty=format:'%h' @{u}..", subDir);
                    //stdOutput = stdOutput;
                }
                tblGitData.Rows.Add(folder, branch, state);//.Replace("\n", Environment.NewLine));
                boolReturn = true;
            }

            return boolReturn;
        }
        private void LoadGitTools()
        {
            lblStatus.Text = "Validating Git is installed/configured...";
            lblStatus.ForeColor = System.Drawing.Color.Black;
            lnkGitInstall.Visible = false;
            lnkGitLocation.Text = pathGit;
            lblGitVersion.Text = "";
            btnGitSummary.Enabled = false;
            btnGitBranchStatus.Enabled = false;
            if (tabNav.TabPages.Contains(tabGitSummary))
            {
                tabNav.TabPages.Remove(tabGitSummary);
                tabNav.TabPages.Remove(tabGitBranchStatus);
            }
            // Validate Git is installed
            if (!GitInstalled())
            {
                // Prompt User for location
                lblStatus.Text = "Git is not installed/configured, or installed in a non-standard location. Please browse to the Git install location (where git-cmd.exe is located).";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lnkGitInstall.Visible = true;
            }
            else
            {
                // Git Installed, now let's test that we can run a simple command
                RunGitCommand("--version", pathGit);
                lblGitVersion.Text = stdOutput;
                if (stdError != "")
                {
                    lblStatus.Text = "Git is installed, but appears to not be configured properly (unable to determine Git version). Please check your Git installation / configuration.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lnkGitInstall.Visible = true;
                }
                else
                {
                    // Everything appears to be working... Woohoo!
                    lblStatus.Text = "Git appears to be installed. If you would like to use a different location, please Browse to that path.";
                    btnGitSummary.Enabled = true;
                    btnGitBranchStatus.Enabled = true;
                }
            }
        }
        private void RunGitCommand(string command, string workingDirectory)
        {
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.FileName = pathGit + @"\bin\git.exe";
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
        }
        private bool GitInstalled()
        {
            bool boolReturn = false;

            if (Directory.Exists(pathGit))
            {
                if (File.Exists(pathGit + "\\git-cmd.exe"))
                {
                    boolReturn = true;
                }
            }

            return boolReturn;
        }
    }
}
