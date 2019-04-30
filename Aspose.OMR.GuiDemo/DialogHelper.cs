namespace Aspose.OMR.GuiDemo
{
    using Microsoft.Win32;

    public static class DialogHelper
    {
        /// <summary>
        /// The filter string for the dialog that opens template images.
        /// </summary>
        private static readonly string ImageFilesFilterPrompt = "Image files |*.jpg; *.jpeg; *.png; *.gif; *.tif; *.tiff;";

        /// <summary>
        /// The filter string for the dialog that saves recognition results
        /// </summary>
        private static readonly string DataExportFilesFilterPrompt = "Comma-Separated Values (*.csv)" + " | *.csv";

        /// <summary>
        /// Shows Open Image file dialog.
        /// </summary>
        /// <returns>Path to selected file, or <c>null</c> if no file was selected.</returns>
        public static string ShowOpenImageDialog(string suggestedDir = null)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            return ShowDialog(dialog, ImageFilesFilterPrompt, suggestedDir);
        }

        /// <summary>
        /// Shows Save Recognition Results file dialog.
        /// </summary>
        /// <returns>Path to selected file, or <c>null</c> if no file was selected.</returns>
        public static string ShowSaveDataDialog(string suggestedName)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            return ShowDialog(dialog, DataExportFilesFilterPrompt, suggestedName);
        }

        /// <summary>
        /// Displays given dialog and returns its result as a <c>string</c>.
        /// </summary>
        /// <param name="dialog">The dialog to show.</param>
        /// <param name="filter">File type filter string.</param>
        /// <param name="suggestedDir">Suggested dialog initial directory</param>
        /// <param name="suggestedName">Suggested file name</param>
        /// <returns>Path to selected file, or <c>null</c> if no file was selected.</returns>
        private static string ShowDialog(FileDialog dialog, string filter, string suggestedDir = null, string suggestedName = null)
        {
            string fileName = null;

            dialog.Filter = filter;
            dialog.RestoreDirectory = true;
            if (suggestedName != null)
            {
                dialog.FileName = suggestedName;
            }

            if (suggestedDir != null)
            {
                dialog.InitialDirectory = suggestedDir;
            }

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                fileName = dialog.FileName;
            }

            return fileName;
        }
    }
}
