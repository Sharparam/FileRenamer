﻿using System.IO;

namespace FileRenamer
{
	public partial class FileRenamerForm
	{
		private void RefreshControls()
		{
			if (!browseButton.Enabled)
				return;
			if (!string.IsNullOrEmpty(folderBox.Text))
			{
				refreshButton.Enabled = true;
				clearIgnoreButton.Enabled = true;
			}
			else
			{
				refreshButton.Enabled = false;
				clearIgnoreButton.Enabled = false;
			}

			if (fileList.Items.Count > 0)
			{
				startReplace.Enabled = true;
				startBox.Enabled = true;
				endBox.Enabled = true;
				additionalBox.Enabled = true;
			}
			else
			{
				startReplace.Enabled = false;
				startBox.Enabled = false;
				endBox.Enabled = false;
				additionalBox.Enabled = false;
			}

			if (string.IsNullOrEmpty(startReplaceText.Text) || string.IsNullOrEmpty(startText.Text))
			{
				notUseStartReplace.Checked = true;
				notUseStartReplace.Enabled = false;
			}
			else
			{
				notUseStartReplace.Enabled = true;
			}


			if (string.IsNullOrEmpty(endReplaceText.Text) || string.IsNullOrEmpty(endText.Text))
			{
				notUseEndReplace.Checked = true;
				notUseEndReplace.Enabled = false;
			}
			else
			{
				notUseEndReplace.Enabled = true;
			}

			if (replaceBox.Items.Count <= 0 || origBox.Items.Count <= 0)
			{
				useAddOptions.Checked = false;
				useAddOptions.Enabled = false;
			}
			else
			{
				useAddOptions.Enabled = true;
			}
		}

		private void ControlsEnabled(bool enabled)
		{
			if (enabled)
			{
				browseButton.Enabled = true;
				fileList.Enabled = true;
				removeButton.Enabled = true;
				clearIgnoreButton.Enabled = true;
				refreshButton.Enabled = true;
				startReplace.Enabled = true;
				startBox.Enabled = true;
				endBox.Enabled = true;
				additionalBox.Enabled = true;
			}
			else
			{
				browseButton.Enabled = false;
				fileList.Enabled = false;
				removeButton.Enabled = false;
				clearIgnoreButton.Enabled = false;
				refreshButton.Enabled = false;
				startReplace.Enabled = false;
				startBox.Enabled = false;
				endBox.Enabled = false;
				additionalBox.Enabled = false;
			}
		}
		private void RefreshFileList(string path)
		{
			fileList.Items.Clear();
			folderBox.Text = path;
			foreach (var file in Directory.GetFiles(path))
			{
				if (!IgnoreFiles.Contains(file))
					fileList.Items.Add(file);
			}
			fileListLabel.Text = "Files found (" + IgnoreFiles.Count + " Ignored):";
		}
	}
}
