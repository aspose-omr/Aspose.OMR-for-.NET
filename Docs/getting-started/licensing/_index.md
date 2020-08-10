---
title: Licensing
type: docs
weight: 60
url: /net/licensing/
---

## **Evaluation Version Limitations**
We want our customers to test our components thoroughly before buying so the evaluation version allows you to use it as you would normally.

**Limit of the Number of Questions that can be processed** 
The evaluation version (without a license initialization) provides full product functionality, but it has the following limitation: only five questions of any page can be recognized.
## **Apply License using File or Stream Object**
The license can be loaded from a file or stream object. The easiest way to set a license is to put the license file in the same folder as the Aspose.OMR.dll file and specify the file name, without a path, as shown in the example below.

{{% alert color="primary" %}} 

If you use are using any other Aspose for .NET component along with Aspose.OMR for .NET, please specify the namespace for License like *Aspose.OMR.License*.

{{% /alert %}} 
### **Loading a License from File**
The easiest way to apply a license is to put the license file in the same folder as the Aspose.OMR.dll file and specify just the filename without a path.



{{< gist "aspose-com-gists" "9351fac3e25a64343d5920a7770ded08" "Examples-CSharp-GettingStarted-LoadLicenseFromFile-1.cs" >}}

When you call the [SetLicense](https://apireference.aspose.com/net/omr/aspose.omr/license/methods/setlicense/index) method, the license name that you pass should be that of your license file. For example, if you change the license file name to "Aspose.OMR.lic.xml" pass that file name to the [OMR.SetLicense(…)](https://apireference.aspose.com/net/omr/aspose.omr/license/methods/setlicense/index) method. The license file can be specific for Aspose.OMR for .NET or you can use Aspose.Total for .NET license file.
### **Loading a License from a Stream Object**
The following example shows how to load a license from a stream.

{{< gist "aspose-com-gists" "9351fac3e25a64343d5920a7770ded08" "Examples-CSharp-GettingStarted-LoadLicenseFromStreamObject-1.cs" >}}


Using the License as an Embedded Resource

To apply the license, you can load it from file or stream. Another neat way of packaging the license with your application is to include it as an embedded resource into one of the assemblies that call Aspose.ORM for .NET.

To include the file as an embedded resource:

1. In Visual Studio .NET, include the .lic file into the project by clicking the **File** menu and selecting **Add Existing Item**.
1. Select the file in the Solution Explorer.
1. In the Properties window, set the **Build Action** to **Embedded Resource**.



{{< gist "aspose-com-gists" "9351fac3e25a64343d5920a7770ded08" "Examples-CSharp-GettingStarted-SetLicenseUsingEmbeddedResource-1.cs" >}}
