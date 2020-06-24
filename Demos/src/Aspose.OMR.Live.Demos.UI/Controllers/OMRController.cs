using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Aspose.OMR.Live.Demos.UI.Config;
using Aspose.OMR.Live.Demos.UI.Services;
using Aspose.OMR.Live.Demos.UI.Helpers;
using Aspose.OMR.Live.Demos.UI.Models;
using Aspose.OMR.Live.Demos.UI.Resources;

namespace Aspose.OMR.Live.Demos.UI.Controllers
{
	public class OmrController : Controller
	{
		public ActionResult Generate()
		{
			return RedirectPermanent("/omr/create");
		}

		public ActionResult Recognize()
		{
			return RedirectPermanent("/omr/scan");
		}

		public ActionResult CreateAnswerSheet()
		{
			return View(new OMRCreateViewModel(AppStrings.OMRCreateAnswerSheetAppName));
		}

		public ActionResult CreateTest()
		{
			return View(new OMRCreateViewModel(AppStrings.OMRCreateTestAppName));
		}

		public ActionResult CreateSurvey()
		{
			return View(new OMRCreateViewModel(AppStrings.OMRCreateSurveyAppName));
		}

		public ActionResult ScanAnswerSheet()
		{
			return View(new OMRScanViewModel(AppStrings.OMRScanAnswerSheetAppName));
		}

		public ActionResult ScanSurvey()
		{
			return View(new OMRScanViewModel(AppStrings.OMRScanSurveyAppName));
		}

		public ActionResult ScanTest()
		{
			return View(new OMRScanViewModel(AppStrings.OMRScanTestAppName));
		}

		public ActionResult GradeCalculator()
		{
			return View(new OMRGradeCalculatorViewModel());
		}

		public ActionResult Create()
		{
			return View(new OMRCreateViewModel(AppStrings.OMRCreateAppName));
		}

		public ActionResult Scan()
		{
			return View(new OMRScanViewModel(AppStrings.OMRScanAppName));
		}

		[HttpPost]
		public ActionResult Create(int templateType, string outputFormat, string questionsNumber)
		{
			if (ValidateOMRGenerateModel())
			{
				try
				{
					string stringType = ParseNumericType(templateType);
					string outputFormatParsed = ParseNumericGenerationOutputFormat(outputFormat);
					int questionsNumberParsed = ParseNumericQuestionsNumber(questionsNumber);
					AsposeOmrGenerate asposeOmrGenerate = new AsposeOmrGenerate();
					var response = asposeOmrGenerate.GenerateOmrTemplate(stringType, outputFormatParsed, questionsNumberParsed);

					if ((response != null) && (response.FileName != ""))
					{
						
							

						var imgBase64 = Convert.ToBase64String( System.IO.File.ReadAllBytes(Config.Configuration.OutputDirectory + response.FileName));

						string url = Config.Configuration.AsposeOMRLiveDemosPath + "common/download?file=" + response.FileName;
						

						return Json(
							new
							{
								success = true,
								imgBase64 = imgBase64,
								url = url
							},
							"application/json",
							Encoding.UTF8,
							JsonRequestBehavior.AllowGet
						);

						
						
					}
					else
					{
						return Json(new { success = false, errorMsg = "Failed to create template" });
					}
				}
				catch (Exception ex)
				{
					return Json(new { success = false, errorMsg = "Failed to create template. Error: " + ex.Message });
				}
			}

			return Json(new { success = false, errorMsg = "Failed to create template. Invalid codetext." });
		}

		[HttpPost]
		public ActionResult Scan(int templateType, string outputFormat, string questionsNumber)
		{
			try
			{
				var files = Request.Files;
				foreach (string fileName in Request.Files)
				{
					HttpPostedFileBase postedFile = Request.Files[fileName];

					if (postedFile != null)
					{
						var isFileUploaded = FileManager.UploadFile(postedFile);

						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{
							string templateTypeParsed = ParseNumericType(templateType);
							string outputFormatParsed = ParseNumericRecognitionOutputFormat(outputFormat);
							int questionsNumberParsed = ParseNumericQuestionsNumber(questionsNumber);

							AsposeOmrRecognize asposeOmrRecognize = new AsposeOmrRecognize();
							var response = asposeOmrRecognize.RecognizeOmrImage(
								templateTypeParsed,
								outputFormatParsed,
								questionsNumberParsed,
								isFileUploaded.FileName,
								isFileUploaded.FolderId);

							if (response == null)
							{
								return Json(new { success = false, errorMsg = AppStrings.APIResponseTime });
							}
							else if (response.StatusCode != 200)
							{
								return Json(new { success = false, errorMsg = response.Status });
							}

							string url = Config.Configuration.AsposeOMRLiveDemosPath + "common/download?file=" + response.FileName;

							return Json(new { success = true, text = response.Text, url = url });
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Json(new { success = false, errorMsg = AppStrings.APIResponseTime });
			}

			return Json(new { success = false, errorMsg = AppStrings.APIResponseTime });
		}

		protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return new JsonResult()
			{
				Data = data,
				ContentType = contentType,
				ContentEncoding = contentEncoding,
				JsonRequestBehavior = behavior,
				MaxJsonLength = Int32.MaxValue
			};
		}

		private string ParseNumericType(int templateType)
		{
			string res = "";
			switch (templateType)
			{
				case 0:
				{
					res = "sheet";
					break;
				}
				case 1:
				{
					res = "survey";
					break;
				}
				case 2:
				{
					res = "test";
					break;
				}
			}

			return res;
		}

		private string ParseNumericRecognitionOutputFormat(string outputFormat)
		{
			string res = "";
			switch (outputFormat.ToLowerInvariant())
			{
				case "1":
				{
					res = "csv";
					break;
				}
				case "2":
				{
					res = "json";
					break;
				}
			}

			return res;
		}

		private string ParseNumericGenerationOutputFormat(string outputFormat)
		{
			string res = "";
			switch (outputFormat.ToLowerInvariant())
			{
				case "1":
				{
					res = "png";
					break;
				}
				case "2":
				{
					res = "pdf";
					break;
				}
			}

			return res;
		}

		private int ParseNumericQuestionsNumber(string outputFormat)
		{
			if (outputFormat == null)
			{
				return 0;
			}

			int res = 100;
			switch (outputFormat.ToLowerInvariant())
			{
				case "1":
				{
					res = 60;
					break;
				}
				case "2":
				{
					res = 100;
					break;
				}
				case "3":
				{
					res = 150;
					break;
				}
				case "4":
				{
					res = 200;
					break;
				}
			}

			return res;
		}

		private bool ValidateOMRGenerateModel()
		{
			return true;
		}
	}
}
