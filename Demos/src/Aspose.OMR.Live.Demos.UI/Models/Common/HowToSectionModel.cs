using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.OMR.Live.Demos.UI.Resources;

namespace Aspose.OMR.Live.Demos.UI.Models.Common
{
	public class HowToSectionModel
	{
		public string Anchor { get; set; } = "howto";

		public string Title { get; set; }
		public List<string> HowToLines { get; set; }
		public List<string> HowToNames { get; set; }	

		#region OMR
		public static HowToSectionModel OMRCreateAnswerSheet => new HowToSectionModel
		{
			Title = AppStrings.OMRCreateAnswerSheetHowToTitle,
			HowToLines = AppStrings.OMRCreateAnswerSheetHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRCreateAnswerSheetHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
		};

		public static HowToSectionModel OMRCreateSurvey => new HowToSectionModel
		{
			Title = AppStrings.OMRCreateSurveyHowToTitle,
			HowToLines = AppStrings.OMRCreateSurveyHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRCreateSurveyHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
		};

		public static HowToSectionModel OMRCreateTest => new HowToSectionModel
		{
			Title = AppStrings.OMRCreateTestHowToTitle,
			HowToLines = AppStrings.OMRCreateTestHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRCreateTestHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		public static HowToSectionModel OMRScanAnswerSheet => new HowToSectionModel
		{
			Title = AppStrings.OMRScanAnswerSheetHowToTitle,
			HowToLines = AppStrings.OMRScanAnswerSheetHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRScanAnswerSheetHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		public static HowToSectionModel OMRScanSurvey => new HowToSectionModel
		{
			Title = AppStrings.OMRScanSurveyHowToTitle,
			HowToLines = AppStrings.OMRScanSurveyHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRScanSurveyHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		public static HowToSectionModel OMRScanTest => new HowToSectionModel
		{
			Title = AppStrings.OMRScanTestHowToTitle,
			HowToLines = AppStrings.OMRScanTestHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRScanTestHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		public static HowToSectionModel OMRGradeCalculator => new HowToSectionModel
		{
			Title = AppStrings.OMRGradeCalculatorHowToTitle,
			HowToLines = AppStrings.OMRGradeCalculatorContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRGradeCalculatorHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		public static HowToSectionModel OMRCreate => new HowToSectionModel
		{
			Title = AppStrings.OMRCreateHowToTitle,
			HowToLines = AppStrings.OMRCreateHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRCreateHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		public static HowToSectionModel OMRScan => new HowToSectionModel
		{
			Title = AppStrings.OMRScanHowToTitle,
			HowToLines = AppStrings.OMRScanHowToContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList(),
			HowToNames = AppStrings.OMRScanHowToNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList()
		};

		#endregion OMR

		

	}

}
