using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Aspose.OMR.Live.Demos.UI.Resources;
using Aspose.OMR.Live.Demos.UI.Models.Common;

namespace Aspose.OMR.Live.Demos.UI.Models
{
	public class OMRTemplateTypePreview
	{
		public string TemplateName { get; set; }
		public string TemplateImgUrl { get; set; }
		public string TypeDescription1 { get; set; }
		public string TypeDescription2 { get; set; }
		public string TypeDescription3 { get; set; }
		public string TypeDescription4 { get; set; }
	}

	public class OMRViewModelBase
	{
		public List<OMRTemplateTypePreview> TemplateTypes { get; set; }
		public string JsonLd { get; set; }
		public string JsonHowto { get; set; }
		public string JsonFaq { get; set; }

		public OMRViewModelBase()
		{
			TemplateTypes = InitTemplateTypes();
		}

		/// <summary>
		/// Init properties containing startup preview images and text description for each type of template 
		/// </summary>
		/// <returns>List of created preview models</returns>
		private List<OMRTemplateTypePreview> InitTemplateTypes()
		{
			var types = new List<OMRTemplateTypePreview>();

			var sheetItem = new OMRTemplateTypePreview();
			sheetItem.TemplateName = "Answer Sheet";
			sheetItem.TemplateImgUrl = "../../img/omr/Sheet100.png";
			sheetItem.TypeDescription1 =  AppStrings.OMRSheetDescription1;
			sheetItem.TypeDescription2 = AppStrings.OMRSheetDescription2;
			sheetItem.TypeDescription3 = AppStrings.OMRSheetDescription3;
			sheetItem.TypeDescription4 = AppStrings.OMRSheetDescription4;
			types.Add(sheetItem);

			var surveyItem = new OMRTemplateTypePreview();
			surveyItem.TemplateName = "Survey";
			surveyItem.TemplateImgUrl = "../../img/omr/Survey.png";
			surveyItem.TypeDescription1 = AppStrings.OMRSurveyDescription1;
			surveyItem.TypeDescription2 = AppStrings.OMRSurveyDescription2;
			surveyItem.TypeDescription3 = AppStrings.OMRSurveyDescription3;
			types.Add(surveyItem);

			var testItem = new OMRTemplateTypePreview();
			testItem.TemplateName = "Test";
			testItem.TemplateImgUrl = "../../img/omr/Test.png";
			testItem.TypeDescription1 = AppStrings.OMRTestDescription1;
			testItem.TypeDescription2 = AppStrings.OMRTestDescription2;
			testItem.TypeDescription3 = AppStrings.OMRTestDescription3;
			types.Add(testItem);

			return types;
		}


