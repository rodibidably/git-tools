namespace git_tools
{
    partial class GitTools
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabNav = new System.Windows.Forms.TabControl();
            this.tabGitTools = new System.Windows.Forms.TabPage();
            this.chkDeepLookup = new System.Windows.Forms.CheckBox();
            this.chkLocalSummary = new System.Windows.Forms.CheckBox();
            this.btnGitBranchStatus = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGitSummary = new System.Windows.Forms.Button();
            this.lnkGitTools = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabGitSummary = new System.Windows.Forms.TabPage();
            this.lblGitSummaryOptions = new System.Windows.Forms.Label();
            this.lnkGitSummaryRoot = new System.Windows.Forms.LinkLabel();
            this.dgvGitSummary = new System.Windows.Forms.DataGridView();
            this.tabGitBranchStatus = new System.Windows.Forms.TabPage();
            this.ofdGit = new System.Windows.Forms.OpenFileDialog();
            this.lnkGitLocation = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGitVersion = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lnkGitInstall = new System.Windows.Forms.LinkLabel();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabNav.SuspendLayout();
            this.tabGitTools.SuspendLayout();
            this.tabGitSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // tabNav
            // 
            this.tabNav.Controls.Add(this.tabGitTools);
            this.tabNav.Controls.Add(this.tabGitSummary);
            this.tabNav.Controls.Add(this.tabGitBranchStatus);
            this.tabNav.Location = new System.Drawing.Point(15, 70);
            this.tabNav.Name = "tabNav";
            this.tabNav.SelectedIndex = 0;
            this.tabNav.Size = new System.Drawing.Size(707, 379);
            this.tabNav.TabIndex = 0;
            // 
            // tabGitTools
            // 
            this.tabGitTools.Controls.Add(this.chkDeepLookup);
            this.tabGitTools.Controls.Add(this.chkLocalSummary);
            this.tabGitTools.Controls.Add(this.btnGitBranchStatus);
            this.tabGitTools.Controls.Add(this.label5);
            this.tabGitTools.Controls.Add(this.label6);
            this.tabGitTools.Controls.Add(this.btnGitSummary);
            this.tabGitTools.Controls.Add(this.lnkGitTools);
            this.tabGitTools.Controls.Add(this.label3);
            this.tabGitTools.Location = new System.Drawing.Point(4, 22);
            this.tabGitTools.Name = "tabGitTools";
            this.tabGitTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitTools.Size = new System.Drawing.Size(699, 353);
            this.tabGitTools.TabIndex = 2;
            this.tabGitTools.Text = "git-tools";
            this.tabGitTools.UseVisualStyleBackColor = true;
            // 
            // chkDeepLookup
            // 
            this.chkDeepLookup.AutoSize = true;
            this.chkDeepLookup.Location = new System.Drawing.Point(113, 71);
            this.chkDeepLookup.Name = "chkDeepLookup";
            this.chkDeepLookup.Size = new System.Drawing.Size(91, 17);
            this.chkDeepLookup.TabIndex = 22;
            this.chkDeepLookup.Text = "Deep Lookup";
            this.chkDeepLookup.UseVisualStyleBackColor = true;
            // 
            // chkLocalSummary
            // 
            this.chkLocalSummary.AutoSize = true;
            this.chkLocalSummary.Checked = true;
            this.chkLocalSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocalSummary.Location = new System.Drawing.Point(9, 71);
            this.chkLocalSummary.Name = "chkLocalSummary";
            this.chkLocalSummary.Size = new System.Drawing.Size(98, 17);
            this.chkLocalSummary.TabIndex = 21;
            this.chkLocalSummary.Text = "Local Summary";
            this.chkLocalSummary.UseVisualStyleBackColor = true;
            // 
            // btnGitBranchStatus
            // 
            this.btnGitBranchStatus.Location = new System.Drawing.Point(9, 129);
            this.btnGitBranchStatus.Name = "btnGitBranchStatus";
            this.btnGitBranchStatus.Size = new System.Drawing.Size(93, 26);
            this.btnGitBranchStatus.TabIndex = 20;
            this.btnGitBranchStatus.Text = "git-branch-status";
            this.btnGitBranchStatus.UseVisualStyleBackColor = true;
            this.btnGitBranchStatus.Click += new System.EventHandler(this.btnGitBranchStatus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(600, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "git-branch-status shows the divergence relationship between branches for which th" +
    "e upstream differs from it\'s local counterpart\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(582, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "git-summary will neatly list the current status of any git repos it finds within " +
    "any directory (and sub directories) on your system";
            // 
            // btnGitSummary
            // 
            this.btnGitSummary.Location = new System.Drawing.Point(210, 71);
            this.btnGitSummary.Name = "btnGitSummary";
            this.btnGitSummary.Size = new System.Drawing.Size(93, 26);
            this.btnGitSummary.TabIndex = 14;
            this.btnGitSummary.Text = "git-summary";
            this.btnGitSummary.UseVisualStyleBackColor = true;
            this.btnGitSummary.Click += new System.EventHandler(this.btnGitSummary_Click);
            // 
            // lnkGitTools
            // 
            this.lnkGitTools.AutoSize = true;
            this.lnkGitTools.Location = new System.Drawing.Point(6, 29);
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
            this.label3.MaximumSize = new System.Drawing.Size(690, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(690, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "git-tools is a .NET application that acts as a wrapper around many popular git fu" +
    "nctions to make application development easier. For more details, check out the " +
    "repository on GitHub";
            // 
            // tabGitSummary
            // 
            this.tabGitSummary.Controls.Add(this.lblGitSummaryOptions);
            this.tabGitSummary.Controls.Add(this.lnkGitSummaryRoot);
            this.tabGitSummary.Controls.Add(this.dgvGitSummary);
            this.tabGitSummary.Location = new System.Drawing.Point(4, 22);
            this.tabGitSummary.Name = "tabGitSummary";
            this.tabGitSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitSummary.Size = new System.Drawing.Size(699, 353);
            this.tabGitSummary.TabIndex = 0;
            this.tabGitSummary.Text = "git-summary";
            this.tabGitSummary.UseVisualStyleBackColor = true;
            // 
            // lblGitSummaryOptions
            // 
            this.lblGitSummaryOptions.AutoSize = true;
            this.lblGitSummaryOptions.Location = new System.Drawing.Point(6, 16);
            this.lblGitSummaryOptions.Name = "lblGitSummaryOptions";
            this.lblGitSummaryOptions.Size = new System.Drawing.Size(109, 13);
            this.lblGitSummaryOptions.TabIndex = 15;
            this.lblGitSummaryOptions.Text = "lblGitSummaryOptions";
            // 
            // lnkGitSummaryRoot
            // 
            this.lnkGitSummaryRoot.AutoSize = true;
            this.lnkGitSummaryRoot.Location = new System.Drawing.Point(6, 3);
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
            this.Status});
            this.dgvGitSummary.Location = new System.Drawing.Point(6, 32);
            this.dgvGitSummary.Name = "dgvGitSummary";
            this.dgvGitSummary.ReadOnly = true;
            this.dgvGitSummary.Size = new System.Drawing.Size(687, 315);
            this.dgvGitSummary.TabIndex = 15;
            this.dgvGitSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGitSummary_CellContentClick);
            // 
            // tabGitBranchStatus
            // 
            this.tabGitBranchStatus.Location = new System.Drawing.Point(4, 22);
            this.tabGitBranchStatus.Name = "tabGitBranchStatus";
            this.tabGitBranchStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitBranchStatus.Size = new System.Drawing.Size(699, 353);
            this.tabGitBranchStatus.TabIndex = 1;
            this.tabGitBranchStatus.Text = "git-branch-status";
            this.tabGitBranchStatus.UseVisualStyleBackColor = true;
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
            this.lnkGitLocation.Location = new System.Drawing.Point(169, 38);
            this.lnkGitLocation.Name = "lnkGitLocation";
            this.lnkGitLocation.Size = new System.Drawing.Size(75, 13);
            this.lnkGitLocation.TabIndex = 13;
            this.lnkGitLocation.TabStop = true;
            this.lnkGitLocation.Text = "lnkGitLocation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Git Location:";
            // 
            // lblGitVersion
            // 
            this.lblGitVersion.AutoSize = true;
            this.lblGitVersion.Location = new System.Drawing.Point(169, 54);
            this.lblGitVersion.Name = "lblGitVersion";
            this.lblGitVersion.Size = new System.Drawing.Size(65, 13);
            this.lblGitVersion.TabIndex = 10;
            this.lblGitVersion.Text = "lblGitVersion";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.MaximumSize = new System.Drawing.Size(735, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "lblStatus";
            // 
            // lnkGitInstall
            // 
            this.lnkGitInstall.AutoSize = true;
            this.lnkGitInstall.Location = new System.Drawing.Point(12, 22);
            this.lnkGitInstall.Name = "lnkGitInstall";
            this.lnkGitInstall.Size = new System.Drawing.Size(276, 13);
            this.lnkGitInstall.TabIndex = 14;
            this.lnkGitInstall.TabStop = true;
            this.lnkGitInstall.Text = "https://help.github.com/articles/set-up-git/#setting-up-git";
            this.lnkGitInstall.Visible = false;
            // 
            // fbdPath
            // 
            this.fbdPath.Description = "Location to Run Git Tools against";
            this.fbdPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdPath.ShowNewFolderButton = false;
            // 
            // Folder
            // 
            this.Folder.DataPropertyName = "Folder";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.Folder.DefaultCellStyle = dataGridViewCellStyle1;
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
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // GitTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.lnkGitInstall);
            this.Controls.Add(this.lnkGitLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGitVersion);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GitTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "git-tools";
            this.Load += new System.EventHandler(this.GitTools_Load);
            this.tabNav.ResumeLayout(false);
            this.tabGitTools.ResumeLayout(false);
            this.tabGitTools.PerformLayout();
            this.tabGitSummary.ResumeLayout(false);
            this.tabGitSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGitSummary)).EndInit();
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
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkGitTools;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGitSummary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGitBranchStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvGitSummary;
        private System.Windows.Forms.LinkLabel lnkGitInstall;
        private System.Windows.Forms.CheckBox chkLocalSummary;
        private System.Windows.Forms.CheckBox chkDeepLookup;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.LinkLabel lnkGitSummaryRoot;
        private System.Windows.Forms.Label lblGitSummaryOptions;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

