namespace WebTester
{
    partial class WebTester
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
            this.btnURL = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lstvURL = new System.Windows.Forms.ListView();
            this.colURL = new System.Windows.Forms.ColumnHeader();
            this.colText = new System.Windows.Forms.ColumnHeader();
            this.btnNewPath = new System.Windows.Forms.Button();
            this.btnNumberofURL = new System.Windows.Forms.Button();
            this.lstvWebSite = new System.Windows.Forms.ListView();
            this.colHwebSite = new System.Windows.Forms.ColumnHeader();
            this.colHName = new System.Windows.Forms.ColumnHeader();
            this.btnNumberWebSitePath = new System.Windows.Forms.Button();
            this.btnAverage = new System.Windows.Forms.Button();
            this.txtNumberURL = new System.Windows.Forms.TextBox();
            this.txtNumberWebSite = new System.Windows.Forms.TextBox();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCas4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCase16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnURL
            // 
            this.btnURL.Location = new System.Drawing.Point(12, 12);
            this.btnURL.Name = "btnURL";
            this.btnURL.Size = new System.Drawing.Size(170, 23);
            this.btnURL.TabIndex = 0;
            this.btnURL.Text = "Read Hyperlinks from URL";
            this.btnURL.UseVisualStyleBackColor = true;
            this.btnURL.Click += new System.EventHandler(this.btnURL_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(278, 14);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(287, 20);
            this.txtURL.TabIndex = 2;
            this.txtURL.Text = "http://www.";
            // 
            // lstvURL
            // 
            this.lstvURL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colURL,
            this.colText});
            this.lstvURL.Location = new System.Drawing.Point(12, 57);
            this.lstvURL.Name = "lstvURL";
            this.lstvURL.Size = new System.Drawing.Size(786, 220);
            this.lstvURL.TabIndex = 3;
            this.lstvURL.UseCompatibleStateImageBehavior = false;
            this.lstvURL.View = System.Windows.Forms.View.Details;
            // 
            // colURL
            // 
            this.colURL.Text = "URL";
            this.colURL.Width = 360;
            // 
            // colText
            // 
            this.colText.Text = "Text";
            this.colText.Width = 411;
            // 
            // btnNewPath
            // 
            this.btnNewPath.Location = new System.Drawing.Point(12, 285);
            this.btnNewPath.Name = "btnNewPath";
            this.btnNewPath.Size = new System.Drawing.Size(119, 23);
            this.btnNewPath.TabIndex = 4;
            this.btnNewPath.Text = "Navigate a new path";
            this.btnNewPath.UseVisualStyleBackColor = true;
            this.btnNewPath.Click += new System.EventHandler(this.btnNewPath_Click);
            // 
            // btnNumberofURL
            // 
            this.btnNumberofURL.Location = new System.Drawing.Point(228, 285);
            this.btnNumberofURL.Name = "btnNumberofURL";
            this.btnNumberofURL.Size = new System.Drawing.Size(249, 23);
            this.btnNumberofURL.TabIndex = 5;
            this.btnNumberofURL.Text = "Calculate number of read Hyperlinks from URL";
            this.btnNumberofURL.UseVisualStyleBackColor = true;
            this.btnNumberofURL.Click += new System.EventHandler(this.btnNumberofURL_Click);
            // 
            // lstvWebSite
            // 
            this.lstvWebSite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHwebSite,
            this.colHName});
            this.lstvWebSite.Location = new System.Drawing.Point(12, 322);
            this.lstvWebSite.Name = "lstvWebSite";
            this.lstvWebSite.Size = new System.Drawing.Size(786, 152);
            this.lstvWebSite.TabIndex = 6;
            this.lstvWebSite.UseCompatibleStateImageBehavior = false;
            this.lstvWebSite.View = System.Windows.Forms.View.Details;
            // 
            // colHwebSite
            // 
            this.colHwebSite.Text = "Web site path navigate";
            this.colHwebSite.Width = 445;
            // 
            // colHName
            // 
            this.colHName.Text = "Name";
            this.colHName.Width = 287;
            // 
            // btnNumberWebSitePath
            // 
            this.btnNumberWebSitePath.Location = new System.Drawing.Point(244, 480);
            this.btnNumberWebSitePath.Name = "btnNumberWebSitePath";
            this.btnNumberWebSitePath.Size = new System.Drawing.Size(216, 23);
            this.btnNumberWebSitePath.TabIndex = 7;
            this.btnNumberWebSitePath.Text = "calculate number Web site path navigate";
            this.btnNumberWebSitePath.UseVisualStyleBackColor = true;
            this.btnNumberWebSitePath.Click += new System.EventHandler(this.btnNumberWebSitePath_Click);
            // 
            // btnAverage
            // 
            this.btnAverage.Location = new System.Drawing.Point(244, 518);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(193, 23);
            this.btnAverage.TabIndex = 8;
            this.btnAverage.Text = "Calculate average of path converge";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // txtNumberURL
            // 
            this.txtNumberURL.Location = new System.Drawing.Point(483, 287);
            this.txtNumberURL.Name = "txtNumberURL";
            this.txtNumberURL.ReadOnly = true;
            this.txtNumberURL.Size = new System.Drawing.Size(117, 20);
            this.txtNumberURL.TabIndex = 9;
            // 
            // txtNumberWebSite
            // 
            this.txtNumberWebSite.Location = new System.Drawing.Point(466, 484);
            this.txtNumberWebSite.Name = "txtNumberWebSite";
            this.txtNumberWebSite.ReadOnly = true;
            this.txtNumberWebSite.Size = new System.Drawing.Size(100, 20);
            this.txtNumberWebSite.TabIndex = 10;
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(465, 521);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(100, 20);
            this.txtAverage.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(603, 18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(158, 24);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testCase1ToolStripMenuItem,
            this.testCase2ToolStripMenuItem,
            this.testCase3ToolStripMenuItem,
            this.testCas4ToolStripMenuItem,
            this.testCase5ToolStripMenuItem,
            this.testCase6ToolStripMenuItem,
            this.testCase7ToolStripMenuItem,
            this.testCase8ToolStripMenuItem,
            this.testCase9ToolStripMenuItem,
            this.testCase10ToolStripMenuItem,
            this.testCase11ToolStripMenuItem,
            this.testCase12ToolStripMenuItem,
            this.testCase13ToolStripMenuItem,
            this.testCase14ToolStripMenuItem,
            this.testCase15ToolStripMenuItem,
            this.testCase16ToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // testCase1ToolStripMenuItem
            // 
            this.testCase1ToolStripMenuItem.Name = "testCase1ToolStripMenuItem";
            this.testCase1ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.testCase1ToolStripMenuItem.Text = "Test HyperLinks";
            this.testCase1ToolStripMenuItem.Click += new System.EventHandler(this.testCase1ToolStripMenuItem_Click);
            // 
            // testCase2ToolStripMenuItem
            // 
            this.testCase2ToolStripMenuItem.Name = "testCase2ToolStripMenuItem";
            this.testCase2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase2ToolStripMenuItem.Text = "Test case2";
            this.testCase2ToolStripMenuItem.Click += new System.EventHandler(this.testCase2ToolStripMenuItem_Click);
            // 
            // testCase3ToolStripMenuItem
            // 
            this.testCase3ToolStripMenuItem.Name = "testCase3ToolStripMenuItem";
            this.testCase3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase3ToolStripMenuItem.Text = "Test case3";
            this.testCase3ToolStripMenuItem.Click += new System.EventHandler(this.testCase3ToolStripMenuItem_Click);
            // 
            // testCas4ToolStripMenuItem
            // 
            this.testCas4ToolStripMenuItem.Name = "testCas4ToolStripMenuItem";
            this.testCas4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCas4ToolStripMenuItem.Text = "Test case4";
            this.testCas4ToolStripMenuItem.Click += new System.EventHandler(this.testCas4ToolStripMenuItem_Click);
            // 
            // testCase5ToolStripMenuItem
            // 
            this.testCase5ToolStripMenuItem.Name = "testCase5ToolStripMenuItem";
            this.testCase5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase5ToolStripMenuItem.Text = "Test case5";
            this.testCase5ToolStripMenuItem.Click += new System.EventHandler(this.testCase5ToolStripMenuItem_Click);
            // 
            // testCase6ToolStripMenuItem
            // 
            this.testCase6ToolStripMenuItem.Name = "testCase6ToolStripMenuItem";
            this.testCase6ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase6ToolStripMenuItem.Text = "Test case6";
            this.testCase6ToolStripMenuItem.Click += new System.EventHandler(this.testCase6ToolStripMenuItem_Click);
            // 
            // testCase7ToolStripMenuItem
            // 
            this.testCase7ToolStripMenuItem.Name = "testCase7ToolStripMenuItem";
            this.testCase7ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase7ToolStripMenuItem.Text = "Test case7";
            this.testCase7ToolStripMenuItem.Click += new System.EventHandler(this.testCase7ToolStripMenuItem_Click);
            // 
            // testCase8ToolStripMenuItem
            // 
            this.testCase8ToolStripMenuItem.Name = "testCase8ToolStripMenuItem";
            this.testCase8ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase8ToolStripMenuItem.Text = "Test case8";
            this.testCase8ToolStripMenuItem.Click += new System.EventHandler(this.testCase8ToolStripMenuItem_Click);
            // 
            // testCase9ToolStripMenuItem
            // 
            this.testCase9ToolStripMenuItem.Name = "testCase9ToolStripMenuItem";
            this.testCase9ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase9ToolStripMenuItem.Text = "Test case9";
            this.testCase9ToolStripMenuItem.Click += new System.EventHandler(this.testCase9ToolStripMenuItem_Click);
            // 
            // testCase10ToolStripMenuItem
            // 
            this.testCase10ToolStripMenuItem.Name = "testCase10ToolStripMenuItem";
            this.testCase10ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase10ToolStripMenuItem.Text = "Test case10";
            this.testCase10ToolStripMenuItem.Click += new System.EventHandler(this.testCase10ToolStripMenuItem_Click);
            // 
            // testCase11ToolStripMenuItem
            // 
            this.testCase11ToolStripMenuItem.Name = "testCase11ToolStripMenuItem";
            this.testCase11ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase11ToolStripMenuItem.Text = "Test case11";
            this.testCase11ToolStripMenuItem.Click += new System.EventHandler(this.testCase11ToolStripMenuItem_Click);
            // 
            // testCase12ToolStripMenuItem
            // 
            this.testCase12ToolStripMenuItem.Name = "testCase12ToolStripMenuItem";
            this.testCase12ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase12ToolStripMenuItem.Text = "Test case12";
            this.testCase12ToolStripMenuItem.Click += new System.EventHandler(this.testCase12ToolStripMenuItem_Click);
            // 
            // testCase13ToolStripMenuItem
            // 
            this.testCase13ToolStripMenuItem.Name = "testCase13ToolStripMenuItem";
            this.testCase13ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase13ToolStripMenuItem.Text = "Test case13";
            this.testCase13ToolStripMenuItem.Click += new System.EventHandler(this.testCase13ToolStripMenuItem_Click);
            // 
            // testCase14ToolStripMenuItem
            // 
            this.testCase14ToolStripMenuItem.Name = "testCase14ToolStripMenuItem";
            this.testCase14ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase14ToolStripMenuItem.Text = "Test case14";
            this.testCase14ToolStripMenuItem.Click += new System.EventHandler(this.testCase14ToolStripMenuItem_Click);
            // 
            // testCase15ToolStripMenuItem
            // 
            this.testCase15ToolStripMenuItem.Name = "testCase15ToolStripMenuItem";
            this.testCase15ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase15ToolStripMenuItem.Text = "Test case15";
            this.testCase15ToolStripMenuItem.Click += new System.EventHandler(this.testCase15ToolStripMenuItem_Click);
            // 
            // testCase16ToolStripMenuItem
            // 
            this.testCase16ToolStripMenuItem.Name = "testCase16ToolStripMenuItem";
            this.testCase16ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testCase16ToolStripMenuItem.Text = "Test case16";
            this.testCase16ToolStripMenuItem.Click += new System.EventHandler(this.testCase16ToolStripMenuItem_Click);
            // 
            // WebTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 568);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.txtNumberWebSite);
            this.Controls.Add(this.txtNumberURL);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.btnNumberWebSitePath);
            this.Controls.Add(this.lstvWebSite);
            this.Controls.Add(this.btnNumberofURL);
            this.Controls.Add(this.btnNewPath);
            this.Controls.Add(this.lstvURL);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnURL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WebTester";
            this.Text = "Web Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebTester_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ListView lstvURL;
        private System.Windows.Forms.ColumnHeader colURL;
        private System.Windows.Forms.ColumnHeader colText;
        private System.Windows.Forms.Button btnNewPath;
        private System.Windows.Forms.Button btnNumberofURL;
        public System.Windows.Forms.ListView lstvWebSite;
        private System.Windows.Forms.Button btnNumberWebSitePath;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.TextBox txtNumberURL;
        private System.Windows.Forms.TextBox txtNumberWebSite;
        private System.Windows.Forms.ColumnHeader colHwebSite;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.ColumnHeader colHName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCas4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase13ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase14ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCase16ToolStripMenuItem;
    }
}

