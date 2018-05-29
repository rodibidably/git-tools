using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace git_tools
{
    public partial class Git_Tools : Form
    {
        GitTools gt = new GitTools();
        string stdError = "";
        string stdOutput = "";
        public Git_Tools()
        {
            InitializeComponent();
        }
        // Load Page | Browse for Git Location
        private void GitTools_Load(object sender, EventArgs e)
        {
            toolTips.SetToolTip(chkLocalSummary, "Checks only local changes (no Fetch first), which is faster.");
            toolTips.SetToolTip(chkDeepLookup, "Will look for Git repos recursivly within the directory tree (does not search sub folders under a Git repo). Can be slow for large trees.");
            LoadGitTools("C:\\Program Files\\Git");
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdGit.InitialDirectory = gt.Path;
            // Show the dialog.
            DialogResult result = ofdGit.ShowDialog();
            // Confirm result
            if (result == DialogResult.OK)
            {
                LoadGitTools(Path.GetDirectoryName(ofdGit.FileName));
            }
        }
        private void LoadGitTools(string pathGit)
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
            if (!gt.GitInstalled(pathGit))
            {
                // Prompt User for location
                lblStatus.Text = "Git is not installed/configured, or installed in a non-standard location. Please browse to the Git install location (where git-cmd.exe is located).";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lnkGitInstall.Visible = true;
            }
            else
            {
                // Git Installed, now let's test that we can run a simple command
                gt.RunCommand("--version", pathGit, ref stdOutput, ref stdError);
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
        // Clickable Links
        private void lnkGitLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Directory.Exists(gt.Path))
            {
                lnkGitLocation.Text = "";
                MessageBox.Show("Path does not exist. Please Browse for the Git installation directory.", "Path does not exist.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Process.Start(gt.Path);
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
                lnkGitSummaryRoot.Text = "";
                MessageBox.Show("Path does not exist. Please Browse for another Folder.", "Path does not exist.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Process.Start(lnkGitSummaryRoot.Text);
            }
        }
        // git-summary
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
                if (!tabNav.TabPages.Contains(tabGitSummary))
                {
                    tabNav.TabPages.Add(tabGitSummary);
                    tabNav.SelectedTab = tabGitSummary;
                }
                dgvGitSummary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvGitSummary.DataSource = gt.GetRepos(lnkGitSummaryRoot.Text, chkLocalSummary.Checked, chkDeepLookup.Checked);
            }
        }
        private void dgvGitSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                Process.Start(lnkGitSummaryRoot.Text + dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
        // git-branch-status
        private void btnGitBranchStatus_Click(object sender, EventArgs e)
        {
            // 
            if (!tabNav.TabPages.Contains(tabGitBranchStatus))
            {
                tabNav.TabPages.Add(tabGitBranchStatus);
                tabNav.SelectedTab = tabGitBranchStatus;
            }
        }
    }
}
