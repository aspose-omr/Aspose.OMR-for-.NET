using Aspose.OMR.Api;
using System;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.PerformOMR
{
    class PerformOMROnImages
    {
        public static void Run()
        {
            // ExStart:1
            string TemplateName = @"Sheet.omr";
            string[] UserImages = new string[] { "Sheet1.jpg", "Sheet2.jpg" };

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
                string csvResult = templateProcessor.RecognizeImage(imagePath).GetCsv();

                File.WriteAllText(Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImages[i]) + ".csv"), csvResult);
                Console.WriteLine("Result exported. Path: " + Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImages[i]) + ".csv"));
            }
            Console.WriteLine("PerformOMROnImages executed successfully.\n\r");
            // ExEnd:1
        }
    }
}
