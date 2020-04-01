using Aspose.OMR.Api;
using System;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.PerformOMR
{
    class PerformOMRWithThreshold
    {
        public static void Run()
        {
            // ExStart:1
            string TemplateName = @"Sheet.omr";
            string[] UserImages = new string[] { "Sheet1.jpg", "Sheet2.jpg" };

            int CustomThreshold = 40;

            // input and output preparation
            string testFolderPath = RunExamples.GetSourceDir();
            string templatePath = Path.Combine(testFolderPath, TemplateName);
            string outputPath = RunExamples.GetResultDir();

            // actual OMR API calls
            OmrEngine engine = new OmrEngine();
            TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);
            Console.WriteLine("Template loaded.");

            for (int i = 0; i < UserImages.Length; i++)
            {
                string imagePath = Path.Combine(testFolderPath, UserImages[i]);
                string csvResult = templateProcessor.RecognizeImage(imagePath, CustomThreshold).GetCsv();

                File.WriteAllText(Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImages[i]) + "_Threshold.csv"), csvResult);
                Console.WriteLine("Result exported. Path: " + Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImages[i]) + "_Threashold.csv"));
            }
            Console.WriteLine("PerformOMRWithThreshold executed successfully.\n\r");
            // ExEnd:1
        }
    }
}
