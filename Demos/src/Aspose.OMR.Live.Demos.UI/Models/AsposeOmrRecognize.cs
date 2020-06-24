using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.OMR.Api;
using Aspose.OMR.Model;

namespace Aspose.OMR.Live.Demos.UI.Models
{
	/// <summary>
	/// Controller for OMR Recognize method
	/// </summary>
	public class AsposeOmrRecognize : AsposeOMRBase
	{
		private string omrText = "";
		private Response response;

		private readonly string csvExtension = ".csv";
		private readonly string jsonExtension = ".json";

		/// <summary>
		/// Action delegate for the Recognize method
		/// </summary>
		/// <param name="outPath"></param>
		/// <param name="barcodeType"></param>
		protected delegate void OmrRecognizeActionDelegate(string outPath, string barcodeType);


		///<Summary>
		/// RecognizeOmrImage method to recognize omr images
		///</Summary>
	
		public Response RecognizeOmrImage(string templateType, string outputFormat, int questionsNumber, string fileName, string folderName)
		{
			response =  ProcessTask(fileName, folderName, outputFormat,  "RecognizeOmrImage", delegate (string inFilePath, string outPath)
			{
				string templatePath = ParseTemplateType(templateType, questionsNumber);

				OmrEngine engine = new OmrEngine();
				TemplateProcessor templateProcessor = engine.GetTemplateProcessor(templatePath);
				RecognitionResult recognitionRes = templateProcessor.RecognizeImage(inFilePath);

				if (outputFormat.ToLowerInvariant() == "csv")
				{
					omrText = recognitionRes.GetCsv();
				}
				else if (outputFormat.ToLowerInvariant() == "json")
				{
					omrText = recognitionRes.GetJson();
				}

				using (StreamWriter writer = new StreamWriter(outPath))
				{
					writer.Write(omrText);
				}
			});

			response.Text = omrText;

			return response;
		}

		private string ParseTemplateType(string templateType, int questionsNumber)
		{
			string templatePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/omr/");

			if (templateType.ToLowerInvariant() == "sheet")
			{
				switch (questionsNumber)
				{
					case 60:
					{
						templatePath += "Sheet60.omr";
						break;
					}
					case 100:
					{
						templatePath += "Sheet100.omr";
						break;
					}
					case 150:
					{
						templatePath += "Sheet150.omr";
						break;
					}
					case 200:
					{
						templatePath += "Sheet200.omr";
						break;
					}
				}
			}
			else if (templateType.ToLowerInvariant() == "survey")
			{
				templatePath += "survey.omr";
			}
			else if (templateType.ToLowerInvariant() == "test")
			{
				templatePath += "test.omr";
			}

			return templatePath;
		}

		private Response ProcessTask(string fileName, string folderName,  string outputFormat, string methodName, OmrRecognizeActionDelegate action)
		{
			License.SetAsposeOMRLicense();
			return  Process(this.GetType().Name, fileName, outputFormat, folderName, methodName, action);
		}

		protected Response Process(string className, string fileName, string outputFormat, string folderName,  string methodName, OmrRecognizeActionDelegate action)
		{
			

			string sourceFolder = Config.Configuration.WorkingDirectory + folderName;
			string tempFile = fileName;
			fileName = sourceFolder + "/" + fileName;

			string guid = Guid.NewGuid().ToString();

			string outFileExtension = "";
			switch (outputFormat.ToLowerInvariant())
			{
				case "csv":
				{
					outFileExtension = csvExtension;
					break;
				}
				case "json":
				{
					outFileExtension = jsonExtension;
					break;
				}
				default:
				{
					outFileExtension = csvExtension;
					break;
				}
			}

			string outfileName = guid + outFileExtension;
			string outPath = Config.Configuration.OutputDirectory + outfileName;

			string statusValue = "OK";
			int statusCodeValue = 200;

			try
			{
				action(fileName, outPath);

				
			}
			catch (Exception ex)
			{
				statusCodeValue = 500;
				statusValue = "500 " + ex.Message;
				outfileName = "";
				
			}

			return new Response
			{
				FileName = outfileName,
				Status = statusValue,
				StatusCode = statusCodeValue,
			};
		}
	}
}
