namespace Aspose.OMR.Live.Demos.UI.Models
{
	public class OmrApp
	{
		public string ImageSource { get; set; }
		public string ImageAlt { get; set; }
		public string AppName { get; set; }
		public string AppTitle { get; set; }
		public string Href { get; set; }

		private const string OmrProductName = "omr";

		public OmrApp(string displayName, string appName)
		{
			AppName = appName;
			Href = $"/{OmrProductName}/{appName.ToLower()}";

			ImageSource = $"/img/omr/aspose_{appName.ToLowerInvariant()}-app.png";
			ImageAlt = $"Aspose.OMR {AppName}";
			AppTitle = displayName;
		}
	}
}
