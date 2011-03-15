using System.IO;

namespace FileRenamer
{
	public partial class FileRenamerForm
	{
		/// <summary>
		/// Refresh all controls in the form.
		/// </summary>
		private void RefreshControls()
		{
			if (!browseButton.Enabled)
				return;
			bool condition = !string.IsNullOrEmpty(folderBox.Text);
			refreshButton.Enabled = condition;
			clearIgnoreButton.Enabled = condition;

			condition = fileList.Items.Count > 0;
			startReplace.Enabled = condition;
			startBox.Enabled = condition;
			endBox.Enabled = condition;
			additionalBox.Enabled = condition;

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

		/// <summary>
		/// Enable or disable all the controls on the form.
		/// </summary>
		/// <param name="enabled">True to enable, false to disable.</param>
		private void ControlsEnabled(bool enabled)
		{
			browseButton.Enabled = enabled;
			fileList.Enabled = enabled;
			removeButton.Enabled = enabled;
			clearIgnoreButton.Enabled = enabled;
			refreshButton.Enabled = enabled;
			startReplace.Enabled = enabled;
			startBox.Enabled = enabled;
			endBox.Enabled = enabled;
			additionalBox.Enabled = enabled;
		}

		/// <summary>
		/// Refresh the file list.
		/// </summary>
		/// <param name="path">The directory to grab files from.</param>
		private void RefreshFileList(string path)
		{
			fileList.Items.Clear();
			folderBox.Text = path;
			foreach (var file in Directory.GetFiles(path))
			{
				if (!ignoreFiles.Contains(file))
					fileList.Items.Add(file);
			}
			fileListLabel.Text = "Files found (" + ignoreFiles.Count + " were ignored):";
		}
	}
}
