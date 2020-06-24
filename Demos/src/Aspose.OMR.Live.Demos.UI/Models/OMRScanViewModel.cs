using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.OMR.Live.Demos.UI.Models
{
	public class OMRScanViewModel : OMRViewModelBase
	{
		public List<string> OutputFormats;
		public List<string> QuestionsNum;

		public OMRScanViewModel(string appName) : base()
		{
			InitOutputFormats();
			InitQuestionNumOptions();

			this.JsonLd = base.InitBreadcrumbList(appName);
			this.JsonHowto = base.PrepareJsonLdHowTo(appName);
			this.JsonFaq = base.InitJsonFaq(appName);
		}

		private void InitQuestionNumOptions()
		{
			QuestionsNum = new List<string>();
			QuestionsNum.Add("60");
			QuestionsNum.Add("100");
			QuestionsNum.Add("150");
			QuestionsNum.Add("200");
		}

		private void InitOutputFormats()
		{
			this.OutputFormats = new List<string>();
			this.OutputFormats.Add("CSV");
			this.OutputFormats.Add("JSON");
		}
	}
}
