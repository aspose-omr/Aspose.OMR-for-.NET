using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.OMR.Live.Demos.UI.Resources;

namespace Aspose.OMR.Live.Demos.UI.Models
{
	public class OmrOtherAppsViewModel
	{
		public string Product { get; set; }
		public string AppName { get; set; }
		public List<OmrApp> OtherApps { get; set; }

		#region OMR
		private static List<OmrApp> OmrOtherApps => new List<OmrApp>
		{
			new OmrApp(AppStrings.OMRCreateAnswerSheetShortName, AppStrings.OMRCreateAnswerSheetAppNameRef),
			new OmrApp(AppStrings.OMRCreateSurveyAppName, AppStrings.OMRCreateSurveyAppNameRef),
			new OmrApp(AppStrings.OMRCreateTestAppName, AppStrings.OMRCreateTestAppNameRef),

			new OmrApp(AppStrings.OMRScanAnswerSheetShortName, AppStrings.OMRScanAnswerSheetAppNameRef),
			new OmrApp(AppStrings.OMRScanSurveyAppName, AppStrings.OMRScanSurveyAppNameRef),
			new OmrApp(AppStrings.OMRScanTestAppName, AppStrings.OMRScanTestAppNameRef),

			new OmrApp(AppStrings.OMRGradeCalculatorPanelAppName, AppStrings.OMRGradeCalculatorAppNameRef)
		};

		public static OmrOtherAppsViewModel OmrScan => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanAppName,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrScanAnswerSheet => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanAnswerSheetAppNameRef,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrScanSurvey => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanSurveyAppNameRef,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrScanTest => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRScanTestAppNameRef,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrCreate => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateAppName,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrCreateAnswerSheet => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateAnswerSheetAppNameRef,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrCreateSurvey => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateSurveyAppNameRef,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrCreateTest => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRCreateTestAppNameRef,
			OtherApps = OmrOtherApps
		};

		public static OmrOtherAppsViewModel OmrGradeCalculator => new OmrOtherAppsViewModel
		{
			Product = AppStrings.OMRProductName,
			AppName = AppStrings.OMRGradeCalculatorAppNameRef,
			OtherApps = OmrOtherApps
		};

		#endregion
	}
}
