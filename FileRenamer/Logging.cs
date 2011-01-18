using System;
using System.Drawing;

namespace FileRenamer
{
	public partial class FileRenamerForm
	{
		/// <summary>
		/// Print a message to the log window.
		/// </summary>
		/// <param name="message">The message to print</param>
		public void LogOut(string message)
		{
			logWindow.AppendText(message + Environment.NewLine);
		}

		/// <summary>
		/// Print a message to the log window with the specified color.
		/// </summary>
		/// <param name="message">The message to print</param>
		/// <param name="color">The (fore)color to use.</param>
		public void LogOut(string message, Color color)
		{
			logWindow.SelectionColor = color;
			logWindow.SelectedText = message + Environment.NewLine;
		}
	}
}
