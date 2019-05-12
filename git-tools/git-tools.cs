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
        Common blC = new Common();
        GitTools gt = new GitTools();
        string stdError = "";
        string stdOutput = "";
        DateTime pStart;
        public Git_Tools()
        {
            InitializeComponent();
        }
        // Load Page | Browse for Git Location
        private void GitTools_Load(object sender, EventArgs e)
        {
            blC.Trace("");

            pStart = System.DateTime.Now;
            // Set One-Time form values that can't be set through designer and never change
            toolTips.SetToolTip(btnBrowse, "Browse to the Git install location (where git-cmd.exe is located).");
            toolTips.SetToolTip(lnkGitLocation, "Git install location (where git-cmd.exe is located).");
            toolTips.SetToolTip(lblGitVersion, "Git version installed.");
            toolTips.SetToolTip(btnGitSummary, "Browse to the folder to run git-summary against.");
            toolTips.SetToolTip(lnkGitSummaryRoot, "The selected folder that git-summary is running against.");
            toolTips.SetToolTip(chkRunFetch, "Checks local and remote changes (i.e. first run `git fetch`); Runs slower");
            toolTips.SetToolTip(chkRunUnpulled, "Checks local and remote changes (i.e. first run `git log --pretty=format:'%h' ..@{u}`); Runs slower");
            toolTips.SetToolTip(chkRunUnpushed, "Checks local and remote changes (i.e. first run `git log --pretty=format:'%h' @{u}..`); Runs slower");
            toolTips.SetToolTip(chkRunStashed, "Checks local and remote changes (i.e. first run `git stash list`); Runs slower");
            toolTips.SetToolTip(chkRunUnmerged, "Checks local and remote changes (i.e. first run `git branch --no-merged master`); Runs slower");
            toolTips.SetToolTip(chkRecursive, "Will look for Git repos recursively within the directory tree (does not search sub folders under a Git repo); Can be slow for large directory trees");
            toolTips.SetToolTip(chkShowAll, "Show all Repositories in List, even those without changes");
            tsStatusLabel.Text = "";
            tsStatusDetails.Text = "";
            lnkGitSummaryRoot.Text = "";
            dgvGitSummary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvGitSummary.AutoGenerateColumns = false;
            // Set Default Values where applicable
            blC.Trace("GitSummaryDefaults: " + ConfigurationManager.AppSettings["GitSummaryDefaults"]);
            chkRunFetch.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkRunFetch");
            chkRunUnpulled.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkRunUnpulled");
            chkRunUnpushed.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkRunUnpushed");
            chkRunStashed.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkRunStashed");
            chkRunUnmerged.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkRunUnmerged");
            chkRecursive.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkRecursive");
            chkShowAll.Checked = ConfigurationManager.AppSettings["GitSummaryDefaults"].Contains("chkShowAll");
            // Determine if Git is installed in default location
            LoadGitTools("C:\\Program Files\\Git");
            DisplayTimeElapsed();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            blC.Trace("");

            // Display the Open File Dialog
            ofdGit.InitialDirectory = gt.Path;
            DialogResult result = ofdGit.ShowDialog();
            blC.Trace("result: " + result);
            if (result == DialogResult.OK)
            {
                pStart = System.DateTime.Now;
                // Determine if Git is installed in User selected location
                LoadGitTools(Path.GetDirectoryName(ofdGit.FileName));
                DisplayTimeElapsed();
            }
        }
        private void LoadGitTools(string pathGit)
        {
            blC.Trace("pathGit: " + pathGit + " | IsGitInstalled: " + gt.IsGitInstalled(pathGit));

            // Cleanup form (to defaults) before processing
            tsStatusLabel.Text = "Validating Git is installed/configured...";
            tsStatusLabel.ForeColor = System.Drawing.Color.Black;
            lnkGitLocation.Text = pathGit;
            lblGitVersion.Text = "";
            btnGitSummary.Enabled = false;
            btnGitBranchStatus.Enabled = false;
            // Validate Git is installed
            if (!gt.IsGitInstalled(pathGit))
            {
                // Prompt User for alternate Git installation location
                tsStatusLabel.Text = "Git is not installed/configured, or installed in a non-standard location. Please browse to the Git install location (where git-cmd.exe is located).";
                tsStatusLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Git Installed, now let's test that we can run a simple command
                gt.RunCommand("--version", pathGit, ref stdOutput, ref stdError);
                lblGitVersion.Text = stdOutput;
                if (stdError != "")
                {
                    // Unable to determine Git version. Something may be wrong with the installation
                    tsStatusLabel.Text = "Git is installed, but appears to not be configured properly (unable to determine Git version). Please check your Git installation / configuration.";
                    tsStatusLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // Everything appears to be working... Woohoo!
                    tsStatusLabel.Text = "Git appears to be installed. If you would like to use a different location, please Browse to that path.";
                    btnGitSummary.Enabled = true;
                    btnGitBranchStatus.Enabled = true;
                }
            }
        }
        // Clickable Links
        private void lnkGitLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            blC.Trace("");

            // Open Windows Explorer to the Git Install Location
            blC.Trace("gt.Path: " + gt.Path + " | Exists: " + Directory.Exists(gt.Path));
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
            blC.Trace("");

            // Open Default Browser to the GitHub Project
            System.Diagnostics.Process.Start("https://github.com/rodibidably/git-tools");
        }
        private void lnkGitSummaryRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            blC.Trace("");

            // Open Windows Explorer to the selected Git Repository root
            blC.Trace("lnkGitSummaryRoot: " + lnkGitSummaryRoot.Text + " | Exists: " + Directory.Exists(lnkGitSummaryRoot.Text));
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
            blC.Trace("");

            // Do not allow new process to begin before old process has ended
            blC.Trace("bwGitSummary.IsBusy: " + bwGitSummary.IsBusy);
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
                    pStart = System.DateTime.Now;
                    blC.Trace("SelectedPath: " + fbdPath.SelectedPath);
                    // Write last path used to app.config
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings["LastPath"].Value = fbdPath.SelectedPath;
                    configuration.Save(ConfigurationSaveMode.Full, true);
                    ConfigurationManager.RefreshSection("appSettings");
                    // Cleanup form (to default / selected values / lock fields) before processing
                    lnkGitSummaryRoot.Text = fbdPath.SelectedPath;
                    tsStatusLabel.Text = ("Processing: ");
                    tsProgressBar.Visible = true;
                    tsProgressBar.Maximum = 100;
                    tsProgressBar.Minimum = 0;
                    tsProgressBar.Value = 0;
                    EnableFields(false);
                    // Start the asynchronous operation (essentially: bwGitSummary_DoWork)
                    bwGitSummary.RunWorkerAsync();
                }
            }
        }
        private void bwGitSummary_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            blC.Trace(" ");

            // This event handler is where the time-consuming work is done
            BackgroundWorker worker = sender as BackgroundWorker;
            // Recursively run through selected path to build List<>
            gt.GetRepos(ref worker, lnkGitSummaryRoot.Text, chkRunFetch.Checked, chkRunUnpulled.Checked, chkRunUnpushed.Checked, chkRunStashed.Checked, chkRunUnmerged.Checked, chkRecursive.Checked, chkShowAll.Checked, tsStatusDetails);
        }
        private void bwGitSummary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            blC.Trace("e.ProgressPercentage: " + e.ProgressPercentage);

            // This event handler updates the progress
            tsProgressBar.Value = e.ProgressPercentage;
        }
        private void bwGitSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            blC.Trace("e.Cancelled: " + e.Cancelled + " | (e.Error != null): " + (e.Error != null) + " | e.Result: " + e.Result);

            tsStatusDetails.Text = "";
            // This event handler deals with the results of the background operation
            if (e.Cancelled == true)
            {
                tsStatusLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                tsStatusLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                // Cleanup form after processing, to display results
                tsProgressBar.Visible = false;
                // After List<> has been built, now load DataGrid with results
                dgvGitSummary.DataSource = gt.Repos.FindAll(repo => (repo.Display == true));
                tsStatusLabel.Text = "Processed " + gt.Repos.Count + " repositories" + " (" + dgvGitSummary.RowCount + " displayed)";
                // Highlight rows with changes
                int highlightRows = 0;
                foreach (DataGridViewRow row in dgvGitSummary.Rows)
                {
                    if ((bool?)row.Cells["Diff"].Value == true)
                    {
                        highlightRows++;
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
                    }
                }
                blC.Trace("gt.Repos.Count: " + gt.Repos.Count + " | dgvGitSummary.RowCount: " + dgvGitSummary.RowCount + " | highlightRows: " + highlightRows);
                // Hide columns that were not collected
                dgvGitSummary.Columns["Unpulled"].Visible = chkRunUnpulled.Checked;
                dgvGitSummary.Columns["Unpushed"].Visible = chkRunUnpushed.Checked;
                dgvGitSummary.Columns["Stashed"].Visible = chkRunStashed.Checked;
                dgvGitSummary.Columns["Unmerged"].Visible = chkRunUnmerged.Checked;
            }
            // Cleanup form after processing, to enable fields
            EnableFields(true);
            tabNav.SelectedTab = tabGitSummary;
            DisplayTimeElapsed();
        }
        private void dgvGitSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            blC.Trace("");

            blC.Trace("RowIndex: " + e.RowIndex + " | ColumnIndex: " + e.ColumnIndex);
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Open Windows Explorer to the selected Git Repository
                blC.Trace("Process.Start - lnkGitSummaryRoot: " + lnkGitSummaryRoot.Text + " | Value: " + dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                Process.Start(lnkGitSummaryRoot.Text + dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 12)
            {
                // Open Default Browser to the GitHub Project
                blC.Trace("Process.Start - Value: " + dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                Process.Start(dgvGitSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
        private void DisplayTimeElapsed()
        {
            double timeElapsed = (System.DateTime.Now - pStart).TotalSeconds;
            blC.Trace("timeElapsed: " + timeElapsed);
            tsStatusLabel.Text += "   |   Processing Time: " + timeElapsed + " seconds";
        }
        private void EnableFields(bool enabled)
        {
            blC.Trace("enabled: " + enabled);

            dgvGitSummary.Visible = enabled;
            btnBrowse.Enabled = enabled;
            chkRunFetch.Enabled = enabled;
            chkRunUnpulled.Enabled = enabled;
            chkRunUnpushed.Enabled = enabled;
            chkRunStashed.Enabled = enabled;
            chkRunUnmerged.Enabled = enabled;
            chkRecursive.Enabled = enabled;
            chkShowAll.Enabled = enabled;
            btnGitSummary.Enabled = enabled;
        }
        private void dgvGitSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            blC.Trace("");

            blC.Trace("RowIndex: " + e.RowIndex + " | ColumnIndex: " + e.ColumnIndex);
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                // Git Branch Status
                MessageBox.Show("git-branch-status will be coming next in development", "Coming next in development", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGitSummarySaveDefaults_Click(object sender, EventArgs e)
        {
            blC.Trace("");

            // Save current values for Defaults to app.config
            string strDefaults = "";
            if (chkRunFetch.Checked)
            {
                strDefaults += "chkRunFetch,";
            }
            if (chkRunUnpulled.Checked)
            {
                strDefaults += "chkRunUnpulled,";
            }
            if (chkRunUnpushed.Checked)
            {
                strDefaults += "chkRunUnpushed,";
            }
            if (chkRunStashed.Checked)
            {
                strDefaults += "chkRunStashed,";
            }
            if (chkRunUnmerged.Checked)
            {
                strDefaults += "chkRunUnmerged,";
            }
            if (chkRecursive.Checked)
            {
                strDefaults += "chkRecursive,";
            }
            if (chkShowAll.Checked)
            {
                strDefaults += "chkShowAll,";
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("GitSummaryDefaults");
            config.AppSettings.Settings.Add("GitSummaryDefaults", strDefaults);
            config.Save(ConfigurationSaveMode.Minimal);
        }
        // git-branch-status
        private void btnGitBranchStatus_Click(object sender, EventArgs e)
        {
            blC.Trace("");

            // 
            MessageBox.Show("git-branch-status will be coming next in development", "Coming next in development", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tabNav.SelectedTab = tabGitBranchStatus;
        }
    }
}
