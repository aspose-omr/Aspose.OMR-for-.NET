namespace Aspose.OMR.ConsoleDemo
{
    using System;
    using System.IO;
    using Api;
    using Generation;
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
        /// Text markups used in template generation
        /// </summary>
        private static readonly string[] GenerationMarkups = new string[] { "Sheet.txt", "Grid.txt", "AsposeTest.txt" };

        /// <summary>
        /// Starting point of the demo
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Set license, provide LicensePath and uncomment to test full results
            SetLicense();

            // Create template and image from text
            Generate();

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
        /// Demonstrates template generation workflow
        /// </summary>
        public static void Generate()
        {
            // input and output preparation
            string testFolderPath = Path.Combine(FindDataFolder(), TestDataFolderName);
            testFolderPath = Path.Combine(testFolderPath, "Generation");
            Console.WriteLine("Test folder located. Path: " + testFolderPath);

            string outputPath = Path.Combine(testFolderPath, "Result");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // initialize engine
            OmrEngine engine = new OmrEngine();

            for (int i = 0; i < GenerationMarkups.Length; i++)
            {
                // call template generation providing path to the txt file with markup
                GenerationResult res = engine.GenerateTemplate(Path.Combine(testFolderPath, GenerationMarkups[i]));

                // check in case of errors
                if (res.ErrorCode != 0)
                {
                    Console.WriteLine("ERROR CODE: " + res.ErrorCode);
                }

                // save generation result: image and .omr template
                res.Save(outputPath, Path.GetFileNameWithoutExtension(GenerationMarkups[i]));
            }
        }

        /// <summary>
        /// Demonstrates main OMR workflow
        /// </summary>
        public static void Recognize()
        {
            // input and output preparation
            string testFolderPath = Path.Combine(FindDataFolder(), TestDataFolderName);
            Console.WriteLine("Test folder located. Path: " + testFolderPath);

            string templatePath = Path.Combine(testFolderPath, TemplateName);
            string outputPath = Path.Combine(testFolderPath, "Result");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // initialize engine and get template processor providing path to the .omr file
            OmrEngine engine = new OmrEngine();
            TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);
            Console.WriteLine("Template loaded.");

            // images loop
            for (int i = 0; i < UserImages.Length; i++)
            {
                // path to the image to be recognized
                string imagePath = Path.Combine(testFolderPath, UserImages[i]);
                Console.WriteLine("Processing image: " + imagePath);

                // recognize image and recieve result
                RecognitionResult result = templateProcessor.RecognizeImage(imagePath);

                // export results as csv string
                string csvResult = result.GetCsv();

                // save csv to the output folder
                File.WriteAllText(Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImages[i]) + ".csv"), csvResult);
            }
        }


        /// <summary>
        /// Demonstrates full OMR workflow, including recalculation of existing result
        /// </summary>
        public static void RecognizeWithRecalculation()
        {
            // input and output preparation
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

            // Set custom threshold to use in recalculation
            // this value is in range (0..100)
            // represents the percentage of required black pixels on bubble image to be recognized
            // i.e. the lower the value - the less black pixels required for bubble to be counted as filled and vice versa
            int CustomThreshold = 40;

            // images loop
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
