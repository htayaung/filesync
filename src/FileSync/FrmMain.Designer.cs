namespace FileSync
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainPanel = new TableLayoutPanel();
            tvFileSystem = new TreeView();
            pnlSource = new Panel();
            btnBrowseSourceFolder = new Button();
            btnSearch = new Button();
            lblFileExtensionExample = new Label();
            lblFileExtensionOptional = new Label();
            txtFileExtension = new TextBox();
            lblFileExtension = new Label();
            pnlModifiedDateTime = new FlowLayoutPanel();
            dtpModifiedDate = new DateTimePicker();
            dtpModifiedTime = new DateTimePicker();
            lblModifiedDate = new Label();
            txtSourceFolder = new TextBox();
            lblSourceFolder = new Label();
            pnlDestination = new Panel();
            btnBrowseDestinationFolder = new Button();
            btnCopy = new Button();
            txtDestinationFolder = new TextBox();
            lblDestinationFolder = new Label();
            pnlProgressStatus = new Panel();
            btnCancelProcess = new Button();
            progressBar = new ProgressBar();
            lblProgressStatus = new Label();
            toolTip = new ToolTip(components);
            mainPanel.SuspendLayout();
            pnlSource.SuspendLayout();
            pnlModifiedDateTime.SuspendLayout();
            pnlDestination.SuspendLayout();
            pnlProgressStatus.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainPanel.Controls.Add(tvFileSystem, 0, 2);
            mainPanel.Controls.Add(pnlSource, 0, 0);
            mainPanel.Controls.Add(pnlDestination, 0, 1);
            mainPanel.Controls.Add(pnlProgressStatus, 0, 3);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(5);
            mainPanel.RowCount = 4;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            mainPanel.Size = new Size(1006, 721);
            mainPanel.TabIndex = 0;
            // 
            // tvFileSystem
            // 
            tvFileSystem.CheckBoxes = true;
            tvFileSystem.Dock = DockStyle.Fill;
            tvFileSystem.Location = new Point(8, 268);
            tvFileSystem.Name = "tvFileSystem";
            tvFileSystem.Size = new Size(990, 415);
            tvFileSystem.TabIndex = 1;
            tvFileSystem.AfterCheck += tvFileSystem_AfterCheck;
            // 
            // pnlSource
            // 
            pnlSource.Controls.Add(btnBrowseSourceFolder);
            pnlSource.Controls.Add(btnSearch);
            pnlSource.Controls.Add(lblFileExtensionExample);
            pnlSource.Controls.Add(lblFileExtensionOptional);
            pnlSource.Controls.Add(txtFileExtension);
            pnlSource.Controls.Add(lblFileExtension);
            pnlSource.Controls.Add(pnlModifiedDateTime);
            pnlSource.Controls.Add(lblModifiedDate);
            pnlSource.Controls.Add(txtSourceFolder);
            pnlSource.Controls.Add(lblSourceFolder);
            pnlSource.Dock = DockStyle.Fill;
            pnlSource.Location = new Point(8, 8);
            pnlSource.Name = "pnlSource";
            pnlSource.Size = new Size(990, 164);
            pnlSource.TabIndex = 2;
            // 
            // btnBrowseSourceFolder
            // 
            btnBrowseSourceFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseSourceFolder.FlatAppearance.BorderSize = 0;
            btnBrowseSourceFolder.FlatStyle = FlatStyle.Flat;
            btnBrowseSourceFolder.Image = Properties.Resources.open_folder;
            btnBrowseSourceFolder.Location = new Point(807, 5);
            btnBrowseSourceFolder.Name = "btnBrowseSourceFolder";
            btnBrowseSourceFolder.Size = new Size(32, 32);
            btnBrowseSourceFolder.TabIndex = 9;
            toolTip.SetToolTip(btnBrowseSourceFolder, "Browse source folder");
            btnBrowseSourceFolder.UseVisualStyleBackColor = true;
            btnBrowseSourceFolder.Click += btnBrowseSourceFolder_Click;
            // 
            // btnSearch
            // 
            btnSearch.Enabled = false;
            btnSearch.Location = new Point(187, 121);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 35);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            toolTip.SetToolTip(btnSearch, "Search files from a specified source folder");
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblFileExtensionExample
            // 
            lblFileExtensionExample.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFileExtensionExample.AutoSize = true;
            lblFileExtensionExample.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFileExtensionExample.ForeColor = SystemColors.WindowText;
            lblFileExtensionExample.Location = new Point(804, 91);
            lblFileExtensionExample.Name = "lblFileExtensionExample";
            lblFileExtensionExample.Size = new Size(109, 20);
            lblFileExtensionExample.TabIndex = 7;
            lblFileExtensionExample.Text = "e.g. html, css, js";
            // 
            // lblFileExtensionOptional
            // 
            lblFileExtensionOptional.AutoSize = true;
            lblFileExtensionOptional.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFileExtensionOptional.Location = new Point(109, 91);
            lblFileExtensionOptional.Name = "lblFileExtensionOptional";
            lblFileExtensionOptional.Size = new Size(70, 19);
            lblFileExtensionOptional.TabIndex = 6;
            lblFileExtensionOptional.Text = "(optional)";
            // 
            // txtFileExtension
            // 
            txtFileExtension.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFileExtension.Location = new Point(187, 87);
            txtFileExtension.Name = "txtFileExtension";
            txtFileExtension.Size = new Size(614, 27);
            txtFileExtension.TabIndex = 5;
            toolTip.SetToolTip(txtFileExtension, "File extensions");
            // 
            // lblFileExtension
            // 
            lblFileExtension.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFileExtension.Location = new Point(3, 85);
            lblFileExtension.Name = "lblFileExtension";
            lblFileExtension.Size = new Size(180, 30);
            lblFileExtension.TabIndex = 4;
            lblFileExtension.Text = "File Extensions";
            lblFileExtension.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlModifiedDateTime
            // 
            pnlModifiedDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlModifiedDateTime.Controls.Add(dtpModifiedDate);
            pnlModifiedDateTime.Controls.Add(dtpModifiedTime);
            pnlModifiedDateTime.Location = new Point(187, 43);
            pnlModifiedDateTime.Name = "pnlModifiedDateTime";
            pnlModifiedDateTime.Size = new Size(614, 34);
            pnlModifiedDateTime.TabIndex = 3;
            // 
            // dtpModifiedDate
            // 
            dtpModifiedDate.Format = DateTimePickerFormat.Short;
            dtpModifiedDate.Location = new Point(3, 3);
            dtpModifiedDate.Name = "dtpModifiedDate";
            dtpModifiedDate.Size = new Size(268, 27);
            dtpModifiedDate.TabIndex = 0;
            // 
            // dtpModifiedTime
            // 
            dtpModifiedTime.Format = DateTimePickerFormat.Time;
            dtpModifiedTime.Location = new Point(277, 3);
            dtpModifiedTime.Name = "dtpModifiedTime";
            dtpModifiedTime.ShowUpDown = true;
            dtpModifiedTime.Size = new Size(110, 27);
            dtpModifiedTime.TabIndex = 1;
            // 
            // lblModifiedDate
            // 
            lblModifiedDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModifiedDate.Location = new Point(3, 45);
            lblModifiedDate.Name = "lblModifiedDate";
            lblModifiedDate.Size = new Size(180, 30);
            lblModifiedDate.TabIndex = 2;
            lblModifiedDate.Text = "Modified Date";
            lblModifiedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSourceFolder
            // 
            txtSourceFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSourceFolder.Location = new Point(187, 8);
            txtSourceFolder.Name = "txtSourceFolder";
            txtSourceFolder.Size = new Size(614, 27);
            txtSourceFolder.TabIndex = 1;
            toolTip.SetToolTip(txtSourceFolder, "Source folder path");
            txtSourceFolder.TextChanged += txtSourceFolder_TextChanged;
            // 
            // lblSourceFolder
            // 
            lblSourceFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSourceFolder.Location = new Point(3, 6);
            lblSourceFolder.Name = "lblSourceFolder";
            lblSourceFolder.Size = new Size(180, 30);
            lblSourceFolder.TabIndex = 0;
            lblSourceFolder.Text = "Source Folder";
            lblSourceFolder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDestination
            // 
            pnlDestination.Controls.Add(btnBrowseDestinationFolder);
            pnlDestination.Controls.Add(btnCopy);
            pnlDestination.Controls.Add(txtDestinationFolder);
            pnlDestination.Controls.Add(lblDestinationFolder);
            pnlDestination.Dock = DockStyle.Fill;
            pnlDestination.Location = new Point(8, 178);
            pnlDestination.Name = "pnlDestination";
            pnlDestination.Size = new Size(990, 84);
            pnlDestination.TabIndex = 3;
            // 
            // btnBrowseDestinationFolder
            // 
            btnBrowseDestinationFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseDestinationFolder.FlatAppearance.BorderSize = 0;
            btnBrowseDestinationFolder.FlatStyle = FlatStyle.Flat;
            btnBrowseDestinationFolder.Image = Properties.Resources.open_folder;
            btnBrowseDestinationFolder.Location = new Point(807, 4);
            btnBrowseDestinationFolder.Name = "btnBrowseDestinationFolder";
            btnBrowseDestinationFolder.Size = new Size(32, 32);
            btnBrowseDestinationFolder.TabIndex = 10;
            toolTip.SetToolTip(btnBrowseDestinationFolder, "Browse destination folder");
            btnBrowseDestinationFolder.UseVisualStyleBackColor = true;
            btnBrowseDestinationFolder.Click += btnBrowseDestinationFolder_Click;
            // 
            // btnCopy
            // 
            btnCopy.Enabled = false;
            btnCopy.Location = new Point(187, 40);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(150, 35);
            btnCopy.TabIndex = 9;
            btnCopy.Text = "Copy";
            toolTip.SetToolTip(btnCopy, "Copy files and folders to destination folder");
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtDestinationFolder
            // 
            txtDestinationFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDestinationFolder.Location = new Point(187, 7);
            txtDestinationFolder.Name = "txtDestinationFolder";
            txtDestinationFolder.Size = new Size(614, 27);
            txtDestinationFolder.TabIndex = 3;
            toolTip.SetToolTip(txtDestinationFolder, "Destination folder");
            txtDestinationFolder.TextChanged += txtDestinationFolder_TextChanged;
            // 
            // lblDestinationFolder
            // 
            lblDestinationFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDestinationFolder.Location = new Point(3, 5);
            lblDestinationFolder.Name = "lblDestinationFolder";
            lblDestinationFolder.Size = new Size(180, 30);
            lblDestinationFolder.TabIndex = 2;
            lblDestinationFolder.Text = "Destination Folder";
            lblDestinationFolder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlProgressStatus
            // 
            pnlProgressStatus.Controls.Add(btnCancelProcess);
            pnlProgressStatus.Controls.Add(progressBar);
            pnlProgressStatus.Controls.Add(lblProgressStatus);
            pnlProgressStatus.Dock = DockStyle.Fill;
            pnlProgressStatus.Location = new Point(8, 689);
            pnlProgressStatus.Name = "pnlProgressStatus";
            pnlProgressStatus.Size = new Size(990, 24);
            pnlProgressStatus.TabIndex = 4;
            // 
            // btnCancelProcess
            // 
            btnCancelProcess.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelProcess.FlatAppearance.BorderSize = 0;
            btnCancelProcess.FlatStyle = FlatStyle.Flat;
            btnCancelProcess.Image = Properties.Resources.cancel_icon;
            btnCancelProcess.Location = new Point(963, 2);
            btnCancelProcess.Name = "btnCancelProcess";
            btnCancelProcess.Size = new Size(20, 20);
            btnCancelProcess.TabIndex = 2;
            toolTip.SetToolTip(btnCancelProcess, "Cancel current process");
            btnCancelProcess.UseVisualStyleBackColor = true;
            btnCancelProcess.Visible = false;
            btnCancelProcess.Click += btnCancelProcess_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(56, 7);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(908, 10);
            progressBar.Step = 20;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 1;
            toolTip.SetToolTip(progressBar, "Progress bar");
            progressBar.Visible = false;
            // 
            // lblProgressStatus
            // 
            lblProgressStatus.AutoSize = true;
            lblProgressStatus.Location = new Point(0, 2);
            lblProgressStatus.Name = "lblProgressStatus";
            lblProgressStatus.Size = new Size(49, 20);
            lblProgressStatus.TabIndex = 0;
            lblProgressStatus.Text = "Status";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(mainPanel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(800, 600);
            Name = "FrmMain";
            Text = "FileSync";
            mainPanel.ResumeLayout(false);
            pnlSource.ResumeLayout(false);
            pnlSource.PerformLayout();
            pnlModifiedDateTime.ResumeLayout(false);
            pnlDestination.ResumeLayout(false);
            pnlDestination.PerformLayout();
            pnlProgressStatus.ResumeLayout(false);
            pnlProgressStatus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainPanel;
        private TreeView tvFileSystem;
        private Panel pnlSource;
        private Label lblSourceFolder;
        private TextBox txtSourceFolder;
        private Label lblModifiedDate;
        private FlowLayoutPanel pnlModifiedDateTime;
        private DateTimePicker dtpModifiedDate;
        private DateTimePicker dtpModifiedTime;
        private Label lblFileExtension;
        private TextBox txtFileExtension;
        private Label lblFileExtensionOptional;
        private Label lblFileExtensionExample;
        private Button btnSearch;
        private Panel pnlDestination;
        private TextBox txtDestinationFolder;
        private Label lblDestinationFolder;
        private Button btnCopy;
        private Panel pnlProgressStatus;
        private Label lblProgressStatus;
        private ProgressBar progressBar;
        private Button btnBrowseSourceFolder;
        private Button btnBrowseDestinationFolder;
        private Button btnCancelProcess;
        private ToolTip toolTip;
    }
}
