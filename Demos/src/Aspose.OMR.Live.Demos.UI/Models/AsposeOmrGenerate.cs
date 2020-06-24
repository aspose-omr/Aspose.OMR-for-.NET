using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Aspose.OMR.Api;
using Aspose.OMR.Generation;


namespace Aspose.OMR.Live.Demos.UI.Models
{
	/// <summary>
	/// Controller for OMR Generate method
	/// </summary>
    public class AsposeOmrGenerate : AsposeOMRBase
	{
		/// <summary>
		/// Action delegate for omr generate method
		/// </summary>
		/// <param name="folderPath"></param>
		/// <param name="fileName"></param>
		protected delegate void OmrGenerateActionDelegate(string folderPath, string fileName);

		/// <summary>
		/// Fixed extension of output image file
		/// </summary>
		private readonly string fixedOutExtension = "png";

		/// <summary>
		/// PDF file extension for output pdf files
		/// </summary>
		private readonly string pdfExtension = "pdf";
		
		///<Summary>
		/// GenerateOmrTemplate method to generate template
		///</Summary>
		
		public Response GenerateOmrTemplate(string templateType, string outputFormat, int questionsNumber)
		{
			return  ProcessTask(templateType, outputFormat, "GenerateOmrTemplate", delegate (string folder, string fileName)
			{
				OmrEngine engine = new OmrEngine();

				string markupPath = ParseTemplateType(templateType, questionsNumber);
				string[] icons = new string[1];
				icons[0] = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/omr/") + "logo.png";

				GenerationResult result = engine.GenerateTemplate(markupPath, icons);

				if (outputFormat.ToLowerInvariant() == fixedOutExtension)
				{
					result.TemplateImage.Save(folder + fileName);
				}
				else if(outputFormat.ToLowerInvariant() == pdfExtension)
				{
					fileName = Path.GetFileNameWithoutExtension(fileName);
					result.SaveAsPdf(folder, fileName);
				}
			});
		}

		private string ParseTemplateType(string templateType, int questionsNumber)
		{
			string markupPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/omr/");
			switch (templateType.ToLowerInvariant())
			{
				case "sheet":
				{
					if (questionsNumber > 0)
					{
						switch (questionsNumber)
						{
							case 60:
							{
								markupPath += "Sheet60.txt";
								break;
							}
							case 100:
							{
								markupPath += "Sheet100.txt";
								break;
							}
							case 150:
							{
								markupPath += "Sheet150.txt";
								break;
							}
							case 200:
							{
								markupPath += "Sheet200.txt";
								break;
							}
						}
					}
					else
					{
						markupPath += "Sheet100.txt";
					}

					break;
				}
				case "survey":
				{
					markupPath += "Survey.txt";
					break;
				}
				case "test":
				{
					markupPath += "Test.txt";
					break;
				}
			}

			return markupPath;
		}

		private Response ProcessTask(string templateType, string outputFormat,  string methodName, OmrGenerateActionDelegate action)
		{
			License.SetAsposeOMRLicense();
			return  Process(templateType, outputFormat, methodName, action);
		}

		///<Summary>
		/// Process
		///</Summary>
		protected Response Process(string templateType, string outputFormat,  string methodName, OmrGenerateActionDelegate action)
		{
			string guid = Guid.NewGuid().ToString();

			string extension = "." + outputFormat.ToLowerInvariant();
			string outfileName = guid + extension;

			string statusValue = "OK";
			int statusCodeValue = 200;

			try
			{
				action(Config.Configuration.OutputDirectory, outfileName);

				
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
