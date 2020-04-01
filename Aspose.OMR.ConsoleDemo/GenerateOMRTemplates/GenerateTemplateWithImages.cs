using Aspose.OMR.Api;
using Aspose.OMR.Generation;
using System;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.GenerateOMRTemplates
{
    class GenerateTemplateWithImages
    {
        public static void Run()
        {
            // ExStart:1
            // input and output preparation
            string testFolderPath = RunExamples.GetGenerationSourceDir();
            string outputPath = RunExamples.GetResultDir();

            string[] images = { Path.Combine(testFolderPath, "Aspose.jpg") };

            // initialize engine
            OmrEngine engine = new OmrEngine();

            GenerationResult res = engine.GenerateTemplate(Path.Combine(testFolderPath, "AsposeTestWithImage.txt"), images);

            // check in case of errors
            if (res.ErrorCode != 0)
            {
                Console.WriteLine("ERROR CODE: " + res.ErrorCode);
            }

            // save generation result: image and .omr template
            res.Save(outputPath, "AsposeTestWithImage");
            // ExEnd:1

            Console.WriteLine("GenerateTemplateWithImages executed successfully.\n\r");
        }
    }
}
