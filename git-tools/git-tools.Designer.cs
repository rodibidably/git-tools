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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGitSummary = new System.Windows.Forms.TabPage();
            this.tabGitBranchStatus = new System.Windows.Forms.TabPage();
            this.tabGitTools = new System.Windows.Forms.TabPage();
            this.wbGitTools = new System.Windows.Forms.WebBrowser();
            this.tabControl1.SuspendLayout();
            this.tabGitTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGitTools);
            this.tabControl1.Controls.Add(this.tabGitSummary);
            this.tabControl1.Controls.Add(this.tabGitBranchStatus);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 387);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGitSummary
            // 
            this.tabGitSummary.Location = new System.Drawing.Point(4, 22);
            this.tabGitSummary.Name = "tabGitSummary";
            this.tabGitSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitSummary.Size = new System.Drawing.Size(1052, 361);
            this.tabGitSummary.TabIndex = 0;
            this.tabGitSummary.Text = "git-summary";
            this.tabGitSummary.UseVisualStyleBackColor = true;
            // 
            // tabGitBranchStatus
            // 
            this.tabGitBranchStatus.Location = new System.Drawing.Point(4, 22);
            this.tabGitBranchStatus.Name = "tabGitBranchStatus";
            this.tabGitBranchStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitBranchStatus.Size = new System.Drawing.Size(1052, 361);
            this.tabGitBranchStatus.TabIndex = 1;
            this.tabGitBranchStatus.Text = "git-branch-status";
            this.tabGitBranchStatus.UseVisualStyleBackColor = true;
            // 
            // tabGitTools
            // 
            this.tabGitTools.Controls.Add(this.wbGitTools);
            this.tabGitTools.Location = new System.Drawing.Point(4, 22);
            this.tabGitTools.Name = "tabGitTools";
            this.tabGitTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabGitTools.Size = new System.Drawing.Size(702, 361);
            this.tabGitTools.TabIndex = 2;
            this.tabGitTools.Text = "git-tools";
            this.tabGitTools.UseVisualStyleBackColor = true;
            // 
            // wbGitTools
            // 
            this.wbGitTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbGitTools.Location = new System.Drawing.Point(3, 3);
            this.wbGitTools.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGitTools.Name = "wbGitTools";
            this.wbGitTools.Size = new System.Drawing.Size(696, 355);
            this.wbGitTools.TabIndex = 0;
            this.wbGitTools.Url = new System.Uri("https://github.com/rodibidably/git-tools/blob/master/README.md", System.UriKind.Absolute);
            // 
            // GitTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GitTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "git-tools";
            this.tabControl1.ResumeLayout(false);
            this.tabGitTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGitSummary;
        private System.Windows.Forms.TabPage tabGitBranchStatus;
        private System.Windows.Forms.TabPage tabGitTools;
        private System.Windows.Forms.WebBrowser wbGitTools;
    }
}

