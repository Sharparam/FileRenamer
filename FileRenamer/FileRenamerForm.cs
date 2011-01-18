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
			//Disable the controls so that the user may not interfer.
			ControlsEnabled(false);
			//This would be the path to the folder with an added backslash (\). i.e: C:\MyFolder\
			string prefix = folderBox.Text + "\\";
			//Get the length of the path.
			int prefixLength = prefix.Length;
			LogOut("==BEGINNING RENAMING OF FILES==" + Environment.NewLine, Color.Blue);
			//Perform replace at beginning of name only if the user wants to.
			if (!notUseStartReplace.Checked)
			{
				LogOut(Environment.NewLine + "==REPLACING AT BEGINNING OF FILES==" + Environment.NewLine, Color.Blue);
				foreach (var file in fileList.Items)
				{
					//Get the old name of the file and remove the path in front of it.
					string oldName = file.ToString().Remove(0, prefixLength);
					string newName = oldName;
					//Find out if the user wants to replace it with an empty string.
					string replaceString = startReplaceText.Text.ToUpper() == "%EMPTY%" ? string.Empty : startReplaceText.Text;

					//Check if the name contains what we want to replace, otherwise skip it.
					//NOTE: Could use oldName here?
					if (!newName.Contains(startText.Text))
					{
						LogOut("Couldn't replace at start of file name, string not found. On " + oldName + Environment.NewLine, Color.Blue);
					}
					else
					{
						//Get the length of what we want to replace.
						int textLength = startText.Text.Length;
						//Remove it from the beginning of the name.
						newName = newName.Remove(0, textLength);
						//Get the new name of the file (without the path in front of it)
						string newNameShort = replaceString + newName;
						//Get the full new name of the file (with the path in front of it)
						newName = prefix + replaceString + newName;
						//Have this inside try-catch just in case something would go wrong.
						try
						{
							//Rename, "move", the file.
							File.Move(file.ToString(), newName);
							LogOut("Renamed " + oldName + " to " + newNameShort + Environment.NewLine);
						}
						catch (Exception ex)
						{
							LogOut("ERROR: Unable to rename file. Details: " + ex.Message + Environment.NewLine, Color.Red);
						}
					}
				}
				LogOut("==DONE REPLACING AT BEGINNING OF FILES==" + Environment.NewLine, Color.Green);
			}
			else
			{
				//NOTE: This is not always "user" specified, change this?
				LogOut(Environment.NewLine + "==SKIPPING REPLACE AT BEGINNING OF FILES (USER SPECIFIED)==" + Environment.NewLine, Color.Blue);
			}
			//Refresh the file list before continuing so that the next replace will get updated information.
			RefreshFileList(folderBox.Text);
			//Perform replace at end of name only if the user wants to.
			if (!notUseEndReplace.Checked)
			{
				LogOut(Environment.NewLine + "==REPLACING END OF FILES==" + Environment.NewLine, Color.Blue);
				foreach (var file in fileList.Items)
				{
					//Get the old name without the path in front of it.
					string oldName = file.ToString().Remove(0, prefixLength);
					string newName = oldName;
					//Find out if the user wants to replace it with an empty string.
					string replaceString = endReplaceText.Text.ToUpper() == "%EMPTY%" ? string.Empty : endReplaceText.Text;

					//Check if the name contains what we want to replace, otherwise skip it.
					//NOTE: Could use oldName here?
					if (!newName.Contains(endText.Text))
					{
						LogOut("Couldn't replace at end of file name, string not found. On " + oldName + Environment.NewLine, Color.Blue);
					}
					else
					{
						//Get the position of the extension (i.e: .txt, .exe, .doc)
						//TODO: This will probably throw error if the filename does not contain a dot (.) with something after it.
						int extIndex = newName.LastIndexOf(".");
						//Get the extension
						string ext = newName.Substring(extIndex);
						//Remove the extension from the filename to make renaming easier.
						newName = newName.Remove(extIndex);
						//Get the length of the replace string.
						int textLength = endText.Text.Length;
						//Remove the end part of the filename.
						newName = newName.Remove(newName.Length - textLength);
						//Get the new name of the file (without the path in front of it)
						string newNameShort = newName + replaceString + ext;
						//Get the full new name of the file (with the path in front of it)
						newName = prefix + newName + replaceString + ext;
						//Have this inside try-catch just in case something would go wrong.
						try
						{
							//Rename, "move", the file.
							File.Move(file.ToString(), newName);
							LogOut("Renamed " + oldName + " to " + newNameShort + Environment.NewLine);
						}
						catch(Exception ex)
						{
							LogOut("ERROR: Unable to rename file. Details: " + ex.Message + Environment.NewLine, Color.Red);
						}
					}
				}
				LogOut("==DONE REPLACING AT END OF FILES==" + Environment.NewLine, Color.Green);
			}
			else
			{
				LogOut(Environment.NewLine + "==SKIPPING REPLACE AT END OF FILES (USER SPECIFIED)==" + Environment.NewLine, Color.Blue);
			}
			//Refresh the file list before continuing so that the next replace will get updated information.
			RefreshFileList(folderBox.Text);
			//Perform the custom replace only if the user wants to.
			if (useAddOptions.Checked)
			{
				LogOut(Environment.NewLine + "==BEGINNING CUSTOM REPLACE OF FILE NAMES==" + Environment.NewLine, Color.Blue);
				foreach (var file in fileList.Items)
				{
					//Get the old name of the file without the path in front of it.
					string oldName = file.ToString().Remove(0, prefixLength);
					string newName = oldName;
					foreach (var replaceString in replaceBox.Items)
					{
						//Find out if the user wants to replace it with an empty string.
						string replace = replaceString.ToString().ToUpper() == "%EMPTY%" ? string.Empty : replaceString.ToString();
						foreach (var origString in origBox.Items)
						{
							//Check if the name contains what we want to replace and if it does, replace it with the new string.
							if (newName.Contains(origString.ToString()))
								newName = newName.Replace(origString.ToString(), replace);
							else
								LogOut("Couldn't do custom replace, string \"" + origString +  "\" not found. On " + oldName + Environment.NewLine, Color.Blue);
						}
					}
					//Get the new name of the file (without the path in front of it)
					string newNameShort = newName;
					//Get the full new name of the file (with the path in front of it)
					newName = prefix + newName;
					//Have this inside try-catch just in case something would go wrong.
					try
					{
						//Rename, "move", the file.
						File.Move(file.ToString(), newName);
						logWindow.AppendText("Renamed " + oldName + " to " + newNameShort + Environment.NewLine);
					}
					catch (Exception ex)
					{
						LogOut("ERROR: Unable to rename file. Details: " + ex.Message + Environment.NewLine, Color.Red);
					}
				}
				LogOut("==DONE REPLACING CUSTOM FILE NAMES==" + Environment.NewLine, Color.Green);
			}
			else
			{
				LogOut(Environment.NewLine + "==SKIPPING CUSTOM REPLACE (USER SPECIFIED)==" + Environment.NewLine, Color.Blue);
			}
			LogOut(Environment.NewLine + "==DONE RENAMING FILES==" + Environment.NewLine, Color.Green);
			//Refresh the file list.
			RefreshFileList(folderBox.Text);
			//Enable the controls again.
			ControlsEnabled(true);
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
