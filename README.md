![Nuget](https://img.shields.io/nuget/v/Aspose.OMR) ![Nuget](https://img.shields.io/nuget/dt/Aspose.OMR)

# .NET OMR API

Aspose.OMR for .NET is an [Optical Mark Recognition API](https://products.aspose.com/omr/net) to recognize optical marks from multiple image formats including JPG, BMP, GIF, TIF, TIFF. After performing OMR operation on these images, API saves the output in CSV format. Moreover, OMR reader API allows capturing human-marked data from documents of different sources like questionnaires, surveys, MCQ papers and more. API recognizes scanned images and even photos from all these sources with high accuracy.

<p align="center">

  <a title="Download complete Aspose.Page for .NET source code" href="https://github.com/aspose-omr/Aspose.OMR-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

The repository contains sample applications that demonstrate how to perform common OMR tasks with Aspose.OMR for .NET. Our demos run out of the box.

Directory | Description
--------- | -----------
[Aspose.OMR.ConsoleDemo](Aspose.OMR.ConsoleDemo)  | A collection of .NET examples that help you learn and explore the API features
[Aspose.OMR.GuiDemo](Aspose.OMR.GuiDemo)  | A demonstration of Aspose.OMR graphical control.
[TestData](TestData)  | The test files used in the examples.
[Demos](Demos)  | Source code for the live demos hosted at https://products.aspose.app/omr/family.


## OMR Features

- [Extract human marked data from images](https://docs.aspose.com/omr/net/perform-omr-on-images/).
- Process rotated and perspective (side viewed) images.
- Recognize data from tests, exams, questionnaires, surveys etc.
- High accuracy rate & ability to export the results in CSV format.
- [Create OMR templates](https://docs.aspose.com/omr/net/create-omr-template/) from text markup.

## Save OMR Results As

CSV, XML, JSON

## Read Images for OMR

JPEG, PNG, GIF, TIFF, BMP

## Platform Independence

Aspose.OMR for .NET API is written in C# and can be used to build 32-bit and 64-bit applications targeting .NET Framework 4.0 and higher.

## Get Started with Aspose.OMR for .NET

Are you ready to give Aspose.OMR for .NET a try? Simply execute `Install-Package Aspose.OMR` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.OMR for .NET and want to upgrade the version, please execute `Update-Package Aspose.OMR` to get the latest version.

## Perform OMR on a JPG Image & Get Results in a CSV

```csharp
string TemplateName = "Sheet.omr";
string[] UserImages = 
new string[] { "Sheet1.jpg", "Sheet2.jpg" };

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

    File.WriteAllText(Path.Combine(outputPath, UserImages[i] + ".csv"), csvResult);
    Console.WriteLine("Result exported. Path: " + Path.Combine(outputPath, UserImages[i] + ".csv"));
}
Console.WriteLine("PerformOMROnImages executed successfully.\n\r");
```

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/omr/net) | [Docs](https://docs.aspose.com/omr/net/) | [Demos](https://products.aspose.app/omr/family) | [API Reference](https://apireference.aspose.com/omr/net) | [Examples](https://github.com/aspose-omr/Aspose.OMR-for-.NET) | [Blog](https://blog.aspose.com/category/omr/) | [Search](https://search.aspose.com/) | [Free Support](https://forum.aspose.com/c/omr) |  [Temporary License](https://purchase.aspose.com/temporary-license)
