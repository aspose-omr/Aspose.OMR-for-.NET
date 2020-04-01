using Aspose.OMR.Api;
using Aspose.OMR.Model;
using System;
using System.Diagnostics;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.PerformOMR
{
    class PerformOMRRecalculation
    {
        public static void Run()
        {
            // ExStart:1
            string TemplateName = @"Sheet.omr";
            string[] UserImages = new string[] { "Sheet1.jpg", "Sheet2.jpg" };

            string testFolderPath = RunExamples.GetSourceDir();
            string templatePath = Path.Combine(testFolderPath, TemplateName);
            string outputPath = RunExamples.GetResultDir();
            int CustomThreshold = 40;

            // init engine and get template processor
            OmrEngine engine = new OmrEngine();
            TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);

            Console.WriteLine("Template loaded.");

            for (int i = 0; i < UserImages.Length; i++)
            {
                string image = UserImages[i];
                string imagePath = Path.Combine(testFolderPath, image);
                Console.WriteLine("\n\rProcessing image: " + imagePath);

                // timer for performance measure
                Stopwatch sw = Stopwatch.StartNew();

                // recognize image
                RecognitionResult result = templateProcessor.RecognizeImage(imagePath);

                sw.Stop();
                Console.WriteLine("Recognition time: " + sw.Elapsed);

                // get export csv string
                string stringRes = result.GetCsv();

                // save csv to output folder
                File.WriteAllText(Path.Combine(outputPath, Path.GetFileNameWithoutExtension(image) + ".csv"), stringRes);
                Console.WriteLine("Result Exported. Path: " + Path.Combine(outputPath, Path.GetFileNameWithoutExtension(image) + ".csv"));

                sw.Restart();
                // recalculate recognition results with custom threshold
                Console.WriteLine("\n\rPerformaing recalculation\n\r");

                templateProcessor.Recalculate(result, CustomThreshold);
                sw.Stop();
                Console.WriteLine("Recalculation time: " + sw.Elapsed);

                // get export csv string
                stringRes = result.GetCsv();

                // save recalculated results
                File.WriteAllText(Path.Combine(outputPath, Path.GetFileNameWithoutExtension(image) + "_Recalculated.csv"), stringRes);
                Console.WriteLine("Recalculation result exported. Path: " + Path.Combine(outputPath, Path.GetFileNameWithoutExtension(image) + "_Recalculated.csv"));
            }
            Console.WriteLine("PerformOMRRecalculation executed successfully.\n\r");
            // ExEnd:1
        }
    }
}
