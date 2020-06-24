namespace Aspose.OMR.ConsoleDemo
{
    using System;
    using System.IO;
    using Api;
    using Aspose.OMR.ConsoleDemo.PerformOMR;
    using Aspose.OMR.ConsoleDemo.GenerateOMRTemplates;
    using Generation;
    using Model;

    public class RunExamples
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");
            // Uncomment the one you want to try out

            // Set license, provide LicensePath and uncomment to test full results
            //SetLicense();

            // =====================================================
            // =====================================================
            // Perform OMR Operation
            // =====================================================
            // =====================================================

            PerformOMROnImages.Run();
            //PerformOMRWithThreshold.Run();
            //PerformOMRRecalculation.Run();
            //OMROperationWithBarcodeRecognition.Run();

            // =====================================================
            // =====================================================
            // Generate OMR Templates
            // =====================================================
            // =====================================================

            //GenerateTemplates.Run();
            //GenerateTemplateWithImages.Run();
            //GenerateTemplateWithBarcode.Run();
            //GenerateTemplatesWithPdfOutput.Run();

            ////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void SetLicense()
        {
            License lic = new License();
            String LicensePath = @"";
            lic.SetLicense(LicensePath);
            Console.WriteLine("License is set.");
        }

        public static string GetSourceDir()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return startDirectory != null ? Path.Combine(startDirectory, "TestData\\OMR\\") : null;
        }

        public static string GetGenerationSourceDir()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return startDirectory != null ? Path.Combine(startDirectory, "TestData\\Generation\\") : null;
        }

        public static string GetResultDir()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return startDirectory != null ? Path.Combine(startDirectory, "TestData\\Result\\") : null;
        }
    }
}
