namespace WebTester
{
    partial class Form1
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
            this.btnReadFromUrl = new System.Windows.Forms.Button();
            this.numMaxDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lvUrls = new System.Windows.Forms.ListView();
            this.chURL = new System.Windows.Forms.ColumnHeader();
            this.chText = new System.Windows.Forms.ColumnHeader();
            this.tbDebugOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadFromUrl
            // 
            this.btnReadFromUrl.Location = new System.Drawing.Point(12, 12);
            this.btnReadFromUrl.Name = "btnReadFromUrl";
            this.btnReadFromUrl.Size = new System.Drawing.Size(188, 23);
            this.btnReadFromUrl.TabIndex = 0;
            this.btnReadFromUrl.Text = "Read Hyperlinks from URL";
            this.btnReadFromUrl.UseVisualStyleBackColor = true;
            this.btnReadFromUrl.Click += new System.EventHandler(this.btnReadFromUrl_Click);
            // 
            // numMaxDepth
            // 
            this.numMaxDepth.Location = new System.Drawing.Point(298, 12);
            this.numMaxDepth.Name = "numMaxDepth";
            this.numMaxDepth.Size = new System.Drawing.Size(120, 20);
            this.numMaxDepth.TabIndex = 1;
            this.numMaxDepth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum Depth:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "URL:";
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.Location = new System.Drawing.Point(462, 11);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(270, 20);
            this.tbUrl.TabIndex = 4;
            this.tbUrl.Text = "http://www.";
            // 
            // lvUrls
            // 
            this.lvUrls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUrls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chURL,
            this.chText});
            this.lvUrls.FullRowSelect = true;
            this.lvUrls.HideSelection = false;
            this.lvUrls.Location = new System.Drawing.Point(12, 41);
            this.lvUrls.MultiSelect = false;
            this.lvUrls.Name = "lvUrls";
            this.lvUrls.Size = new System.Drawing.Size(720, 156);
            this.lvUrls.TabIndex = 5;
            this.lvUrls.UseCompatibleStateImageBehavior = false;
            this.lvUrls.View = System.Windows.Forms.View.Details;
            // 
            // chURL
            // 
            this.chURL.Text = "URL";
            this.chURL.Width = 383;
            // 
            // chText
            // 
            this.chText.Text = "Text";
            this.chText.Width = 242;
            // 
            // tbDebugOutput
            // 
            this.tbDebugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDebugOutput.Location = new System.Drawing.Point(13, 204);
            this.tbDebugOutput.Multiline = true;
            this.tbDebugOutput.Name = "tbDebugOutput";
            this.tbDebugOutput.ReadOnly = true;
            this.tbDebugOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDebugOutput.Size = new System.Drawing.Size(719, 159);
            this.tbDebugOutput.TabIndex = 6;
            this.tbDebugOutput.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 375);
            this.Controls.Add(this.tbDebugOutput);
            this.Controls.Add(this.lvUrls);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMaxDepth);
            this.Controls.Add(this.btnReadFromUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadFromUrl;
        private System.Windows.Forms.NumericUpDown numMaxDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ListView lvUrls;
        private System.Windows.Forms.ColumnHeader chURL;
        private System.Windows.Forms.ColumnHeader chText;
        private System.Windows.Forms.TextBox tbDebugOutput;
    }
}