		/// <summary>
		/// Build HowTo JSON ld for omr apps 
		/// </summary>
		/// <param name="requestingApp">Title of the requesting app</param>
		/// <returns>JSON string for requesting app</returns>
		protected string PrepareJsonLdHowTo(string requestingApp)
		{
			string howToTitle = string.Empty;
			string howToDescription = string.Empty;
			string supplyTitle = string.Empty;

			// get app specific values
            GetAppSpecificStringsHowto(requestingApp, ref howToTitle, ref howToDescription, ref supplyTitle);
            HowToSectionModel howToModel = GetHowToModel(requestingApp);

			// build main model object
            HowTo howTo = new HowTo(howToTitle, howToDescription, supplyTitle);
            howTo.Image = new ImageObject() { Url = new URL() { Id = "https://www.aspose.com/templates/brand/images/omr/aspose_omr-brand.png" } };
            var steps = new List<HowToStep>();

			// build steps
            for (int j = 0; j < howToModel.HowToLines.Count; j++)
            {
	            var step = new HowToStep
	            {
		            Position = (j + 1).ToString(), Name = howToModel.HowToNames[j].TrimStart(), Text = howToModel.HowToLines[j].TrimStart()
	            };

	            steps.Add(step);
            }

			// serialize
            howTo.Steps = steps.ToArray();

			return JsonConvert.SerializeObject(howTo, Formatting.None,
				new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
		}

		/// <summary>
		/// Build json faq for the requesting app
		/// </summary>
		/// <param name="requestingApp">Title of the requesting app</param>
		/// <returns>JSON string for requesting app</returns>
        protected string InitJsonFaq(string requestingApp)
        {
            string faqName = string.Empty;
            string faqText = string.Empty;
            GetAppSpecificStringsFaq(requestingApp, ref faqName, ref faqText);

			// move content out of text lines to string builder for correct resulting json
            HowToSectionModel howToModel = GetHowToModel(requestingApp);
			StringBuilder sb = new StringBuilder();
			howToModel.HowToLines.ForEach(x => sb.Append(x));

			var resultString = new StringBuilder();
            resultString.Append("{");
            resultString.Append("\"@context\": \"http://schema.org\",");
            resultString.Append("\"@type\": \"FAQPage\",");
            resultString.Append("\"mainEntity\":");
            resultString.Append("{");
            resultString.Append("\"@type\": \"Question\",");

            resultString.Append($"\"name\": \"{faqName} ?\",");
            resultString.Append("\"acceptedAnswer\":");
            resultString.Append("{");
            resultString.Append("\"@type\": \"Answer\",");
            resultString.Append($"\"text\": \"{faqText}\"");
            //resultString.Append($"\"text\": \"{sb.ToString()}\"");

            resultString.Append("}");
            resultString.Append("}");
            resultString.Append("}");

            return resultString.ToString();
        }

        /// <summary>
        /// Form json for all OMR apps
        /// </summary>
        /// <param name="requestingApp">Title of the requesting app</param>
        /// <returns>JSON string for requesting app</returns>
        protected string InitBreadcrumbList(string requestingApp)
		{
			// init app specific string values: name, description and url
			string jsonName = string.Empty;
			string jsonAppUrl = string.Empty;
			string jsonDescription = string.Empty;
			GetAppSpecificStringsBreadcrumbs(requestingApp, ref jsonName, ref jsonAppUrl, ref jsonDescription);

			var resultString = new StringBuilder();
			resultString.Append("{");
			resultString.Append("\"@context\": \"http://schema.org\",");
			resultString.Append("\"@type\": \"WebPage\",");
			resultString.Append($"\"name\": \"{jsonName}\",");
			resultString.Append($"\"url\": \"https://products.aspose.app/omr/{jsonAppUrl}\",");
			resultString.Append($"\"description\": \"{jsonDescription}\",");
			resultString.Append("\"breadcrumb\": {");
			resultString.Append("\"@type\": \"BreadcrumbList\",");

			resultString.Append("\"itemListElement\": [");

			ListItems(resultString, jsonName, jsonAppUrl);

			resultString.Append("]}}");
			return resultString.ToString();
		}

		/// <summary>
		/// Get specific how to strings for the requesting app 
		/// </summary>
		/// <param name="appName">Requesting app</param>
		/// <param name="howToName">Name tag for howto json</param>
		/// <param name="howToDescription">Description tag for howto json</param>
		/// <param name="supplyTitle">Supply text tag for howto json</param>
		private void GetAppSpecificStringsHowto(string appName, ref string howToName, ref string howToDescription,  ref string supplyTitle)
		{
			if (string.IsNullOrEmpty(appName))
			{
				return;
			}

			if (appName.Equals(AppStrings.OMRCreateAnswerSheetAppName))
			{
				howToName = AppStrings.OMRCreateAnswerSheetHowToTitle;
				howToDescription = AppStrings.OMRCreateAnswerSheetHowToDescription;
				supplyTitle = AppStrings.OMRCreateAnswerSheetHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRCreateTestAppName))
			{
				howToName = AppStrings.OMRCreateTestHowToTitle;
				howToDescription = AppStrings.OMRCreateTestHowToDescription;
				supplyTitle = AppStrings.OMRCreateTestHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRCreateSurveyAppName))
			{
				howToName = AppStrings.OMRCreateSurveyHowToTitle;
				howToDescription = AppStrings.OMRCreateSurveyHowToDescription;
				supplyTitle = AppStrings.OMRCreateSurveyHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRScanAnswerSheetAppName))
			{
				howToName = AppStrings.OMRScanAnswerSheetHowToTitle;
				howToDescription = AppStrings.OMRScanAnswerSheetHowToDescription;
				supplyTitle = AppStrings.OMRScanAnswerSheetHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRScanSurveyAppName))
			{
				howToName = AppStrings.OMRScanSurveyHowToTitle;
				howToDescription = AppStrings.OMRScanSurveyHowToDescription;
				supplyTitle = AppStrings.OMRScanSurveyHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRScanTestAppName))
			{
				howToName = AppStrings.OMRScanTestHowToTitle;
				howToDescription = AppStrings.OMRScanTestHowToDescription;
				supplyTitle = AppStrings.OMRScanTestHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRGradeCalculatorAppNameRef))
			{
				howToName = AppStrings.OMRGradeCalculatorHowToTitle;
				howToDescription = AppStrings.OMRGradeCalculatorHowToDescription;
				supplyTitle = AppStrings.OMRGradeCalculatorHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRCreateAppName))
			{
				howToName = AppStrings.OMRCreateHowToTitle;
				howToDescription = AppStrings.OMRCreateHowToDescription;
				supplyTitle = AppStrings.OMRCreateHowToSupplyName;
			}
			else if (appName.Equals(AppStrings.OMRScanAppName))
			{
				howToName = AppStrings.OMRScanHowToTitle;
				howToDescription = AppStrings.OMRScanHowToDescription;
				supplyTitle = AppStrings.OMRScanHowToSupplyName;
			}
		}

		/// <summary>
		/// Get how to section model for requesting app
		/// </summary>
		/// <param name="appName">Requesting app</param>
		/// <returns>HowTo section model</returns>
		private HowToSectionModel GetHowToModel(string appName)
		{
			if (appName.Equals(AppStrings.OMRCreateAnswerSheetAppName))
			{
				return HowToSectionModel.OMRCreateAnswerSheet;
			}
			else if (appName.Equals(AppStrings.OMRCreateTestAppName))
			{
				return HowToSectionModel.OMRCreateTest;
			}
			else if (appName.Equals(AppStrings.OMRCreateSurveyAppName))
			{
				return HowToSectionModel.OMRCreateSurvey;
			}
			else if (appName.Equals(AppStrings.OMRScanAnswerSheetAppName))
			{
				return HowToSectionModel.OMRScanAnswerSheet;
			}
			else if (appName.Equals(AppStrings.OMRScanSurveyAppName))
			{
				return HowToSectionModel.OMRScanSurvey;
			}
			else if (appName.Equals(AppStrings.OMRScanTestAppName))
			{
				return HowToSectionModel.OMRScanTest;
			}
			else if (appName.Equals(AppStrings.OMRGradeCalculatorAppNameRef))
			{
				return HowToSectionModel.OMRGradeCalculator;
			}
			else if (appName.Equals(AppStrings.OMRCreateAppName))
			{
				return HowToSectionModel.OMRCreate;
			}
			else if (appName.Equals(AppStrings.OMRScanAppName))
			{
				return HowToSectionModel.OMRScan;
			}

			return HowToSectionModel.OMRCreateTest;
		}

		/// <summary>
		/// Initialize app specific string values
		/// </summary>
		private void GetAppSpecificStringsBreadcrumbs(string appName, ref string jsonName, ref string jsonAppUrl, ref string jsonDescription)
		{
			if (string.IsNullOrEmpty(appName))
			{
				return;
			}

			if (appName.Equals(AppStrings.OMRCreateAnswerSheetAppName))
			{
				jsonName = AppStrings.OMRCreateAnswerSheetPageTitle;
				jsonAppUrl = AppStrings.OMRCreateAnswerSheetAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRCreateAnswerSheetMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRCreateTestAppName))
			{
				jsonName = AppStrings.OMRCreateTestPageTitle;
				jsonAppUrl = AppStrings.OMRCreateTestAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRCreateTestMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRCreateSurveyAppName))
			{
				jsonName = AppStrings.OMRCreateSurveyPageTitle;
				jsonAppUrl = AppStrings.OMRCreateSurveyAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRCreateSurveyMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRScanAnswerSheetAppName))
			{
				jsonName = AppStrings.OMRScanAnswerSheetPageTitle;
				jsonAppUrl = AppStrings.OMRScanAnswerSheetAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRScanAnswerSheetMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRScanSurveyAppName))
			{
				jsonName = AppStrings.OMRScanSurveyPageTitle;
				jsonAppUrl = AppStrings.OMRScanSurveyAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRScanSurveyMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRScanTestAppName))
			{
				jsonName = AppStrings.OMRScanTestPageTitle;
				jsonAppUrl = AppStrings.OMRScanTestAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRScanTestMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRGradeCalculatorAppNameRef))
			{
				jsonName = AppStrings.OMRGradeCalculatorPageTitle;
				jsonAppUrl = AppStrings.OMRGradeCalculatorAppNameRef.ToLowerInvariant();
				jsonDescription = AppStrings.OMRGradeCalculatorMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRCreateAppName))
			{
				jsonName = AppStrings.OMRCreatePageTitle;
				jsonAppUrl = "create";
				jsonDescription = AppStrings.OMRCreateMetaDescription;
			}
			else if (appName.Equals(AppStrings.OMRScanAppName))
			{
				jsonName = AppStrings.OMRScanPageTitle;
				jsonAppUrl = "scan";
				jsonDescription = AppStrings.OMRScanMetaDescription;
			}
		}

		/// <summary>
		/// Get specific faq strings for the requesting app
		/// </summary>
		/// <param name="appName">Requesting app</param>
		/// <param name="faqName">Name tag for faq json</param>
		/// <param name="faqText">Description tag for faq json</param>
		private void GetAppSpecificStringsFaq(string appName, ref string faqName, ref string faqText)
		{
	        if (string.IsNullOrEmpty(appName))
			{
				return;
			}

			if (appName.Equals(AppStrings.OMRCreateAnswerSheetAppName))
			{
				faqName = AppStrings.OMRCreateAnswerSheetHowToTitle;
				//faqText = AppStrings.OMRCreateAnswerSheetHowToContent;
				faqText =
					"Select the number of questions for the answer sheet.Choose the file format: PNG or PDF." +
					"Click the \\\"Create OMR sheet\\\" button to start generation process." +
					"Click the \\\"Download\\\" button to download the answer sheet." +
					"You can now print OMR sheets and pass them to the respondents. After that use OMR Scan Answer Sheet app to read the filled forms.";
			}
			else if (appName.Equals(AppStrings.OMRCreateTestAppName))
			{
				faqName = AppStrings.OMRCreateTestHowToTitle;
				//faqText = AppStrings.OMRCreateTestHowToContent;
				faqText =
					"Choose the file format: PNG or PDF." +
					"Click the \\\"Create OMR test\\\" button to start creation process." +
					"Click the \\\"Download\\\" button to download the created OMR image." +
					"You can now print OMR test forms and pass them to the respondents. After that use OMR Scan Test app to read the filled forms.";
			}
			else if (appName.Equals(AppStrings.OMRCreateSurveyAppName))
			{
				faqName = AppStrings.OMRCreateSurveyHowToTitle;
				//faqText = AppStrings.OMRCreateSurveyHowToContent;
				faqText =
					"Choose the file format: PNG or PDF." +
					"Click the \\\"Create OMR survey\\\" button to start creation process." +
					"Click the \\\"Download\\\" button to download the created OMR image." +
					"You can now print survey forms and pass them to the respondents. After that use OMR Scan Survey app to read the filled forms.";
			}
			else if (appName.Equals(AppStrings.OMRScanAnswerSheetAppName))
			{
				faqName = AppStrings.OMRScanAnswerSheetHowToTitle;
				//faqText = AppStrings.OMRScanAnswerSheetHowToContent;
				faqText =
					"Click inside the file drop area or use drag&drop to upload photo or scan of filled answer sheet." +
					"Select the number of questions on page." +
					"Choose the output format of the recognition results." +
					"Click the \\\"Scan Answer Sheet\\\" button to start recognition process." +
					"Click the \\\"Download\\\" button to download the recognition results or simply copy them to the clipboard.";
			}
			else if (appName.Equals(AppStrings.OMRScanSurveyAppName))
			{
				faqName = AppStrings.OMRScanSurveyHowToTitle;
				//faqText = AppStrings.OMRScanSurveyHowToContent;
				faqText =
					"Click inside the file drop area or use drag&drop to upload photo or scan of filled OMR survey." +
					"Choose the output format of the recognition results." +
					"Click the \\\"Scan OMR Survey\\\" button to start recognition process." +
					"Click the \\\"Download\\\" button to download the recognition results or simply copy them to the clipboard.";
			}
			else if (appName.Equals(AppStrings.OMRScanTestAppName))
			{
				faqName = AppStrings.OMRScanTestHowToTitle;
				//faqText = AppStrings.OMRScanTestHowToContent;
				faqText =
					"Click inside the file drop area or use drag&drop to upload photo or scan of filled OMR test." +
					"Choose the output format of the recognition results." +
					"Click the \\\"Scan OMR Test\\\" button to start recognition process." +
					"Click the \\\"Download\\\" button to download the recognition results or simply copy them to the clipboard.";
			}
			else if (appName.Equals(AppStrings.OMRGradeCalculatorAppNameRef))
			{
				faqName = AppStrings.OMRGradeCalculatorHowToTitle;
				//faqText = AppStrings.OMRGradeCalculatorContent;
				faqText =
					"Enter the total number of questions in your test, exam or quiz." +
					"Type in the number of wrong answers." +
					"The result, including percentage, fraction and letter score will be calculated and displayed." +
					"Use Quick Chart checkbox to display grade distribution chart." +
					"Use Grade Chart checkbox to display full grade chart for the reference.";
			}
			else if (appName.Equals(AppStrings.OMRCreateAppName))
			{
				faqName = AppStrings.OMRCreateHowToTitle;
				//faqText = AppStrings.OMRCreateHowToContent;
				faqText = "Choose the template type of OMR image you want to create." +
				          "For Answer Sheet you can select the number of questions." +
				          "Choose the file format: PNG or PDF." +
				          "Click the \\\"Create OMR image\\\" button to start creation process." +
				          "Click the \\\"Download\\\" button to download the created OMR image." +
				          "You can now print OMR forms and pass them to the respondents. After that use OMR Scan app to read the filled forms";
			}
			else if (appName.Equals(AppStrings.OMRScanAppName))
			{
				faqName = AppStrings.OMRScanHowToTitle;
				//faqText = AppStrings.OMRScanHowToContent;
				faqText =
					"Click inside the file drop area or use drag&drop to upload photo or scan of filled OMR image." +
					"Select the type of template that was used to create your OMR image in OMR Create app." +
					"For Answer Sheet, choose the number of questions on page." +
					"Select the output format of the recognition results." +
					"Click the \\\"Scan OMR image\\\" button to start recognition process." +
					"Click the \\\"Download\\\" button to download the recognition results or simply copy them to the clipboard.";
			}
		}

		/// <summary>
		/// Add child list item to json
		/// </summary>
		private void ListItems(StringBuilder resultString, string jsonName, string jsonAppUrl)
		{
			resultString.Append("{");
			resultString.Append("\"@type\": \"ListItem\",");
			resultString.Append("\"position\": 1,");

			resultString.Append("\"item\": {");
			resultString.Append("\"@type\": \"WebSite\",");
			resultString.Append("\"@id\": \"https://products.aspose.app\",");
			resultString.Append("\"image\": \"https://cms.admin.containerize.com/templates/aspose/App_Themes/V3/images/aspose-logo.png\",");
			resultString.Append("\"name\": \"Free File Format Apps\"");
			resultString.Append("}");
			resultString.Append("},");
			resultString.Append("{");
			resultString.Append("\"@type\": \"ListItem\",");
			resultString.Append("\"position\": 2,");
			resultString.Append("\"item\": {");
			resultString.Append("\"@type\": \"WebPage\",");
			resultString.Append($"\"name\": \"{jsonName}\",");
			resultString.Append($"\"@id\": \"https://products.aspose.app/omr/{jsonAppUrl}\"");
			resultString.Append("}");
			resultString.Append("}");
		}
	}
}
