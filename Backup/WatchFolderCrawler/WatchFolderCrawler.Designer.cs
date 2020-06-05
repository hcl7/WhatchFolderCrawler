namespace WatchFolderCrawler
{
    partial class frmWFC
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
            this.gbinfo = new System.Windows.Forms.GroupBox();
            this.lblcreated = new System.Windows.Forms.Label();
            this.lblrenamed = new System.Windows.Forms.Label();
            this.lblnrdeleted = new System.Windows.Forms.Label();
            this.lblnrchanged = new System.Windows.Forms.Label();
            this.lblLastIndexed = new System.Windows.Forms.Label();
            this.lbldub = new System.Windows.Forms.Label();
            this.lblnrindexed = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.chbwatch = new System.Windows.Forms.CheckBox();
            this.chbsubdir = new System.Windows.Forms.CheckBox();
            this.txtlog = new System.Windows.Forms.TextBox();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.chbcrawler = new System.Windows.Forms.CheckBox();
            this.fswfoldercrawler = new System.IO.FileSystemWatcher();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.gbinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswfoldercrawler)).BeginInit();
            this.SuspendLayout();
            // 
            // gbinfo
            // 
            this.gbinfo.Controls.Add(this.lblstatus);
            this.gbinfo.Controls.Add(this.lblcreated);
            this.gbinfo.Controls.Add(this.lblrenamed);
            this.gbinfo.Controls.Add(this.lblnrdeleted);
            this.gbinfo.Controls.Add(this.lblnrchanged);
            this.gbinfo.Controls.Add(this.lblLastIndexed);
            this.gbinfo.Controls.Add(this.lbldub);
            this.gbinfo.Controls.Add(this.lblnrindexed);
            this.gbinfo.Location = new System.Drawing.Point(12, 202);
            this.gbinfo.Name = "gbinfo";
            this.gbinfo.Size = new System.Drawing.Size(783, 119);
            this.gbinfo.TabIndex = 0;
            this.gbinfo.TabStop = false;
            this.gbinfo.Text = "Information";
            // 
            // lblcreated
            // 
            this.lblcreated.AutoSize = true;
            this.lblcreated.Location = new System.Drawing.Point(209, 16);
            this.lblcreated.Name = "lblcreated";
            this.lblcreated.Size = new System.Drawing.Size(47, 13);
            this.lblcreated.TabIndex = 6;
            this.lblcreated.Text = "Created:";
            // 
            // lblrenamed
            // 
            this.lblrenamed.AutoSize = true;
            this.lblrenamed.Location = new System.Drawing.Point(367, 16);
            this.lblrenamed.Name = "lblrenamed";
            this.lblrenamed.Size = new System.Drawing.Size(56, 13);
            this.lblrenamed.TabIndex = 5;
            this.lblrenamed.Text = "Renamed:";
            // 
            // lblnrdeleted
            // 
            this.lblnrdeleted.AutoSize = true;
            this.lblnrdeleted.Location = new System.Drawing.Point(376, 42);
            this.lblnrdeleted.Name = "lblnrdeleted";
            this.lblnrdeleted.Size = new System.Drawing.Size(47, 13);
            this.lblnrdeleted.TabIndex = 4;
            this.lblnrdeleted.Text = "Deleted:";
            // 
            // lblnrchanged
            // 
            this.lblnrchanged.AutoSize = true;
            this.lblnrchanged.Location = new System.Drawing.Point(203, 42);
            this.lblnrchanged.Name = "lblnrchanged";
            this.lblnrchanged.Size = new System.Drawing.Size(53, 13);
            this.lblnrchanged.TabIndex = 3;
            this.lblnrchanged.Text = "Changed:";
            // 
            // lblLastIndexed
            // 
            this.lblLastIndexed.AutoSize = true;
            this.lblLastIndexed.Location = new System.Drawing.Point(14, 67);
            this.lblLastIndexed.Name = "lblLastIndexed";
            this.lblLastIndexed.Size = new System.Drawing.Size(68, 13);
            this.lblLastIndexed.TabIndex = 2;
            this.lblLastIndexed.Text = "LastIndexed:";
            // 
            // lbldub
            // 
            this.lbldub.AutoSize = true;
            this.lbldub.Location = new System.Drawing.Point(21, 42);
            this.lbldub.Name = "lbldub";
            this.lbldub.Size = new System.Drawing.Size(61, 13);
            this.lbldub.TabIndex = 1;
            this.lbldub.Text = "Dublicated:";
            // 
            // lblnrindexed
            // 
            this.lblnrindexed.AutoSize = true;
            this.lblnrindexed.Location = new System.Drawing.Point(34, 16);
            this.lblnrindexed.Name = "lblnrindexed";
            this.lblnrindexed.Size = new System.Drawing.Size(48, 13);
            this.lblnrindexed.TabIndex = 0;
            this.lblnrindexed.Text = "Indexed:";
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(12, 176);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(256, 20);
            this.txtpath.TabIndex = 1;
            this.txtpath.Text = "c:\\";
            // 
            // chbwatch
            // 
            this.chbwatch.AutoSize = true;
            this.chbwatch.Location = new System.Drawing.Point(481, 179);
            this.chbwatch.Name = "chbwatch";
            this.chbwatch.Size = new System.Drawing.Size(58, 17);
            this.chbwatch.TabIndex = 2;
            this.chbwatch.Text = "Watch";
            this.chbwatch.UseVisualStyleBackColor = true;
            this.chbwatch.CheckedChanged += new System.EventHandler(this.chbwatch_CheckedChanged);
            // 
            // chbsubdir
            // 
            this.chbsubdir.AutoSize = true;
            this.chbsubdir.Location = new System.Drawing.Point(382, 179);
            this.chbsubdir.Name = "chbsubdir";
            this.chbsubdir.Size = new System.Drawing.Size(93, 17);
            this.chbsubdir.TabIndex = 3;
            this.chbsubdir.Text = "Subdirectories";
            this.chbsubdir.UseVisualStyleBackColor = true;
            // 
            // txtlog
            // 
            this.txtlog.Location = new System.Drawing.Point(12, 12);
            this.txtlog.Multiline = true;
            this.txtlog.Name = "txtlog";
            this.txtlog.ReadOnly = true;
            this.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlog.Size = new System.Drawing.Size(783, 148);
            this.txtlog.TabIndex = 4;
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(285, 176);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(91, 20);
            this.txtfilter.TabIndex = 5;
            this.txtfilter.Text = "*.*";
            // 
            // chbcrawler
            // 
            this.chbcrawler.AutoSize = true;
            this.chbcrawler.Location = new System.Drawing.Point(575, 178);
            this.chbcrawler.Name = "chbcrawler";
            this.chbcrawler.Size = new System.Drawing.Size(61, 17);
            this.chbcrawler.TabIndex = 6;
            this.chbcrawler.Text = "Crawler";
            this.chbcrawler.UseVisualStyleBackColor = true;
            this.chbcrawler.CheckedChanged += new System.EventHandler(this.chbcrawler_CheckedChanged);
            // 
            // fswfoldercrawler
            // 
            this.fswfoldercrawler.EnableRaisingEvents = true;
            this.fswfoldercrawler.SynchronizingObject = this;
            this.fswfoldercrawler.Renamed += new System.IO.RenamedEventHandler(this.fswfoldercrawler_Renamed);
            this.fswfoldercrawler.Deleted += new System.IO.FileSystemEventHandler(this.fswfoldercrawler_Deleted);
            this.fswfoldercrawler.Created += new System.IO.FileSystemEventHandler(this.fswfoldercrawler_Created);
            this.fswfoldercrawler.Changed += new System.IO.FileSystemEventHandler(this.fswfoldercrawler_Changed);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(642, 172);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(66, 23);
            this.btnclear.TabIndex = 7;
            this.btnclear.Text = "ClearLog";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(714, 172);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(62, 23);
            this.btnclose.TabIndex = 8;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(42, 91);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(40, 13);
            this.lblstatus.TabIndex = 7;
            this.lblstatus.Text = "Status:";
            // 
            // frmWFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 333);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.chbcrawler);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.txtlog);
            this.Controls.Add(this.chbsubdir);
            this.Controls.Add(this.chbwatch);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.gbinfo);
            this.MaximizeBox = false;
            this.Name = "frmWFC";
            this.Text = "WatchFolderCrawler";
            this.Load += new System.EventHandler(this.frmWFC_Load);
            this.gbinfo.ResumeLayout(false);
            this.gbinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswfoldercrawler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbinfo;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.CheckBox chbwatch;
        private System.Windows.Forms.Label lblnrindexed;
        private System.Windows.Forms.CheckBox chbsubdir;
        private System.Windows.Forms.TextBox txtlog;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.CheckBox chbcrawler;
        private System.IO.FileSystemWatcher fswfoldercrawler;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label lbldub;
        private System.Windows.Forms.Label lblLastIndexed;
        private System.Windows.Forms.Label lblnrchanged;
        private System.Windows.Forms.Label lblnrdeleted;
        private System.Windows.Forms.Label lblrenamed;
        private System.Windows.Forms.Label lblcreated;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label lblstatus;
    }
}

