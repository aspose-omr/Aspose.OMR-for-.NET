using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.OMR.Live.Demos.UI.Resources;
using Aspose.OMR.Live.Demos.UI.Services;

namespace Aspose.OMR.Live.Demos.UI.Models.Common
{
	public class AppProductSectionModel
	{
		public string Anchor { get; set; } = "features";
		public IEnumerable<string> AppFeatures { get; set; }
		public string Product { get; set; }
		public string PageProductTitle { get; set; }
		public string AppName { get; set; }

	

		#region OMR
		public static AppProductSectionModel OMRScanAnswerSheet => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanAnswerSheetAppName,
			PageProductTitle = AppStrings.OMRScanAnswerSheetProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRScanAnswerSheetProductSectionFeature1,
				AppStrings.OMRScanAnswerSheetProductSectionFeature2,
				AppStrings.OMRScanAnswerSheetProductSectionFeature3,
			}
		};

		public static AppProductSectionModel OMRScanSurvey => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanAppName,
			PageProductTitle = AppStrings.OMRScanSurveyProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRScanSurveyProductSectionFeature1,
				AppStrings.OMRScanSurveyProductSectionFeature2,
				AppStrings.OMRScanSurveyProductSectionFeature3,
			}
		};

		public static AppProductSectionModel OMRScanTest => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanAppName,
			PageProductTitle = AppStrings.OMRScanTestProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRScanTestProductSectionFeature1,
				AppStrings.OMRScanTestProductSectionFeature2,
				AppStrings.OMRScanTestProductSectionFeature3,
			}
		};
		public static AppProductSectionModel OMRScan => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanAppName,
			PageProductTitle = AppStrings.OMRScanProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRScanProductSectionFeature1,
				AppStrings.OMRScanProductSectionFeature2,
				AppStrings.OMRScanProductSectionFeature3,
				AppStrings.OMRScanProductSectionFeature4
			}
		};

		public static AppProductSectionModel OMRCreate => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateAppName,
			PageProductTitle = AppStrings.OMRCreateProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRCreateProductSectionFeature1,
				AppStrings.OMRCreateProductSectionFeature2,
				AppStrings.OMRCreateProductSectionFeature3,
				AppStrings.OMRCreateProductSectionFeature4
			}
		};


		public static AppProductSectionModel OMRCreateTest => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateAppName,
			PageProductTitle = AppStrings.OMRCreateTestProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRCreateTestProductSectionFeature1,
				AppStrings.OMRCreateTestProductSectionFeature2,
			}
		};

		public static AppProductSectionModel OMRCreateSurvey => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateSurveyAppName,
			PageProductTitle = AppStrings.OMRCreateSurveyProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRCreateSurveyProductSectionFeature1,
				AppStrings.OMRCreateSurveyProductSectionFeature2,
			}
		};

		public static AppProductSectionModel OMRCreateAnswerSheet => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateAnswerSheetAppName,
			PageProductTitle = AppStrings.OMRCreateAnswerSheetProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRCreateAnswerSheetFeature1,
				AppStrings.OMRCreateAnswerSheetFeature2,
				AppStrings.OMRCreateAnswerSheetFeature3,
			}
		};

		public static AppProductSectionModel OMRGradeCalculator => new AppProductSectionModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRGradeCalculatorAppName,
			PageProductTitle = AppStrings.OMRGradeCalculatorProductSectionTitle,
			AppFeatures = new List<string>
			{
				AppStrings.OMRGradeCalculatorProductSectionFeature1,
				AppStrings.OMRGradeCalculatorProductSectionFeature2,
				AppStrings.OMRGradeCalculatorProductSectionFeature3,
				AppStrings.OMRGradeCalculatorProductSectionFeature4,
			}
		};
		#endregion OMR

	}
}
