using Aspose.OMR.Api;
using Aspose.OMR.Generation;
using System;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.GenerateOMRTemplates
{
    class GenerateTemplateWithBarcode
    {
        public static void Run()
        {
            // ExStart:1
            // input and output preparation
            string testFolderPath = RunExamples.GetGenerationSourceDir();
            string outputPath = RunExamples.GetResultDir();

            // initialize engine
            OmrEngine engine = new OmrEngine();

            GenerationResult res = engine.GenerateTemplate(Path.Combine(testFolderPath, "AsposeTestWithBarcode.txt"));

            // check in case of errors
            if (res.ErrorCode != 0)
            {
                Console.WriteLine("ERROR: " + res.ErrorCode + ": " + res.ErrorMessage);
            }

            // save generation result: image and .omr template
            res.Save(outputPath, "AsposeTestWithBarcode");
            // ExEnd:1

            Console.WriteLine("GenerateTemplateWithBarcode executed successfully.\n\r");
        }
    }
}
