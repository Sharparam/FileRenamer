using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileRenamer
{
	public partial class FileRenamerForm : Form
	{
		/// <summary>
		/// List of files that will not be included when renaming.
		/// </summary>
		readonly List<string> ignoreFiles = new List<string>();

		/// <summary>
		/// List of characters (strings) that can be used to separate the number from the file name.
		/// </summary>
		readonly string[] sepChars = new[]
		{
		    "_",
			"-",
			"#"
		};

		/// <summary>
		/// List of characters (strings) that can be used to surround numbers.
		/// </summary>
		readonly string[] srndChars = new[]
		{
			"( )",
			"[ ]",
			"{ }"
		};

		public FileRenamerForm()
		{
			InitializeComponent();
			//Load values into ComboBoxes
			sepChar.Items.AddRange(sepChars);
			srndChar.Items.AddRange(srndChars);
			//Set the "default" selected item on ComboBoxes
			sepChar.SelectedIndex = 0;
			srndChar.SelectedIndex = 0;
			//Setup the tooltips.
			var startReplaceToolTip = new ToolTip();
			startReplaceToolTip.SetToolTip(startReplaceText, "Use %EMPTY% to replace with nothing. (i.e remove the specified string)");
			var endReplaceToolTip = new ToolTip();
			endReplaceToolTip.SetToolTip(endReplaceText, "Use %EMPTY% to replace with nothing. (i.e remove the specified string)");
			var customReplaceToolTip = new ToolTip();
			customReplaceToolTip.SetToolTip(replaceText, "Use %EMPTY% to replace with nothing. (i.e remove the specified string)");
			RefreshControls();
		}

		private void RemoveButtonClick(object sender, EventArgs e)
		{
			//Add the currently selected file to the list of ignored files.
			ignoreFiles.Add(fileList.SelectedItem.ToString());
			//Remove the item from the file list.
			fileList.Items.Remove(fileList.SelectedItem);
			//Refresh the controls and file list.
			RefreshControls();
			RefreshFileList(folderBox.Text);
		}

		private void BrowseButtonClick(object sender, EventArgs e)
		{
			//Remove all files from the ignore list.
			ignoreFiles.Clear();
			DialogResult result = folderDialog.ShowDialog(this);
			//Check if the user press OK, otherwise unexpected errors might occur.
			if (result == DialogResult.OK)
			{
				RefreshFileList(folderDialog.SelectedPath);
			}
			RefreshControls();
		}

		private void AddStringClick(object sender, EventArgs e)
		{
			//Check so that the user is not adding null values.
			if (!string.IsNullOrEmpty(origText.Text) && !string.IsNullOrEmpty(replaceText.Text))
			{
				//Add the strings to boxes and reset the input fields.
				origBox.Items.Add(origText.Text);
				replaceBox.Items.Add(replaceText.Text);
				origText.Text = string.Empty;
				replaceText.Text = string.Empty;
			}
			RefreshControls();
		}

		private void RemoveStringClick(object sender, EventArgs e)
		{
			//Check so that the user is not trying to remove a null item.
			if (origBox.SelectedItem != null)
			{
				//Remove the item from both boxes.
				replaceBox.Items.RemoveAt(origBox.SelectedIndex);
				origBox.Items.Remove(origBox.SelectedItem);
				RefreshControls();
			}
		}

		private void StartReplaceClick(object sender, EventArgs e)
		{
			Replace();
		}

		private void RefreshButtonClick(object sender, EventArgs e)
		{
			RefreshFileList(folderBox.Text);
			RefreshControls();
		}

		private void TextCheck(object sender, EventArgs e)
		{
			RefreshControls();
		}

		private void ClearIgnoreButtonClick(object sender, EventArgs e)
		{
			ignoreFiles.Clear();
			RefreshFileList(folderBox.Text);
		}

		private void CheckChanged(object sender, EventArgs e)
		{
			RefreshControls();
		}
	}
}
