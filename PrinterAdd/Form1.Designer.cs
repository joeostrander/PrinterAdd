namespace PrinterAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listViewSearchResults = new System.Windows.Forms.ListView();
            this.columnHeaderPrinterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDriverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUncName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripSearchResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonPrinterName = new System.Windows.Forms.RadioButton();
            this.radioButtonPrinterLocation = new System.Windows.Forms.RadioButton();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewInstalledPrinters = new System.Windows.Forms.ListView();
            this.columnHeaderInstalledPrinter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInstalledLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInstalledDriverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInstalledUnc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripInstalledPrinters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripSearchResults.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStripInstalledPrinters.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(118, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // listViewSearchResults
            // 
            this.listViewSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPrinterName,
            this.columnHeaderLocation,
            this.columnHeaderDriverName,
            this.columnHeaderUncName});
            this.listViewSearchResults.ContextMenuStrip = this.contextMenuStripSearchResults;
            this.listViewSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearchResults.FullRowSelect = true;
            this.listViewSearchResults.GridLines = true;
            this.listViewSearchResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSearchResults.Location = new System.Drawing.Point(3, 16);
            this.listViewSearchResults.Name = "listViewSearchResults";
            this.listViewSearchResults.Size = new System.Drawing.Size(704, 180);
            this.listViewSearchResults.TabIndex = 2;
            this.listViewSearchResults.UseCompatibleStateImageBehavior = false;
            this.listViewSearchResults.View = System.Windows.Forms.View.Details;
            this.listViewSearchResults.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listViewSearchResults.DoubleClick += new System.EventHandler(this.listViewSearchResults_DoubleClick);
            // 
            // columnHeaderPrinterName
            // 
            this.columnHeaderPrinterName.Text = "Printer";
            this.columnHeaderPrinterName.Width = 120;
            // 
            // columnHeaderLocation
            // 
            this.columnHeaderLocation.Text = "Location";
            this.columnHeaderLocation.Width = 180;
            // 
            // columnHeaderDriverName
            // 
            this.columnHeaderDriverName.Text = "Driver Name";
            this.columnHeaderDriverName.Width = 200;
            // 
            // columnHeaderUncName
            // 
            this.columnHeaderUncName.Text = "UNC";
            this.columnHeaderUncName.Width = 200;
            // 
            // contextMenuStripSearchResults
            // 
            this.contextMenuStripSearchResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSelectedToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.contextMenuStripSearchResults.Name = "contextMenuStrip1";
            this.contextMenuStripSearchResults.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripSearchResults.ShowImageMargin = false;
            this.contextMenuStripSearchResults.Size = new System.Drawing.Size(119, 48);
            // 
            // addSelectedToolStripMenuItem
            // 
            this.addSelectedToolStripMenuItem.Name = "addSelectedToolStripMenuItem";
            this.addSelectedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.addSelectedToolStripMenuItem.Text = "&Add Selected";
            this.addSelectedToolStripMenuItem.Click += new System.EventHandler(this.addSelectedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "A&bout";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // radioButtonPrinterName
            // 
            this.radioButtonPrinterName.AutoSize = true;
            this.radioButtonPrinterName.Checked = true;
            this.radioButtonPrinterName.Location = new System.Drawing.Point(209, 13);
            this.radioButtonPrinterName.Name = "radioButtonPrinterName";
            this.radioButtonPrinterName.Size = new System.Drawing.Size(53, 17);
            this.radioButtonPrinterName.TabIndex = 3;
            this.radioButtonPrinterName.TabStop = true;
            this.radioButtonPrinterName.Text = "&Name";
            this.radioButtonPrinterName.UseVisualStyleBackColor = true;
            // 
            // radioButtonPrinterLocation
            // 
            this.radioButtonPrinterLocation.AutoSize = true;
            this.radioButtonPrinterLocation.Location = new System.Drawing.Point(268, 13);
            this.radioButtonPrinterLocation.Name = "radioButtonPrinterLocation";
            this.radioButtonPrinterLocation.Size = new System.Drawing.Size(66, 17);
            this.radioButtonPrinterLocation.TabIndex = 4;
            this.radioButtonPrinterLocation.Text = "&Location";
            this.radioButtonPrinterLocation.UseVisualStyleBackColor = true;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Location = new System.Drawing.Point(3, 16);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStatus.Size = new System.Drawing.Size(704, 81);
            this.textBoxStatus.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewSearchResults);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 199);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Results:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listViewInstalledPrinters);
            this.groupBox3.Location = new System.Drawing.Point(12, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(710, 135);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Installed:";
            // 
            // listViewInstalledPrinters
            // 
            this.listViewInstalledPrinters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderInstalledPrinter,
            this.columnHeaderInstalledLocation,
            this.columnHeaderInstalledDriverName,
            this.columnHeaderInstalledUnc});
            this.listViewInstalledPrinters.ContextMenuStrip = this.contextMenuStripInstalledPrinters;
            this.listViewInstalledPrinters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInstalledPrinters.FullRowSelect = true;
            this.listViewInstalledPrinters.GridLines = true;
            this.listViewInstalledPrinters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewInstalledPrinters.Location = new System.Drawing.Point(3, 16);
            this.listViewInstalledPrinters.Name = "listViewInstalledPrinters";
            this.listViewInstalledPrinters.Size = new System.Drawing.Size(704, 116);
            this.listViewInstalledPrinters.TabIndex = 2;
            this.listViewInstalledPrinters.UseCompatibleStateImageBehavior = false;
            this.listViewInstalledPrinters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderInstalledPrinter
            // 
            this.columnHeaderInstalledPrinter.Text = "Printer";
            this.columnHeaderInstalledPrinter.Width = 120;
            // 
            // columnHeaderInstalledLocation
            // 
            this.columnHeaderInstalledLocation.Text = "Location";
            this.columnHeaderInstalledLocation.Width = 180;
            // 
            // columnHeaderInstalledDriverName
            // 
            this.columnHeaderInstalledDriverName.Text = "Driver Name";
            this.columnHeaderInstalledDriverName.Width = 200;
            // 
            // columnHeaderInstalledUnc
            // 
            this.columnHeaderInstalledUnc.Text = "UNC";
            this.columnHeaderInstalledUnc.Width = 200;
            // 
            // contextMenuStripInstalledPrinters
            // 
            this.contextMenuStripInstalledPrinters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStripInstalledPrinters.Name = "contextMenuStrip1";
            this.contextMenuStripInstalledPrinters.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripInstalledPrinters.ShowImageMargin = false;
            this.contextMenuStripInstalledPrinters.Size = new System.Drawing.Size(143, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem1.Text = "&Uninstall Selected";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem2.Text = "A&bout";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 497);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonPrinterLocation);
            this.Controls.Add(this.radioButtonPrinterName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 536);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripSearchResults.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStripInstalledPrinters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listViewSearchResults;
        private System.Windows.Forms.ColumnHeader columnHeaderPrinterName;
        private System.Windows.Forms.ColumnHeader columnHeaderLocation;
        private System.Windows.Forms.ColumnHeader columnHeaderUncName;
        private System.Windows.Forms.RadioButton radioButtonPrinterName;
        private System.Windows.Forms.RadioButton radioButtonPrinterLocation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSearchResults;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.ToolStripMenuItem addSelectedToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeaderDriverName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listViewInstalledPrinters;
        private System.Windows.Forms.ColumnHeader columnHeaderInstalledPrinter;
        private System.Windows.Forms.ColumnHeader columnHeaderInstalledLocation;
        private System.Windows.Forms.ColumnHeader columnHeaderInstalledDriverName;
        private System.Windows.Forms.ColumnHeader columnHeaderInstalledUnc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInstalledPrinters;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

