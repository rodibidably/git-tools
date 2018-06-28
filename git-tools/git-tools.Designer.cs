namespace git_tools
{
    partial class Git_Tools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Git_Tools));
            this.tabNav = new System.Windows.Forms.TabControl();
            this.tabGitTools = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.lnkGitInstall = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lnkGitTools = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabGitSummary = new System.Windows.Forms.TabPage();
            this.chkRunStashed = new System.Windows.Forms.CheckBox();
            this.chkRunUnmerged = new System.Windows.Forms.CheckBox();
            this.chkRunUnpushed = new System.Windows.Forms.CheckBox();
            this.chkRunUnpulled = new System.Windows.Forms.CheckBox();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.chkRunFetch = new System.Windows.Forms.CheckBox();
            this.btnGitSummary = new System.Windows.Forms.Button();
            this.lnkGitSummaryRoot = new System.Windows.Forms.LinkLabel();
            this.dgvGitSummary = new System.Windows.Forms.DataGridView();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diff = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Untracked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NewFiles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unpulled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unpushed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Stashed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unmerged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGitBranchStatus = new System.Windows.Forms.TabPage();
            this.btnGitBranchStatus = new System.Windows.Forms.Button();
            this.ofdGit = new System.Windows.Forms.OpenFileDialog();
            this.lnkGitLocation = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGitVersion = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.bwGitSummary = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tabNav.SuspendLayout();
            this.tabGitTools.SuspendLayout();
            this.tabGitSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitSummary)).BeginInit();
            this.tabGitBranchStatus.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNav
            // 
            this.tabNav.Controls.Add(this.tabGitTools);
            this.tabNav.Controls.Add(this.tabGitSummary);
            this.tabNav.Controls.Add(this.tabGitBranchStatus);
            this.tabNav.Location = new System.Drawing.Point(12, 44);
            this.tabNav.Name = "tabNav";
            this.tabNav.SelectedIndex = 0;
            this.tabNav.ShowToolTips = true;
            this.tabNav.Size = new System.Drawing.Size(760, 439);
            this.tabNav.TabIndex = 0;
            // 
            // tabGitTools
            // 
            this.tabGitTools.Controls.Add(this.label8);
            this.tabGitTools.Controls.Add(this.label7);
            this.tabGitTools.Controls.Add(this.lnkGitInstall);
            this.tabGitTools.Controls.Add(this.label4);
            this.tabGitTools.Controls.Add(this.label5);
            this.tabGitTools.Controls.Add(this.label6);
            this.tabGitTools.Controls.Add(this.lnkGitTools);
            this.tabGitTools.Controls.Add(this.label3);
            this.tabGitTools.Location = new System.Drawing.Point(4, 22);
            this.tabGitTools.Name = "tabGitTools";
            this.tabGitTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitTools.Size = new System.Drawing.Size(752, 413);
            this.tabGitTools.TabIndex = 2;
            this.tabGitTools.Text = "git-tools";
            this.tabGitTools.ToolTipText = "git-tools is a .NET application that acts as a wrapper around many popular git fu" +
    "nctions, designed to make using Git easier";
            this.tabGitTools.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.MaximumSize = new System.Drawing.Size(830, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "To setup Git, follow the instructions here:";
            // 
            // lnkGitInstall
            // 
            this.lnkGitInstall.AutoSize = true;
            this.lnkGitInstall.Location = new System.Drawing.Point(211, 46);
            this.lnkGitInstall.Name = "lnkGitInstall";
            this.lnkGitInstall.Size = new System.Drawing.Size(276, 13);
            this.lnkGitInstall.TabIndex = 21;
            this.lnkGitInstall.TabStop = true;
            this.lnkGitInstall.Text = "https://help.github.com/articles/set-up-git/#setting-up-git";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(251, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Coming next in development";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(600, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "git-branch-status shows the divergence relationship between branches for which th" +
    "e upstream differs from it\'s local counterpart\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(604, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "git-summary cleanly lists the current status of any Git repositories it finds wit" +
    "hin any directory (and sub-directories) on your system";
            // 
            // lnkGitTools
            // 
            this.lnkGitTools.AutoSize = true;
            this.lnkGitTools.Location = new System.Drawing.Point(6, 16);
            this.lnkGitTools.Name = "lnkGitTools";
            this.lnkGitTools.Size = new System.Drawing.Size(191, 13);
            this.lnkGitTools.TabIndex = 14;
            this.lnkGitTools.TabStop = true;
            this.lnkGitTools.Text = "https://github.com/rodibidably/git-tools";
            this.lnkGitTools.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGitTools_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.MaximumSize = new System.Drawing.Size(830, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(579, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "git-tools is a .NET application that acts as a wrapper around many popular git fu" +
    "nctions, designed to make using Git easier";
            // 
            // tabGitSummary
            // 
            this.tabGitSummary.Controls.Add(this.chkRunStashed);
            this.tabGitSummary.Controls.Add(this.chkRunUnmerged);
            this.tabGitSummary.Controls.Add(this.chkRunUnpushed);
            this.tabGitSummary.Controls.Add(this.chkRunUnpulled);
            this.tabGitSummary.Controls.Add(this.chkShowAll);
            this.tabGitSummary.Controls.Add(this.chkRecursive);
            this.tabGitSummary.Controls.Add(this.chkRunFetch);
            this.tabGitSummary.Controls.Add(this.btnGitSummary);
            this.tabGitSummary.Controls.Add(this.lnkGitSummaryRoot);
            this.tabGitSummary.Controls.Add(this.dgvGitSummary);
            this.tabGitSummary.Location = new System.Drawing.Point(4, 22);
            this.tabGitSummary.Name = "tabGitSummary";
            this.tabGitSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitSummary.Size = new System.Drawing.Size(752, 413);
            this.tabGitSummary.TabIndex = 0;
            this.tabGitSummary.Text = "git-summary";
            this.tabGitSummary.ToolTipText = "git-summary cleanly lists the current status of any Git repositories it finds wit" +
    "hin any directory (and sub-directories) on your system";
            this.tabGitSummary.UseVisualStyleBackColor = true;
            // 
            // chkRunStashed
            // 
            this.chkRunStashed.AutoSize = true;
            this.chkRunStashed.Location = new System.Drawing.Point(301, 6);
            this.chkRunStashed.Name = "chkRunStashed";
            this.chkRunStashed.Size = new System.Drawing.Size(92, 17);
            this.chkRunStashed.TabIndex = 31;
            this.chkRunStashed.Text = "Run \'Stashed\'";
            this.chkRunStashed.UseVisualStyleBackColor = true;
            // 
            // chkRunUnmerged
            // 
            this.chkRunUnmerged.AutoSize = true;
            this.chkRunUnmerged.Location = new System.Drawing.Point(399, 6);
            this.chkRunUnmerged.Name = "chkRunUnmerged";
            this.chkRunUnmerged.Size = new System.Drawing.Size(102, 17);
            this.chkRunUnmerged.TabIndex = 30;
            this.chkRunUnmerged.Text = "Run \'Unmerged\'";
            this.chkRunUnmerged.UseVisualStyleBackColor = true;
            // 
            // chkRunUnpushed
            // 
            this.chkRunUnpushed.AutoSize = true;
            this.chkRunUnpushed.Checked = true;
            this.chkRunUnpushed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunUnpushed.Location = new System.Drawing.Point(193, 6);
            this.chkRunUnpushed.Name = "chkRunUnpushed";
            this.chkRunUnpushed.Size = new System.Drawing.Size(102, 17);
            this.chkRunUnpushed.TabIndex = 29;
            this.chkRunUnpushed.Text = "Run \'Unpushed\'";
            this.chkRunUnpushed.UseVisualStyleBackColor = true;
            // 
            // chkRunUnpulled
            // 
            this.chkRunUnpulled.AutoSize = true;
            this.chkRunUnpulled.Checked = true;
            this.chkRunUnpulled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunUnpulled.Location = new System.Drawing.Point(92, 6);
            this.chkRunUnpulled.Name = "chkRunUnpulled";
            this.chkRunUnpulled.Size = new System.Drawing.Size(95, 17);
            this.chkRunUnpulled.TabIndex = 28;
            this.chkRunUnpulled.Text = "Run \'Unpulled\'";
            this.chkRunUnpulled.UseVisualStyleBackColor = true;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Checked = true;
            this.chkShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowAll.Location = new System.Drawing.Point(587, 6);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(101, 17);
            this.chkShowAll.TabIndex = 27;
            this.chkShowAll.Text = "Show All Repos";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(507, 6);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 17);
            this.chkRecursive.TabIndex = 26;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // chkRunFetch
            // 
            this.chkRunFetch.AutoSize = true;
            this.chkRunFetch.Location = new System.Drawing.Point(6, 6);
            this.chkRunFetch.Name = "chkRunFetch";
            this.chkRunFetch.Size = new System.Drawing.Size(80, 17);
            this.chkRunFetch.TabIndex = 25;
            this.chkRunFetch.Text = "Run \'Fetch\'";
            this.chkRunFetch.UseVisualStyleBackColor = true;
            // 
            // btnGitSummary
            // 
            this.btnGitSummary.Location = new System.Drawing.Point(6, 26);
            this.btnGitSummary.Name = "btnGitSummary";
            this.btnGitSummary.Size = new System.Drawing.Size(93, 26);
            this.btnGitSummary.TabIndex = 24;
            this.btnGitSummary.Text = "git-summary";
            this.btnGitSummary.UseVisualStyleBackColor = true;
            this.btnGitSummary.Click += new System.EventHandler(this.btnGitSummary_Click);
            // 
            // lnkGitSummaryRoot
            // 
            this.lnkGitSummaryRoot.AutoSize = true;
            this.lnkGitSummaryRoot.Location = new System.Drawing.Point(105, 26);
            this.lnkGitSummaryRoot.Name = "lnkGitSummaryRoot";
            this.lnkGitSummaryRoot.Size = new System.Drawing.Size(100, 13);
            this.lnkGitSummaryRoot.TabIndex = 16;
            this.lnkGitSummaryRoot.TabStop = true;
            this.lnkGitSummaryRoot.Text = "lnkGitSummaryRoot";
            this.lnkGitSummaryRoot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGitSummaryRoot_LinkClicked);
            // 
            // dgvGitSummary
            // 
            this.dgvGitSummary.AllowUserToAddRows = false;
            this.dgvGitSummary.AllowUserToDeleteRows = false;
            this.dgvGitSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGitSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGitSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folder,
            this.Branch,
            this.Diff,
            this.Untracked,
            this.NewFiles,
            this.Modified,
            this.Deleted,
            this.Unpulled,
            this.Unpushed,
            this.Stashed,
            this.Unmerged,
            this.Status,
            this.Remote});
            this.dgvGitSummary.Location = new System.Drawing.Point(6, 58);
            this.dgvGitSummary.Name = "dgvGitSummary";
            this.dgvGitSummary.ReadOnly = true;
            this.dgvGitSummary.Size = new System.Drawing.Size(740, 349);
            this.dgvGitSummary.TabIndex = 15;
            this.dgvGitSummary.Visible = false;
            this.dgvGitSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGitSummary_CellContentClick);
            this.dgvGitSummary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGitSummary_CellDoubleClick);
            // 
            // Folder
            // 
            this.Folder.DataPropertyName = "Folder";
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.Blue;
            this.Folder.DefaultCellStyle = dataGridViewCellStyle49;
            this.Folder.HeaderText = "Folder";
            this.Folder.Name = "Folder";
            this.Folder.ReadOnly = true;
            this.Folder.Width = 61;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "Branch";
            this.Branch.HeaderText = "Branch";
            this.Branch.Name = "Branch";
            this.Branch.ReadOnly = true;
            this.Branch.Width = 66;
            // 
            // Diff
            // 
            this.Diff.DataPropertyName = "Diff";
            this.Diff.HeaderText = "Diff";
            this.Diff.Name = "Diff";
            this.Diff.ReadOnly = true;
            this.Diff.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Diff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Diff.Visible = false;
            this.Diff.Width = 48;
            // 
            // Untracked
            // 
            this.Untracked.DataPropertyName = "Untracked";
            this.Untracked.HeaderText = "Untracked";
            this.Untracked.Name = "Untracked";
            this.Untracked.ReadOnly = true;
            this.Untracked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Untracked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Untracked.Width = 82;
            // 
            // NewFiles
            // 
            this.NewFiles.DataPropertyName = "NewFiles";
            this.NewFiles.HeaderText = "NewFiles";
            this.NewFiles.Name = "NewFiles";
            this.NewFiles.ReadOnly = true;
            this.NewFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NewFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NewFiles.Visible = false;
            this.NewFiles.Width = 75;
            // 
            // Modified
            // 
            this.Modified.DataPropertyName = "Modified";
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle50.NullValue = " ";
            this.Modified.DefaultCellStyle = dataGridViewCellStyle50;
            this.Modified.HeaderText = "Modified";
            this.Modified.Name = "Modified";
            this.Modified.ReadOnly = true;
            this.Modified.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modified.Width = 72;
            // 
            // Deleted
            // 
            this.Deleted.DataPropertyName = "Deleted";
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.NullValue = " ";
            this.Deleted.DefaultCellStyle = dataGridViewCellStyle51;
            this.Deleted.HeaderText = "Deleted";
            this.Deleted.Name = "Deleted";
            this.Deleted.ReadOnly = true;
            this.Deleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Deleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Deleted.Width = 50;
            // 
            // Unpulled
            // 
            this.Unpulled.DataPropertyName = "Unpulled";
            this.Unpulled.HeaderText = "Unpulled";
            this.Unpulled.Name = "Unpulled";
            this.Unpulled.ReadOnly = true;
            this.Unpulled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Unpulled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Unpulled.Width = 74;
            // 
            // Unpushed
            // 
            this.Unpushed.DataPropertyName = "Unpushed";
            this.Unpushed.HeaderText = "Unpushed";
            this.Unpushed.Name = "Unpushed";
            this.Unpushed.ReadOnly = true;
            this.Unpushed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Unpushed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Unpushed.Width = 81;
            // 
            // Stashed
            // 
            this.Stashed.DataPropertyName = "Stashed";
            this.Stashed.HeaderText = "Stashed";
            this.Stashed.Name = "Stashed";
            this.Stashed.ReadOnly = true;
            this.Stashed.Width = 52;
            // 
            // Unmerged
            // 
            this.Unmerged.DataPropertyName = "Unmerged";
            this.Unmerged.HeaderText = "Unmerged";
            this.Unmerged.Name = "Unmerged";
            this.Unmerged.ReadOnly = true;
            this.Unmerged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Unmerged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Unmerged.Width = 81;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // Remote
            // 
            this.Remote.DataPropertyName = "Remote";
            dataGridViewCellStyle52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle52.ForeColor = System.Drawing.Color.Blue;
            this.Remote.DefaultCellStyle = dataGridViewCellStyle52;
            this.Remote.HeaderText = "Remote";
            this.Remote.Name = "Remote";
            this.Remote.ReadOnly = true;
            this.Remote.Width = 69;
            // 
            // tabGitBranchStatus
            // 
            this.tabGitBranchStatus.Controls.Add(this.btnGitBranchStatus);
            this.tabGitBranchStatus.Location = new System.Drawing.Point(4, 22);
            this.tabGitBranchStatus.Name = "tabGitBranchStatus";
            this.tabGitBranchStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitBranchStatus.Size = new System.Drawing.Size(752, 413);
            this.tabGitBranchStatus.TabIndex = 1;
            this.tabGitBranchStatus.Text = "git-branch-status";
            this.tabGitBranchStatus.ToolTipText = "git-branch-status shows the divergence relationship between branches for which th" +
    "e upstream differs from it\'s local counterpart";
            this.tabGitBranchStatus.UseVisualStyleBackColor = true;
            // 
            // btnGitBranchStatus
            // 
            this.btnGitBranchStatus.Location = new System.Drawing.Point(6, 6);
            this.btnGitBranchStatus.Name = "btnGitBranchStatus";
            this.btnGitBranchStatus.Size = new System.Drawing.Size(93, 26);
            this.btnGitBranchStatus.TabIndex = 21;
            this.btnGitBranchStatus.Text = "git-branch-status";
            this.btnGitBranchStatus.UseVisualStyleBackColor = true;
            this.btnGitBranchStatus.Click += new System.EventHandler(this.btnGitBranchStatus_Click);
            // 
            // ofdGit
            // 
            this.ofdGit.FileName = "git-cmd.exe";
            this.ofdGit.Filter = "git-cmd|git-cmd.exe";
            this.ofdGit.Title = "Git Installtion Location";
            // 
            // lnkGitLocation
            // 
            this.lnkGitLocation.AutoSize = true;
            this.lnkGitLocation.Location = new System.Drawing.Point(166, 12);
            this.lnkGitLocation.Name = "lnkGitLocation";
            this.lnkGitLocation.Size = new System.Drawing.Size(75, 13);
            this.lnkGitLocation.TabIndex = 13;
            this.lnkGitLocation.TabStop = true;
            this.lnkGitLocation.Text = "lnkGitLocation";
            this.lnkGitLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGitLocation_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Git Location:";
            // 
            // lblGitVersion
            // 
            this.lblGitVersion.AutoSize = true;
            this.lblGitVersion.Location = new System.Drawing.Point(166, 28);
            this.lblGitVersion.Name = "lblGitVersion";
            this.lblGitVersion.Size = new System.Drawing.Size(65, 13);
            this.lblGitVersion.TabIndex = 10;
            this.lblGitVersion.Text = "lblGitVersion";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fbdPath
            // 
            this.fbdPath.Description = "Location to Run Git Tools against";
            this.fbdPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdPath.ShowNewFolderButton = false;
            // 
            // bwGitSummary
            // 
            this.bwGitSummary.WorkerReportsProgress = true;
            this.bwGitSummary.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGitSummary_DoWork);
            this.bwGitSummary.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGitSummary_ProgressChanged);
            this.bwGitSummary.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGitSummary_RunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel,
            this.tsProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 483);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(787, 22);
            this.statusStrip.TabIndex = 15;
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(76, 17);
            this.tsStatusLabel.Text = "tsStatusLabel";
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
            this.tsProgressBar.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 215);
            this.label8.MaximumSize = new System.Drawing.Size(730, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(729, 195);
            this.label8.TabIndex = 23;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // Git_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 505);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lnkGitLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGitVersion);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tabNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Git_Tools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "git-tools";
            this.Load += new System.EventHandler(this.GitTools_Load);
            this.tabNav.ResumeLayout(false);
            this.tabGitTools.ResumeLayout(false);
            this.tabGitTools.PerformLayout();
            this.tabGitSummary.ResumeLayout(false);
            this.tabGitSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitSummary)).EndInit();
            this.tabGitBranchStatus.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabNav;
        private System.Windows.Forms.TabPage tabGitSummary;
        private System.Windows.Forms.TabPage tabGitBranchStatus;
        private System.Windows.Forms.TabPage tabGitTools;
        private System.Windows.Forms.OpenFileDialog ofdGit;
        private System.Windows.Forms.LinkLabel lnkGitLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGitVersion;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.LinkLabel lnkGitTools;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.LinkLabel lnkGitSummaryRoot;
        private System.ComponentModel.BackgroundWorker bwGitSummary;
        private System.Windows.Forms.DataGridView dgvGitSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Diff;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Untracked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NewFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modified;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deleted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unpulled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unpushed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Stashed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unmerged;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remote;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.CheckBox chkRunFetch;
        private System.Windows.Forms.Button btnGitSummary;
        private System.Windows.Forms.CheckBox chkRunUnpulled;
        private System.Windows.Forms.CheckBox chkRunUnpushed;
        private System.Windows.Forms.CheckBox chkRunStashed;
        private System.Windows.Forms.CheckBox chkRunUnmerged;
        private System.Windows.Forms.Button btnGitBranchStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        private System.Windows.Forms.LinkLabel lnkGitInstall;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

