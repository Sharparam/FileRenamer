namespace FileRenamer
{
	partial class FileRenamerForm
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
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.folderBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.browseButton = new System.Windows.Forms.Button();
			this.fileListLabel = new System.Windows.Forms.Label();
			this.fileList = new System.Windows.Forms.ListBox();
			this.removeButton = new System.Windows.Forms.Button();
			this.startBox = new System.Windows.Forms.GroupBox();
			this.notUseStartReplace = new System.Windows.Forms.CheckBox();
			this.startReplaceText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.startText = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.endBox = new System.Windows.Forms.GroupBox();
			this.notUseEndReplace = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.endReplaceText = new System.Windows.Forms.TextBox();
			this.endText = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.additionalBox = new System.Windows.Forms.GroupBox();
			this.removeString = new System.Windows.Forms.Button();
			this.addString = new System.Windows.Forms.Button();
			this.replaceText = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.origText = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.replaceBox = new System.Windows.Forms.ListBox();
			this.origBox = new System.Windows.Forms.ListBox();
			this.useAddOptions = new System.Windows.Forms.CheckBox();
			this.startReplace = new System.Windows.Forms.Button();
			this.logWindow = new System.Windows.Forms.TextBox();
			this.refreshButton = new System.Windows.Forms.Button();
			this.clearIgnoreButton = new System.Windows.Forms.Button();
			this.advOptions = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.useAdvEnd = new System.Windows.Forms.RadioButton();
			this.useAdvStart = new System.Windows.Forms.RadioButton();
			this.sepChar = new System.Windows.Forms.ComboBox();
			this.sepUseCustom = new System.Windows.Forms.CheckBox();
			this.sepCustom = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.useNumbers = new System.Windows.Forms.CheckBox();
			this.useSrndChar = new System.Windows.Forms.CheckBox();
			this.srndChar = new System.Windows.Forms.ComboBox();
			this.startBox.SuspendLayout();
			this.endBox.SuspendLayout();
			this.additionalBox.SuspendLayout();
			this.advOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// folderDialog
			// 
			this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.folderDialog.ShowNewFolderButton = false;
			// 
			// folderBox
			// 
			this.folderBox.Enabled = false;
			this.folderBox.Location = new System.Drawing.Point(111, 6);
			this.folderBox.Name = "folderBox";
			this.folderBox.Size = new System.Drawing.Size(384, 20);
			this.folderBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Folder with files in:";
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(501, 4);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(75, 23);
			this.browseButton.TabIndex = 2;
			this.browseButton.Text = "Browse...";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.BrowseButtonClick);
			// 
			// fileListLabel
			// 
			this.fileListLabel.AutoSize = true;
			this.fileListLabel.Location = new System.Drawing.Point(12, 38);
			this.fileListLabel.Name = "fileListLabel";
			this.fileListLabel.Size = new System.Drawing.Size(115, 13);
			this.fileListLabel.TabIndex = 3;
			this.fileListLabel.Text = "Found files (0 Ignored):";
			// 
			// fileList
			// 
			this.fileList.FormattingEnabled = true;
			this.fileList.HorizontalScrollbar = true;
			this.fileList.Location = new System.Drawing.Point(15, 55);
			this.fileList.Name = "fileList";
			this.fileList.Size = new System.Drawing.Size(561, 186);
			this.fileList.TabIndex = 6;
			// 
			// removeButton
			// 
			this.removeButton.Location = new System.Drawing.Point(15, 247);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(130, 23);
			this.removeButton.TabIndex = 7;
			this.removeButton.Text = "Remove Selected File";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.RemoveButtonClick);
			// 
			// startBox
			// 
			this.startBox.Controls.Add(this.notUseStartReplace);
			this.startBox.Controls.Add(this.startReplaceText);
			this.startBox.Controls.Add(this.label4);
			this.startBox.Controls.Add(this.startText);
			this.startBox.Controls.Add(this.label3);
			this.startBox.Location = new System.Drawing.Point(15, 277);
			this.startBox.Name = "startBox";
			this.startBox.Size = new System.Drawing.Size(278, 100);
			this.startBox.TabIndex = 8;
			this.startBox.TabStop = false;
			this.startBox.Text = "At the beginning of the file name...";
			// 
			// notUseStartReplace
			// 
			this.notUseStartReplace.AutoSize = true;
			this.notUseStartReplace.Location = new System.Drawing.Point(10, 71);
			this.notUseStartReplace.Name = "notUseStartReplace";
			this.notUseStartReplace.Size = new System.Drawing.Size(135, 17);
			this.notUseStartReplace.TabIndex = 4;
			this.notUseStartReplace.Text = "Do not use this replace";
			this.notUseStartReplace.UseVisualStyleBackColor = true;
			// 
			// startReplaceText
			// 
			this.startReplaceText.Location = new System.Drawing.Point(63, 44);
			this.startReplaceText.Name = "startReplaceText";
			this.startReplaceText.Size = new System.Drawing.Size(209, 20);
			this.startReplaceText.TabIndex = 3;
			this.startReplaceText.TextChanged += new System.EventHandler(this.TextCheck);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "With:";
			// 
			// startText
			// 
			this.startText.Location = new System.Drawing.Point(63, 17);
			this.startText.Name = "startText";
			this.startText.Size = new System.Drawing.Size(209, 20);
			this.startText.TabIndex = 1;
			this.startText.TextChanged += new System.EventHandler(this.TextCheck);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Replace:";
			// 
			// endBox
			// 
			this.endBox.Controls.Add(this.notUseEndReplace);
			this.endBox.Controls.Add(this.label5);
			this.endBox.Controls.Add(this.endReplaceText);
			this.endBox.Controls.Add(this.endText);
			this.endBox.Controls.Add(this.label6);
			this.endBox.Location = new System.Drawing.Point(299, 277);
			this.endBox.Name = "endBox";
			this.endBox.Size = new System.Drawing.Size(278, 100);
			this.endBox.TabIndex = 9;
			this.endBox.TabStop = false;
			this.endBox.Text = "At the end of the file name...";
			// 
			// notUseEndReplace
			// 
			this.notUseEndReplace.AutoSize = true;
			this.notUseEndReplace.Location = new System.Drawing.Point(9, 71);
			this.notUseEndReplace.Name = "notUseEndReplace";
			this.notUseEndReplace.Size = new System.Drawing.Size(135, 17);
			this.notUseEndReplace.TabIndex = 4;
			this.notUseEndReplace.Text = "Do not use this replace";
			this.notUseEndReplace.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Replace:";
			// 
			// endReplaceText
			// 
			this.endReplaceText.Location = new System.Drawing.Point(62, 44);
			this.endReplaceText.Name = "endReplaceText";
			this.endReplaceText.Size = new System.Drawing.Size(209, 20);
			this.endReplaceText.TabIndex = 3;
			this.endReplaceText.TextChanged += new System.EventHandler(this.TextCheck);
			// 
			// endText
			// 
			this.endText.Location = new System.Drawing.Point(62, 17);
			this.endText.Name = "endText";
			this.endText.Size = new System.Drawing.Size(209, 20);
			this.endText.TabIndex = 1;
			this.endText.TextChanged += new System.EventHandler(this.TextCheck);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 43);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "With:";
			// 
			// additionalBox
			// 
			this.additionalBox.Controls.Add(this.removeString);
			this.additionalBox.Controls.Add(this.addString);
			this.additionalBox.Controls.Add(this.replaceText);
			this.additionalBox.Controls.Add(this.label9);
			this.additionalBox.Controls.Add(this.origText);
			this.additionalBox.Controls.Add(this.label8);
			this.additionalBox.Controls.Add(this.label7);
			this.additionalBox.Controls.Add(this.replaceBox);
			this.additionalBox.Controls.Add(this.origBox);
			this.additionalBox.Controls.Add(this.useAddOptions);
			this.additionalBox.Location = new System.Drawing.Point(15, 384);
			this.additionalBox.Name = "additionalBox";
			this.additionalBox.Size = new System.Drawing.Size(561, 139);
			this.additionalBox.TabIndex = 10;
			this.additionalBox.TabStop = false;
			this.additionalBox.Text = "Additional options...";
			// 
			// removeString
			// 
			this.removeString.Location = new System.Drawing.Point(353, 103);
			this.removeString.Name = "removeString";
			this.removeString.Size = new System.Drawing.Size(75, 23);
			this.removeString.TabIndex = 9;
			this.removeString.Text = "Remove";
			this.removeString.UseVisualStyleBackColor = true;
			this.removeString.Click += new System.EventHandler(this.RemoveStringClick);
			// 
			// addString
			// 
			this.addString.Location = new System.Drawing.Point(274, 103);
			this.addString.Name = "addString";
			this.addString.Size = new System.Drawing.Size(79, 23);
			this.addString.TabIndex = 8;
			this.addString.Text = "Add";
			this.addString.UseVisualStyleBackColor = true;
			this.addString.Click += new System.EventHandler(this.AddStringClick);
			// 
			// replaceText
			// 
			this.replaceText.Location = new System.Drawing.Point(274, 77);
			this.replaceText.Name = "replaceText";
			this.replaceText.Size = new System.Drawing.Size(154, 20);
			this.replaceText.TabIndex = 7;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(274, 60);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(161, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Replace above string with below";
			// 
			// origText
			// 
			this.origText.Location = new System.Drawing.Point(274, 33);
			this.origText.Name = "origText";
			this.origText.Size = new System.Drawing.Size(154, 20);
			this.origText.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(435, 14);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "With:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(147, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Replace:";
			// 
			// replaceBox
			// 
			this.replaceBox.FormattingEnabled = true;
			this.replaceBox.Location = new System.Drawing.Point(435, 33);
			this.replaceBox.Name = "replaceBox";
			this.replaceBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.replaceBox.Size = new System.Drawing.Size(120, 95);
			this.replaceBox.TabIndex = 2;
			// 
			// origBox
			// 
			this.origBox.FormattingEnabled = true;
			this.origBox.Location = new System.Drawing.Point(147, 33);
			this.origBox.Name = "origBox";
			this.origBox.Size = new System.Drawing.Size(120, 95);
			this.origBox.TabIndex = 1;
			// 
			// useAddOptions
			// 
			this.useAddOptions.AutoSize = true;
			this.useAddOptions.Location = new System.Drawing.Point(10, 20);
			this.useAddOptions.Name = "useAddOptions";
			this.useAddOptions.Size = new System.Drawing.Size(130, 17);
			this.useAddOptions.TabIndex = 0;
			this.useAddOptions.Text = "Use additional options";
			this.useAddOptions.UseVisualStyleBackColor = true;
			// 
			// startReplace
			// 
			this.startReplace.Location = new System.Drawing.Point(447, 247);
			this.startReplace.Name = "startReplace";
			this.startReplace.Size = new System.Drawing.Size(130, 23);
			this.startReplace.TabIndex = 11;
			this.startReplace.Text = "Start Replacing!";
			this.startReplace.UseVisualStyleBackColor = true;
			this.startReplace.Click += new System.EventHandler(this.StartReplaceClick);
			// 
			// logWindow
			// 
			this.logWindow.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.logWindow.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logWindow.Location = new System.Drawing.Point(583, 247);
			this.logWindow.Multiline = true;
			this.logWindow.Name = "logWindow";
			this.logWindow.ReadOnly = true;
			this.logWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logWindow.Size = new System.Drawing.Size(529, 276);
			this.logWindow.TabIndex = 12;
			this.logWindow.Text = "== MESSAGE LOG ==";
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(182, 247);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(111, 23);
			this.refreshButton.TabIndex = 13;
			this.refreshButton.Text = "Refresh File List";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
			// 
			// clearIgnoreButton
			// 
			this.clearIgnoreButton.Location = new System.Drawing.Point(299, 247);
			this.clearIgnoreButton.Name = "clearIgnoreButton";
			this.clearIgnoreButton.Size = new System.Drawing.Size(111, 23);
			this.clearIgnoreButton.TabIndex = 14;
			this.clearIgnoreButton.Text = "Clear Ignore List";
			this.clearIgnoreButton.UseVisualStyleBackColor = true;
			this.clearIgnoreButton.Click += new System.EventHandler(this.ClearIgnoreButtonClick);
			// 
			// advOptions
			// 
			this.advOptions.Controls.Add(this.srndChar);
			this.advOptions.Controls.Add(this.useSrndChar);
			this.advOptions.Controls.Add(this.useNumbers);
			this.advOptions.Controls.Add(this.label11);
			this.advOptions.Controls.Add(this.sepCustom);
			this.advOptions.Controls.Add(this.sepUseCustom);
			this.advOptions.Controls.Add(this.sepChar);
			this.advOptions.Controls.Add(this.label10);
			this.advOptions.Controls.Add(this.useAdvEnd);
			this.advOptions.Controls.Add(this.useAdvStart);
			this.advOptions.Location = new System.Drawing.Point(583, 4);
			this.advOptions.Name = "advOptions";
			this.advOptions.Size = new System.Drawing.Size(529, 237);
			this.advOptions.TabIndex = 15;
			this.advOptions.TabStop = false;
			this.advOptions.Text = "Advanced...";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(5, 47);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(165, 13);
			this.label10.TabIndex = 3;
			this.label10.Text = "Separate number from name with ";
			// 
			// useAdvEnd
			// 
			this.useAdvEnd.AutoSize = true;
			this.useAdvEnd.Checked = true;
			this.useAdvEnd.Location = new System.Drawing.Point(323, 14);
			this.useAdvEnd.Name = "useAdvEnd";
			this.useAdvEnd.Size = new System.Drawing.Size(97, 17);
			this.useAdvEnd.TabIndex = 1;
			this.useAdvEnd.TabStop = true;
			this.useAdvEnd.Text = "At end of name";
			this.useAdvEnd.UseVisualStyleBackColor = true;
			// 
			// useAdvStart
			// 
			this.useAdvStart.AutoSize = true;
			this.useAdvStart.Location = new System.Drawing.Point(191, 14);
			this.useAdvStart.Name = "useAdvStart";
			this.useAdvStart.Size = new System.Drawing.Size(125, 17);
			this.useAdvStart.TabIndex = 0;
			this.useAdvStart.Text = "At beginning of name";
			this.useAdvStart.UseVisualStyleBackColor = true;
			// 
			// sepChar
			// 
			this.sepChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sepChar.FormattingEnabled = true;
			this.sepChar.Items.AddRange(new object[] {
            "_",
            "-",
            "#",
            "(Space)",
            "(Nothing)"});
			this.sepChar.Location = new System.Drawing.Point(176, 44);
			this.sepChar.Name = "sepChar";
			this.sepChar.Size = new System.Drawing.Size(89, 21);
			this.sepChar.TabIndex = 4;
			// 
			// sepUseCustom
			// 
			this.sepUseCustom.AutoSize = true;
			this.sepUseCustom.Location = new System.Drawing.Point(286, 46);
			this.sepUseCustom.Name = "sepUseCustom";
			this.sepUseCustom.Size = new System.Drawing.Size(85, 17);
			this.sepUseCustom.TabIndex = 5;
			this.sepUseCustom.Text = "Use custom:";
			this.sepUseCustom.UseVisualStyleBackColor = true;
			// 
			// sepCustom
			// 
			this.sepCustom.Location = new System.Drawing.Point(377, 44);
			this.sepCustom.Name = "sepCustom";
			this.sepCustom.Size = new System.Drawing.Size(100, 20);
			this.sepCustom.TabIndex = 7;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(7, 218);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(175, 13);
			this.label11.TabIndex = 8;
			this.label11.Text = "Example of how the name will look: ";
			// 
			// useNumbers
			// 
			this.useNumbers.AutoSize = true;
			this.useNumbers.Location = new System.Drawing.Point(6, 15);
			this.useNumbers.Name = "useNumbers";
			this.useNumbers.Size = new System.Drawing.Size(179, 17);
			this.useNumbers.TabIndex = 9;
			this.useNumbers.Text = "Add a number after the file name";
			this.useNumbers.UseVisualStyleBackColor = true;
			// 
			// useSrndChar
			// 
			this.useSrndChar.AutoSize = true;
			this.useSrndChar.Location = new System.Drawing.Point(6, 72);
			this.useSrndChar.Name = "useSrndChar";
			this.useSrndChar.Size = new System.Drawing.Size(137, 17);
			this.useSrndChar.TabIndex = 10;
			this.useSrndChar.Text = "Sorround numbers with ";
			this.useSrndChar.UseVisualStyleBackColor = true;
			// 
			// srndChar
			// 
			this.srndChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.srndChar.FormattingEnabled = true;
			this.srndChar.Items.AddRange(new object[] {
            "( )",
            "[ ]",
            "{ }"});
			this.srndChar.Location = new System.Drawing.Point(176, 70);
			this.srndChar.Name = "srndChar";
			this.srndChar.Size = new System.Drawing.Size(89, 21);
			this.srndChar.TabIndex = 11;
			// 
			// FileRenamerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1124, 535);
			this.Controls.Add(this.advOptions);
			this.Controls.Add(this.clearIgnoreButton);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.logWindow);
			this.Controls.Add(this.startReplace);
			this.Controls.Add(this.additionalBox);
			this.Controls.Add(this.endBox);
			this.Controls.Add(this.startBox);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.fileList);
			this.Controls.Add(this.fileListLabel);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.folderBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "FileRenamerForm";
			this.Text = "Rename Files";
			this.Load += new System.EventHandler(this.FileRenamerFormLoad);
			this.startBox.ResumeLayout(false);
			this.startBox.PerformLayout();
			this.endBox.ResumeLayout(false);
			this.endBox.PerformLayout();
			this.additionalBox.ResumeLayout(false);
			this.additionalBox.PerformLayout();
			this.advOptions.ResumeLayout(false);
			this.advOptions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderDialog;
		private System.Windows.Forms.TextBox folderBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Label fileListLabel;
		private System.Windows.Forms.ListBox fileList;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.GroupBox startBox;
		private System.Windows.Forms.CheckBox notUseStartReplace;
		private System.Windows.Forms.TextBox startReplaceText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox startText;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox endBox;
		private System.Windows.Forms.CheckBox notUseEndReplace;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox endReplaceText;
		private System.Windows.Forms.TextBox endText;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox additionalBox;
		private System.Windows.Forms.CheckBox useAddOptions;
		private System.Windows.Forms.Button removeString;
		private System.Windows.Forms.Button addString;
		private System.Windows.Forms.TextBox replaceText;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox origText;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox replaceBox;
		private System.Windows.Forms.ListBox origBox;
		private System.Windows.Forms.Button startReplace;
		private System.Windows.Forms.TextBox logWindow;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Button clearIgnoreButton;
		private System.Windows.Forms.GroupBox advOptions;
		private System.Windows.Forms.RadioButton useAdvEnd;
		private System.Windows.Forms.RadioButton useAdvStart;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox sepChar;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox sepCustom;
		private System.Windows.Forms.CheckBox sepUseCustom;
		private System.Windows.Forms.CheckBox useNumbers;
		private System.Windows.Forms.ComboBox srndChar;
		private System.Windows.Forms.CheckBox useSrndChar;
	}
}

