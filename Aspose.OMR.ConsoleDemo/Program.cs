namespace Aspose.OMR.ConsoleDemo
{
    using System;
    using System.IO;
    using Api;
    using Model;

    public class Program
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

        /// <summary>
        /// User images to recognize
        /// </summary>
        private static readonly string[] UserImages = new string[] { "Sheet1.jpg", "Sheet2.jpg" };

        /// <summary>
        /// Starting point of the demo
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Set license, provide LicensePath and uncomment to test full results
            SetLicense();

            // Recognize images
            Recognize();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void SetLicense()
        {
            License lic = new License();
            lic.SetLicense(LicensePath);
            Console.WriteLine("License is set.");
        }

        /// <summary>
        /// Method demonstrated full OMR workflow.
        /// </summary>
        public static void Recognize()
        {
            // Set custom threshold to use in recalculation
            int CustomThreshold = 40;

            string testFolderPath = Path.Combine(FindDataFolder(), TestDataFolderName);
            Console.WriteLine("Test folder located. Path: " + testFolderPath);

            string templatePath = Path.Combine(testFolderPath, TemplateName);
            string outputPath = Path.Combine(testFolderPath, "Result");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // init engine and get template processor
            OmrEngine engine = new OmrEngine();
            TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);

            Console.WriteLine("Template loaded.");

            for (int i = 0; i < UserImages.Length; i++)
            {
                string image = UserImages[i];
                string imagePath = Path.Combine(testFolderPath, image);
                Console.WriteLine("Processing image: " + imagePath);

                // recognize image
                RecognitionResult result = templateProcessor.RecognizeImage(imagePath);

                // get export csv string
                string stringRes = result.GetCsv();

                // save csv to output folder
                string outputName = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(image) + ".csv");

                File.WriteAllText(outputName, stringRes);
                Console.WriteLine("Export done. Path: " + outputName);

                // recalculate recognition results with custom threshold
                templateProcessor.Recalculate(result, CustomThreshold);

                // get export csv string
                stringRes = result.GetCsv();

                // save recalculated results
                outputName = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(image) + "_recalculated.csv");
                File.WriteAllText(outputName, stringRes);
                Console.WriteLine("Recalculated result export done. Path: " + outputName);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Silent and short version of recognition workflow
        /// </summary>
        public static void RecognizeShort()
        {
            // ---------------------------------------
            // input and output preparation
            string testFolderPath = Path.Combine(FindDataFolder(), TestDataFolderName);
            Console.WriteLine("Test folder located. Path: " + testFolderPath);

            string templatePath = Path.Combine(testFolderPath, TemplateName);
            string outputPath = Path.Combine(testFolderPath, "Result");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            // ---------------------------------------



            // actual OMR API calls
            OmrEngine engine = new OmrEngine();
            TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);

            for (int i = 0; i < UserImages.Length; i++)
            {
                string imagePath = Path.Combine(testFolderPath, UserImages[i]);
                string csvResult = templateProcessor.RecognizeImage(imagePath).GetCsv();

                File.WriteAllText(Path.Combine(outputPath, UserImages[i] + ".csv"), csvResult);
            }
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
