using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileRenamer
{
	public partial class FileRenamerForm : Form
	{
		public FileRenamerForm()
		{
			InitializeComponent();
			RefreshControls();
		}

		List<string> IgnoreFiles = new List<string>();

		private void FileRenamerForm_Load(object sender, EventArgs e)
		{
			var startReplaceToolTip = new ToolTip();
			startReplaceToolTip.SetToolTip(startReplaceText, "Use %EMPTY% to replace with nothing. (i.e remove the specified string)");
			var endReplaceToolTip = new ToolTip();
			endReplaceToolTip.SetToolTip(endReplaceText, "Use %EMPTY% to replace with nothing. (i.e remove the specified string)");
			var customReplaceToolTip = new ToolTip();
			customReplaceToolTip.SetToolTip(replaceText, "Use %EMPTY% to replace with nothing. (i.e remove the specified string)");
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			IgnoreFiles.Add(fileList.SelectedItem.ToString());
			fileList.Items.Remove(fileList.SelectedItem);
			RefreshControls();
			RefreshFileList(folderBox.Text);
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			IgnoreFiles.Clear();
			DialogResult result = folderDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				RefreshFileList(folderDialog.SelectedPath);
			}
			RefreshControls();
		}

		private void addString_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(origText.Text) && !string.IsNullOrEmpty(replaceText.Text))
			{
				origBox.Items.Add(origText.Text);
				replaceBox.Items.Add(replaceText.Text);
				origText.Text = string.Empty;
				replaceText.Text = string.Empty;
			}
			RefreshControls();
		}

		private void removeString_Click(object sender, EventArgs e)
		{
			if (origBox.SelectedItem != null)
			{
				replaceBox.Items.RemoveAt(origBox.SelectedIndex);
				origBox.Items.Remove(origBox.SelectedItem);
				RefreshControls();
			}
		}

		private void startReplace_Click(object sender, EventArgs e)
		{
			var newLine = Environment.NewLine;
			ControlsEnabled(false);
			string prefix = folderBox.Text + "\\";
			int prefixLength = prefix.Length;
			logWindow.AppendText("==BEGINNING RENAMING OF FILES==" + newLine);
			if (!notUseStartReplace.Checked)
			{
				logWindow.AppendText(newLine + "==REPLACING AT BEGINNING OF FILES==" + newLine);
				foreach (var file in fileList.Items)
				{
					string oldName = file.ToString().Remove(0, prefixLength);
					string newName = oldName;
					string replaceString;
					if (startReplaceText.Text.ToUpper() == "%EMPTY%")
						replaceString = string.Empty;
					else
						replaceString = startReplaceText.Text;

					if (!newName.Contains(startText.Text))
					{
						logWindow.AppendText("Couldn't replace at start of file name, string not found. On " + oldName + newLine);
					}
					else
					{
						int textLength = startText.Text.Length;
						newName = newName.Remove(0, textLength);
						string newNameShort = replaceString + newName;
						newName = prefix + replaceString + newName;
						try
						{
							File.Move(file.ToString(), newName);
							logWindow.AppendText("Renamed " + oldName + " to " + newNameShort + newLine);
						}
						catch (Exception ex)
						{
							logWindow.AppendText("ERROR: Unable to rename file. Details: " + ex.Message + newLine);
						}
					}
				}
				logWindow.AppendText("==DONE REPLACING AT BEGINNING OF FILES==" + newLine);
			}
			else
			{
				logWindow.AppendText(newLine + "==SKIPPING REPLACE AT BEGINNING OF FILES (USER SPECIFIED)==" + newLine);
			}
			RefreshFileList(folderBox.Text);
			if (!notUseEndReplace.Checked)
			{
				logWindow.AppendText(newLine + "==REPLACING END OF FILES==" + newLine);
				foreach (var file in fileList.Items)
				{
					string oldName = file.ToString().Remove(0, prefixLength);
					string newName = oldName;
					string replaceString;
					if (endReplaceText.Text.ToUpper() == "%EMPTY%")
						replaceString = string.Empty;
					else
						replaceString = endReplaceText.Text;
					if (!newName.Contains(endText.Text))
					{
						logWindow.AppendText("Couldn't replace at end of file name, string not found. On " + oldName + newLine);
					}
					else
					{
						int extIndex = newName.LastIndexOf(".");
						string ext = newName.Substring(extIndex);
						newName = newName.Remove(extIndex);
						int textLength = endText.Text.Length;
						newName = newName.Remove(newName.Length - textLength);
						string newNameShort = newName + replaceString + ext;
						newName = prefix + newName + replaceString + ext;
						try
						{
							File.Move(file.ToString(), newName);
							logWindow.AppendText("Renamed " + oldName + " to " + newNameShort + newLine);
						}
						catch(Exception ex)
						{
							logWindow.AppendText("ERROR: Unable to rename file. Details: " + ex.Message + newLine);
						}
					}
				}
				logWindow.AppendText("==DONE REPLACING AT END OF FILES==" + newLine);
			}
			else
			{
				logWindow.AppendText(newLine + "==SKIPPING REPLACE AT END OF FILES (USER SPECIFIED)==" + newLine);
			}
			RefreshFileList(folderBox.Text);
			if (useAddOptions.Checked)
			{
				logWindow.AppendText(newLine + "==BEGINNING CUSTOM REPLACE OF FILE NAMES==" + newLine);
				foreach (var file in fileList.Items)
				{
					string oldName = file.ToString().Remove(0, prefixLength);
					string newName = oldName;
					foreach (var replaceString in replaceBox.Items)
					{
						string replace;
						if (replaceString.ToString().ToUpper() == "%EMPTY%")
							replace = string.Empty;
						else
							replace = replaceString.ToString();
						foreach (var origString in origBox.Items)
						{
							if (newName.Contains(origString.ToString()))
								newName = newName.Replace(origString.ToString(), replace);
							else
								logWindow.AppendText("Couldn't do custom replace, string \"" + origString +  "\" not found. On " + oldName + newLine);
						}
					}
					string newNameShort = newName;
					newName = prefix + newName;
					try
					{
						File.Move(file.ToString(), newName);
						logWindow.AppendText("Renamed " + oldName + " to " + newNameShort + newLine);
					}
					catch (Exception ex)
					{
						logWindow.AppendText("ERROR: Unable to rename file. Details: " + ex.Message + newLine);
					}
				}
				logWindow.AppendText("==DONE REPLACING CUSTOM FILE NAMES==" + newLine);
			}
			else
			{
				logWindow.AppendText(newLine + "==SKIPPING CUSTOM REPLACE (USER SPECIFIED)==" + newLine);
			}
			logWindow.AppendText(newLine + "==DONE RENAMING FILES==" + newLine);
			RefreshFileList(folderBox.Text);
			ControlsEnabled(true);
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			RefreshFileList(folderBox.Text);
			RefreshControls();
		}

		private void textChanged(object sender, EventArgs e)
		{
			RefreshControls();
		}

		private void clearIgnoreButton_Click(object sender, EventArgs e)
		{
			IgnoreFiles.Clear();
			RefreshFileList(folderBox.Text);
		}
	}
}
