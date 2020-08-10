---
title: How to Run the Examples
type: docs
weight: 70
url: /net/how-to-run-the-examples/
---

## **Software Requirements**
Please make sure you meet the following requirements before downloading and running the examples.

1. Visual Studio 2015 or higher
1. NuGet Package Manager installed in Visual Studio. It is mostly already installed in Visual Studio 2015. For details on how to install NuGet package manager please check: [Installing NuGet client tools](https://docs.microsoft.com/en-us/nuget/guides/install-nuget)
1. Go to Tools->Options->NuGet Package Manager->Package Sources and make sure that the option **nuget.org** is checked
1. The example project uses NuGet Automatic Package Restore feature, therefore, you should have an active internet connection. If you do not have an active internet connection on the machine where examples are to be executed please check [Installation](/omr/net/installation-html/) and manually add a reference to Aspose.OMR.dll in the example project.
## **Download from GitHub**
All examples of Aspose.OMR for .NET are hosted on [GitHub](https://github.com/aspose-omr/Aspose.OMR-for-.NET).
## **Aspose.OMR Examples**
- You can either clone the repository using your favorite GitHub client or download the ZIP file from [here](https://github.com/aspose-cells/Aspose.Cells-for-.NET/archive/master.zip).
- Extract the contents of the ZIP file to any folder on your computer. 
- Console examples are located in Aspose.OMR.ConsoleDemo folder and Graphical Control examples are located in Aspose.OMR.GuiDemo folder.
- There is a Visual Studio solution file for the Examples i.e. **Aspose.OMR.Demos.sln**.
- Open the solution file in Visual Studio and set the appropriate project as the startup project.
- On the first run, the dependencies will automatically be downloaded via NuGet. You may also download the DLLs separately from [here](https://downloads.aspose.com/omr/net).
- **TestData** folder at the root contains input files which are used in the examples. It is mandatory that you download the **TestData** folder along with the examples project.
