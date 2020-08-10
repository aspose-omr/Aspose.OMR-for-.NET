---
title: Aspose.OMR for .NET 19.4 Release Notes
type: docs
weight: 40
url: /net/aspose-omr-for-net-19-4-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes information for [Aspose.OMR for .NET 19.4](http://nuget.org/packages/Aspose.OMR/19.4.0)

{{% /alert %}} 
## **First Public Release of Aspose.OMR for .NET**
We are pleased to announce the first public release of Aspose.OMR for .NET. It is simple to use API that allows developers to perform OMR operation on images. Aspose.OMR can perform OMR operation on JPEG, PNG, GIF, TIFF, and BMP image files and save the output in CSV format. Please visit the [Product Features page](/omr/net/features-list/) for further details and get the chance to download the first release of [Aspose.OMR for .NET](https://downloads.aspose.com/omr/net). You can also get familiar with the solution by using Aspose.OMR for .NET examples and demo projects at [GitHub](https://github.com/aspose-omr/Aspose.OMR-for-.NET).
# **Features**
Aspose.OMR for .NET has the capability to capture human-marked data from documents like surveys, questionnaires, examination paper, etc. With the use of Aspose.OMR for .NET, it is possible to recognize scanned images and even photos with high accuracy. Aspose.OMR for .NET supports the following features:

- Recognition of scanned images and photos
- Ability to process rotated and perspective (side viewed) images
- Recognize data from tests, exams, questionnaires, surveys, etc.
- High accuracy rate
- GUI for correcting complex cases
- Export the results to CSV file format
# **Usage Example**
{{< highlight csharp >}}

 string TemplateName = @"AsposeTest.omr";

string[] UserImages = new string[] { "Photo1.jpg", "Photo2.jpg" };

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

    string csvResult = templateProcessor.RecognizeImage(imagePath).GetResult();

    File.WriteAllText(Path.Combine(outputPath, UserImages[i] + ".csv"), csvResult);

    Console.WriteLine("Result exported. Path: " + Path.Combine(outputPath, UserImages[i] + ".csv"));

}

{{< /highlight >}}
