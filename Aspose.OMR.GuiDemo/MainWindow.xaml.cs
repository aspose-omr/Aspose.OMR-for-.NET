namespace Aspose.OMR.GuiDemo
{
    using System;
    using System.IO;
    using System.Windows;
    using Api;
    using CorrectionUI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Test data should be located under "TestData" folder in solution directory
        private static readonly string TestDataFolderName = @"TestData";

        /// <summary>
        /// Template for testing
        /// </summary>
        private static readonly string TemplateName = @"Sheet.omr";

        /// <summary>
        /// Path to the license Aspose.OMR.NET.lic file
        /// </summary>
        private static readonly string LicensePath = @"";

        private CorrectionControl control;

        public MainWindow()
        {
            InitializeComponent();

            // Set license, provide LicensePath and uncomment to test full results
            //SetLicense();
        }

        public string UserImagePath { get; set; }

        public string DataFolderPath { get; set; }


        /// <summary>
        /// Loads and displays CorrectionControl
        /// </summary>
        private void GetButtonClicked(object sender, RoutedEventArgs e)
        {
            this.DataFolderPath = Path.Combine(FindDataFolder(), TestDataFolderName);
            string templatePath = Path.Combine(this.DataFolderPath, TemplateName);

            OmrEngine engine = new OmrEngine();
            TemplateProcessor processor = engine.GetTemplateProcessor(templatePath);

            control = engine.GetCorrectionControl(processor);
            CustomContentControl.Content = control;
            control.Initialize();
        }

        /// <summary>
        /// Select and display image 
        /// </summary>
        private void SelectImageClicked(object sender, RoutedEventArgs e)
        {
            if (control == null)
            {
                return;
            }

            string imagePath = DialogHelper.ShowOpenImageDialog(this.DataFolderPath);
            if (string.IsNullOrEmpty(imagePath))
            {
                return;
            }

            this.UserImagePath = imagePath;

            control.LoadAndDisplayImage(imagePath);
        }

        /// <summary>
        /// Recognize loaded image
        /// </summary>
        private void RecognizeImageClicked(object sender, RoutedEventArgs e)
        {
            if (control == null)
            {
                return;
            }

            control.RecognizeImage();
        }

        /// <summary>
        /// Export results to CSV
        /// </summary>
        private void ExportResultsClicked(object sender, RoutedEventArgs e)
        {
            if (control == null)
            {
                return;
            }

            string imageName = Path.GetFileNameWithoutExtension(this.UserImagePath);

            string path = DialogHelper.ShowSaveDataDialog(imageName);
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            control.ExportResults(path);
        }

        /// <summary>
        /// License the product
        /// </summary>
        private static void SetLicense()
        {
            License lic = new License();
            lic.SetLicense(LicensePath);
        }

        /// <summary>
        /// Finds specified test data folder
        /// </summary>
        /// <returns>Path to the test data folder</returns>
        private static string FindDataFolder()
        {
            DirectoryInfo current = new DirectoryInfo(Directory.GetCurrentDirectory());
            string templateRelPath = Path.Combine(TestDataFolderName, TemplateName);

            // Locate test data folder containing .omr file
            while (current != null && !File.Exists(Path.Combine(current.FullName, templateRelPath)))
            {
                current = current.Parent;
            }

            // Check if template file exists
            if (current == null)
            {
                throw new Exception("Unable to find template file (.omr)");
            }

            return current.FullName;
        }
    }
}
