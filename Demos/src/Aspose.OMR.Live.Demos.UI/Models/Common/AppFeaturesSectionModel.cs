using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.OMR.Live.Demos.UI.Resources;
using Aspose.OMR.Live.Demos.UI.Services;

namespace Aspose.OMR.Live.Demos.UI.Models.Common
{
	public class AppFeaturesSectionModel
	{
		public string Anchor { get; set; } = "features";

		public string Product { get; set; }
		public string ProductFullName { get; set; }

		public string Feature1 { get; set; }
		public string Feature1Description { get; set; }
		public string Feature2 { get; set; }
		public string Feature2Description { get; set; }
		public string Feature3 { get; set; }
		public string Feature3Description { get; set; }

		
		
		#region OMR
		public static AppFeaturesSectionModel OMRScan => new AppFeaturesSectionModel
		{
			Product = AppStrings.OMRProductName,
			ProductFullName = AppStrings.OMRProductFullName,
			Feature1 = AppStrings.OMRScanFeaturesSectionFeature1,
			Feature1Description = AppStrings.OMRScanFeaturesSectionFeature1Description,
			Feature2 = AppStrings.OMRScanFeaturesSectionFeature2,
			Feature2Description = AppStrings.OMRScanFeaturesSectionFeature2Description,
			Feature3 = AppStrings.OMRScanFeaturesSectionFeature3,
			Feature3Description = AppStrings.OMRScanFeaturesSectionFeature3Description
		};

		public static AppFeaturesSectionModel OMRCreate => new AppFeaturesSectionModel
		{
			Product = AppStrings.OMRProductName,
			ProductFullName = AppStrings.OMRProductFullName,
			Feature1 = AppStrings.OMRCreateFeaturesSectionFeature1,
			Feature1Description = AppStrings.OMRCreateFeaturesSectionFeature1Description,
			Feature2 = AppStrings.OMRCreateFeaturesSectionFeature2,
			Feature2Description = AppStrings.OMRCreateFeaturesSectionFeature2Description,
			Feature3 = AppStrings.OMRCreateFeaturesSectionFeature3,
			Feature3Description = AppStrings.OMRCreateFeaturesSectionFeature3Description
		};

		public static AppFeaturesSectionModel OMRGradeCalculator => new AppFeaturesSectionModel
		{
			Product = AppStrings.OMRProductName,
			ProductFullName = AppStrings.OMRProductFullName,
			Feature1 = AppStrings.OMRGradeCalculatorFeaturesSectionFeature1,
			Feature1Description = AppStrings.OMRGradeCalculatorFeaturesSectionFeature1Description,
			Feature2 = AppStrings.OMRGradeCalculatorFeaturesSectionFeature2,
			Feature2Description = AppStrings.OMRGradeCalculatorFeaturesSectionFeature2Description,
			Feature3 = AppStrings.OMRGradeCalculatorFeaturesSectionFeature3,
			Feature3Description = AppStrings.OMRCreateFeaturesSectionFeature3Description
		};
		#endregion OMR

	}
}
