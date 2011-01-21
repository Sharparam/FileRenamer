using System;
using System.Drawing;
using System.IO;

namespace FileRenamer
{
	partial class FileRenamerForm
	{
		private string prefix;
		private int prefixLength;

		public void Replace()
		{
			//Disable the controls so that the user may not interfer.
			ControlsEnabled(false);
			//This would be the path to the folder with an added backslash (\). i.e: C:\MyFolder\
			prefix = folderBox.Text + "\\";
			//Get the length of the path.
			prefixLength = prefix.Length;
			LogOut("==BEGINNING RENAMING OF FILES==" + Environment.NewLine, Color.Blue);
			//Perform replace at beginning of name only if the user wants to.
			if (!notUseStartReplace.Checked)
			{
				ReplaceBeginning();
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
				ReplaceEnd();
			}
			else
			{
				//NOTE: This is not always "user" specified, change this?
				LogOut(Environment.NewLine + "==SKIPPING REPLACE AT END OF FILES (USER SPECIFIED)==" + Environment.NewLine, Color.Blue);
			}
			//Refresh the file list before continuing so that the next replace will get updated information.
			RefreshFileList(folderBox.Text);
			//Perform the custom replace only if the user wants to.
			if (useAddOptions.Checked)
			{
				ReplaceCustom();
			}
			else
			{
				//NOTE: This is not always "user" specified, change this?
				LogOut(Environment.NewLine + "==SKIPPING CUSTOM REPLACE (USER SPECIFIED)==" + Environment.NewLine, Color.Blue);
			}
			//Refresh the file list before continuing so that the next replace will get updated information.
			RefreshFileList(folderBox.Text);
			//Perform numeration only if the user wants to.
			if (useNumbers.Checked)
			{
				Numerate();
			}
			else
			{
				//NOTE: This is not always "user" specified, change this?
				LogOut(Environment.NewLine + "==SKIPPING NUMERATION OF FILES (USER SPECIFIED)==" + Environment.NewLine, Color.Blue);
			}
			LogOut(Environment.NewLine + "==DONE RENAMING FILES==" + Environment.NewLine, Color.Green);
			//Refresh the file list.
			RefreshFileList(folderBox.Text);
			//Enable the controls again.
			ControlsEnabled(true);
		}

		private void ReplaceBeginning()
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

		private void ReplaceEnd()
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
					catch (Exception ex)
					{
						LogOut("ERROR: Unable to rename file. Details: " + ex.Message + Environment.NewLine, Color.Red);
					}
				}
			}
			LogOut("==DONE REPLACING AT END OF FILES==" + Environment.NewLine, Color.Green);
		}

		private void ReplaceCustom()
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
							LogOut("Couldn't do custom replace, string \"" + origString + "\" not found. On " + oldName + Environment.NewLine, Color.Blue);
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

		private void Numerate()
		{
			LogOut(Environment.NewLine + "==BEGINNING NUMERATION OF FILES==" + Environment.NewLine, Color.Blue);
			LogOut(Environment.NewLine + Environment.NewLine + Environment.NewLine);
			//Get the number of files
			int numFiles = fileList.Items.Count;
			//Get the number of max digits in the numbers
			int digits = numFiles.ToString().Length;
			int number = 0;
			foreach (var file in fileList.Items)
			{
				number++;
				string oldName = file.ToString().Remove(0, prefixLength);
				int extIndex = oldName.LastIndexOf(".");
				string ext = oldName.Substring(extIndex);
				string newName = oldName.Remove(extIndex);
				string sep;
				string num;
				if (useSepChar.Checked)
				{
					if (sepUseCustom.Checked)
					{
						sep = sepCustom.Text;
					}
					else
					{
						if (sepChar.SelectedItem.ToString() == "(Space)")
							sep = " ";
						else
							sep = sepChar.SelectedItem.ToString();
					}
				}
				else
				{
					sep = string.Empty;
				}
				if (useSrndChar.Checked)
					num = srndChar.SelectedItem.ToString().Replace(" ", number.ToString().PadLeft(digits, '0'));
				else
					num = number.ToString();

				string newNameShort = newName + sep + num + ext;
				newName = prefix + newName + sep + num + ext;
				string oldNameShort = oldName;
				oldName = prefix + oldName;
				try
				{
					//Rename, "move", the file.
					File.Move(oldName, newName);
					logWindow.AppendText("Renamed " + oldNameShort + " to " + newNameShort + Environment.NewLine);
				}
				catch (Exception ex)
				{
					LogOut("ERROR: Unable to rename file. Details: " + ex.Message + Environment.NewLine, Color.Red);
				}
			}
		}
	}
}
