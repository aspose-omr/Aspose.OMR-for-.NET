# Aspose.OMR for .NET

Aspose.OMR for .NET is an optical marks recognition API to recognize optical marks from multiple image formats including JPG, BMP, GIF, TIF, TIFF. After performing OMR operation on these images, API saves the output in CSV format. Moreover, OMR reader API allows capturing human-marked data from documents of different sources like questionnaires, surveys, MCQ papers and more. API recognizes scanned images and even photos from all these sources with high accuracy.

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
[Demos](Demos)  | Aspose.OMR for .NET Live Demos Source Code
[TestData](TestData)  | The test files used in the examples

# .NET API to Perform OMR

It is a standalone on-premise API that helps in [recognizing the human-marked data](https://docs.aspose.com/display/omrnet/Perform+OMR+on+Images) from images of scanned documents, surveys, questionnaires, quizzes and examination papers.

[Aspose.OMR for .NET](https://products.aspose.com/omr/net) not only acts as an Optical Mark Recognition engine. It also provides a handy [graphical control](https://docs.aspose.com/display/omrnet/Working+with+Graphical+Control) which can be used for manual tuning of the threshold and markup to see changes in the real-time.

## OMR API Features

- [Recognition of scanned images](https://docs.aspose.com/display/omrnet/Perform+OMR+on+Images) and photos.
- Ability to process rotated and perspective (side viewed) images.
- Recognize data from tests, exams, questionnaires, surveys etc.
- High accuracy rate & ability to export the results in CSV format.
- [Create OMR templates](https://docs.aspose.com/display/omrnet/Create+OMR+Template) from text markup.

## Save OMR Results As

CSV, XML, JSON

## Read Images for OMR

JPEG, PNG, GIF, TIFF, BMP

## Platform Independence

Aspose.OMR for .NET API is written in C# and can be used to build 32-bit and 64-bit applications targeting .NET Framework 4.0 and higher.

## Getting Started with Aspose.OMR for .NET

Are you ready to give Aspose.OMR for .NET a try? Simply execute `Install-Package Aspose.OMR` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.OMR for .NET and want to upgrade the version, please execute `Update-Package Aspose.OMR` to get the latest version.

Simply execute the below code snippet to see how Aspose.OMR API performs in your environment or check the [GitHub Repository](https://github.com/aspose-omr/Aspose.OMR-for-.NET) for other common usage scenarios. 

## Perform OMR on a JPG Image & Get Results in the CSV format

```csharp
// recognize image and receive result
RecognitionResult result = templateProcessor.RecognizeImage(dir + "template.jpg");
// export results as a CSV string
string csvResult = result.GetCsv();
```

[Product Page](https://products.aspose.com/omr/net) | [Docs](https://docs.aspose.com/display/omrnet/Home) | [Demos](https://products.aspose.app/omr/family) | [API Reference](https://apireference.aspose.com/omr/net) | [Examples](https://github.com/aspose-omr/Aspose.OMR-for-.NET) | [Blog](https://blog.aspose.com/category/omr/) | [Free Support](https://forum.aspose.com/c/omr) |  [Temporary License](https://purchase.aspose.com/temporary-license)
