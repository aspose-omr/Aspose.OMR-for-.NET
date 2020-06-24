using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.OMR.Live.Demos.UI.Resources;

namespace Aspose.OMR.Live.Demos.UI.Models
{
	public class OMRGradeCalculatorViewModel : OMRViewModelBase
	{
		public List<string> GradingScales;

		public OMRGradeCalculatorViewModel()
		{
			this.JsonLd = base.InitBreadcrumbList(AppStrings.OMRGradeCalculatorAppNameRef);
			this.JsonHowto = base.PrepareJsonLdHowTo(AppStrings.OMRGradeCalculatorAppNameRef);
			this.JsonFaq = base.InitJsonFaq(AppStrings.OMRGradeCalculatorAppNameRef);

			InitGradingScales();
		}

		private void InitGradingScales()
		{
			this.GradingScales = new List<string>();
			this.GradingScales.Add("Standard");
			this.GradingScales.Add("Extended");
		}
	}
}
