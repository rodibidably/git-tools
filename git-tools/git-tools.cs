using System;
using System.ComponentModel;
using System.Configuration;
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
            // Set One-Time form values that can't be set through designer and never change
            toolTips.SetToolTip(chkRunFetch, "Checks local and remote changes (i.e. first run `git fetch`); Runs slower");
            toolTips.SetToolTip(chkRunUnpulled, "Checks local and remote changes (i.e. first run `git log --pretty=format:'%h' ..@{u}`); Runs slower");
            toolTips.SetToolTip(chkRunUnpushed, "Checks local and remote changes (i.e. first run `git log --pretty=format:'%h' @{u}..`); Runs slower");
            toolTips.SetToolTip(chkRunStashed, "Checks local and remote changes (i.e. first run `git stash list`); Runs slower");
            toolTips.SetToolTip(chkRunUnmerged, "Checks local and remote changes (i.e. first run `git branch --no-merged master`); Runs slower");
            toolTips.SetToolTip(chkRecursive, "Will look for Git repos recursively within the directory tree (does not search sub folders under a Git repo); Can be slow for large directory trees");
            toolTips.SetToolTip(chkShowAll, "Show all Repositories in List, even those without changes");
            lblGitSummaryProgress.Text = "";
            lnkGitSummaryRoot.Text = "";
            dgvGitSummary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvGitSummary.AutoGenerateColumns = false;
            // Determine if Git is installed in default location
            LoadGitTools("C:\\Program Files\\Git");
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Display the Open File Dialog
            ofdGit.InitialDirectory = gt.Path;
            DialogResult result = ofdGit.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Determine if Git is installed in User selected location
                LoadGitTools(Path.GetDirectoryName(ofdGit.FileName));
            }
        }
        private void LoadGitTools(string pathGit)
        {
            // Cleanup form (to defaults) before processing
            lblStatus.Text = "Validating Git is installed/configured...";
            lblStatus.ForeColor = System.Drawing.Color.Black;
            lnkGitInstall.Visible = false;
            lnkGitLocation.Text = pathGit;
            lblGitVersion.Text = "";
            btnGitSummary.Enabled = false;
            btnGitBranchStatus.Enabled = false;
            // Validate Git is installed
            if (!gt.IsGitInstalled(pathGit))
            {
                // Prompt User for alternate Git installation location
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
                    // Unable to determine Git version. Something may be wrong with the installation
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
            // Open Windows Explorer to the Git Install Location
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
            // Open Default Browser to the GitHub Project
            System.Diagnostics.Process.Start("https://github.com/rodibidably/git-tools");
        }
        private void lnkGitSummaryRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Windows Explorer to the selected Git Repository root
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
            // Do not allow new process to begin before old process has ended
            if (bwGitSummary.IsBusy != true)
            {
                // Set Default Path to the last path used
                if (ConfigurationManager.AppSettings["LastPath"] != "")
                {
                    fbdPath.SelectedPath = ConfigurationManager.AppSettings["LastPath"];
                }
                // Display the Open Folder Dialog
                if (fbdPath.ShowDialog() == DialogResult.OK)
                {
                    // Write last path used to app.config
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings["LastPath"].Value = fbdPath.SelectedPath;
                    configuration.Save(ConfigurationSaveMode.Full, true);
                    ConfigurationManager.RefreshSection("appSettings");
//                    ConfigurationManager.AppSettings["LastPath"] = fbdPath.SelectedPath;
                    // Cleanup form (to default / selected values / lock fields) before processing
                    lnkGitSummaryRoot.Text = fbdPath.SelectedPath;
                    lblGitSummaryProgress.Visible = true;
                    lblGitSummaryProgress.Text = ("Processing: 0%");
                    dgvGitSummary.Visible = false;
                    chkRunFetch.Enabled = false;
                    chkRunUnpulled.Enabled = false;
                    chkRunUnpushed.Enabled = false;
                    chkRunStashed.Enabled = false;
                    chkRunUnmerged.Enabled = false;
                    chkRecursive.Enabled = false;
                    chkShowAll.Enabled = false;
                    btnGitSummary.Enabled = false;
                    // Start the asynchronous operation (essentially: bwGitSummary_DoWork)
                    bwGitSummary.RunWorkerAsync();
                }
            }
        }
        private void bwGitSummary_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // This event handler is where the time-consuming work is done
            BackgroundWorker worker = sender as BackgroundWorker;
            // Recursively run through selected path to build List<>
            gt.GetRepos(ref worker, lnkGitSummaryRoot.Text, chkRunFetch.Checked, chkRunUnpulled.Checked, chkRunUnpushed.Checked, chkRunStashed.Checked, chkRunUnmerged.Checked, chkRecursive.Checked, chkShowAll.Checked);
        }
        private void bwGitSummary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This event handler updates the progress
            lblGitSummaryProgress.Text = ("Processing: " + e.ProgressPercentage.ToString() + "%");
        }
        private void bwGitSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This event handler deals with the results of the background operation
            if (e.Cancelled == true)
            {
                lblGitSummaryProgress.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                lblGitSummaryProgress.Text = "Error: " + e.Error.Message;
            }
            else
            {
                // Cleanup form after processing, to display results
                lblGitSummaryProgress.Visible = false;
                dgvGitSummary.Visible = true;
                // After List<> has been built, now load DataGrid with results
                dgvGitSummary.DataSource = gt.Repos;
                // Highlight rows with changes
                foreach (DataGridViewRow row in dgvGitSummary.Rows)
                {
                    if ((bool?)row.Cells["Diff"].Value == true)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
                    }
                }
                // Hide columns that were not collected
                dgvGitSummary.Columns["Unpulled"].Visible = chkRunUnpulled.Checked;
                dgvGitSummary.Columns["Unpushed"].Visible = chkRunUnpushed.Checked;
                dgvGitSummary.Columns["Stashed"].Visible = chkRunStashed.Checked;
                dgvGitSummary.Columns["Unmerged"].Visible = chkRunUnmerged.Checked;
                // Cleanup form after processing, to enable fields
                chkRunFetch.Enabled = true;
                chkRunUnpulled.Enabled = true;
                chkRunUnpushed.Enabled = true;
                chkRunStashed.Enabled = true;
                chkRunUnmerged.Enabled = true;
                chkRecursive.Enabled = true;
                chkShowAll.Enabled = true;
                btnGitSummary.Enabled = true;
                tabNav.SelectedTab = tabGitSummary;
            }
        }
        private void dgvGitSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Open Windows Explorer to the selected Git Repository
                Process.Start(lnkGitSummaryRoot.Text + dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 12)
            {
                // Open Default Browser to the GitHub Project
                System.Diagnostics.Process.Start(dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
        // git-branch-status
        private void btnGitBranchStatus_Click(object sender, EventArgs e)
        {
            // 
            MessageBox.Show("git-branch-status will be coming next in development", "Coming next in development", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tabNav.SelectedTab = tabGitBranchStatus;
        }
    }
}
