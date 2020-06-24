using System.Collections.Generic;
using System.Web;


namespace Aspose.OMR.Live.Demos.UI.Models
{
	public class SheetQuestionNumOptions
	{
		public string QuestionNumber { get; set; }
		public string ImageUrl { get; set; }

		public SheetQuestionNumOptions(string questionNumber, string imageUrl)
		{
			QuestionNumber = questionNumber;
			ImageUrl = imageUrl;
		}
	}

	public class OMRCreateViewModel : OMRViewModelBase
	{
		public List<string> OutputFormats;
		public List<SheetQuestionNumOptions> SheetOptions;

		/// <summary>
		/// Inits new view model for all create apps
		/// </summary>
		/// <param name="appName">The name of specific create app</param>
		public OMRCreateViewModel(string appName) : base()
		{
			InitOutputFormats();
			InitQuestionNumOptions();

			this.JsonLd = base.InitBreadcrumbList(appName);
			this.JsonHowto = base.PrepareJsonLdHowTo(appName);
			this.JsonFaq = base.InitJsonFaq(appName);
		}

		private void InitQuestionNumOptions()
		{
			SheetOptions = new List<SheetQuestionNumOptions>();
			SheetOptions.Add(new SheetQuestionNumOptions("60", "../../img/omr/Sheet60.png"));
			SheetOptions.Add(new SheetQuestionNumOptions("100", "../../img/omr/Sheet100.png"));
			SheetOptions.Add(new SheetQuestionNumOptions("150", "../../img/omr/Sheet150.png"));
			SheetOptions.Add(new SheetQuestionNumOptions("200", "../../img/omr/Sheet200.png"));
		}

		private void InitOutputFormats()
		{
			this.OutputFormats = new List<string>();
			this.OutputFormats.Add("PNG");
			this.OutputFormats.Add("PDF");
		}
	}
}
