using Aspose.OMR.Api;
using Aspose.OMR.Generation;
using System;
using System.IO;

namespace Aspose.OMR.ConsoleDemo.GenerateOMRTemplates
{
    class GenerateTemplates
    {
        public static void Run()
        {
            // ExStart:1
            // input and output preparation
            string testFolderPath = RunExamples.GetGenerationSourceDir();
            string outputPath = RunExamples.GetResultDir();

            string[] GenerationMarkups = new string[] { "Sheet.txt", "Grid.txt", "AsposeTest.txt" };

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
            // ExEnd:1

            Console.WriteLine("GenerateTemplates executed successfully.\n\r");
        }
    }
}
