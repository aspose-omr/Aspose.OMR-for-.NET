using Aspose.OMR.Api;
using System;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.PerformOMR
{
    class OMROperationWithBarcodeRecognition
    {
        public static void Run()
        {
            // ExStart:1
            string TemplateName = @"AsposeTestWithBarcode.omr";
            string UserImage = "AsposeTestWithBarcode.jpg";

            // input and output preparation
            string testFolderPath = RunExamples.GetSourceDir();
            string templatePath = Path.Combine(testFolderPath, TemplateName);
            string outputPath = RunExamples.GetResultDir();

            // actual OMR API calls
            OmrEngine engine = new OmrEngine();
            TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);
            Console.WriteLine("Template loaded.");

            string imagePath = Path.Combine(testFolderPath, UserImage);
            string csvResult = templateProcessor.RecognizeImage(imagePath).GetCsv();

            File.WriteAllText(Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImage) + ".csv"), csvResult);
            Console.WriteLine("Result exported. Path: " + Path.Combine(outputPath, Path.GetFileNameWithoutExtension(UserImage) + ".csv"));

            Console.WriteLine("OMROperationWithBarcodeRecognition executed successfully.\n\r");
            // ExEnd:1
        }
    }
}
