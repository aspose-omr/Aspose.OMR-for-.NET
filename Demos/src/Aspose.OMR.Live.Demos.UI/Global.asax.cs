using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aspose.OMR.Live.Demos.UI.Config;


namespace Aspose.OMR.Live.Demos.UI
{
	public class Global : HttpApplication
	{
		
		protected void Application_Error(object sender, EventArgs e)
		{			
			
		}

		void Application_Start(object sender, EventArgs e)
		{

			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);			
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			RegisterCustomRoutes(RouteTable.Routes);

		}
		void Session_Start(object sender, EventArgs e)
		{
			//Check URL to set language resource file
			string _language = "EN";
			
			SetResourceFile(_language);
		}

		private void SetResourceFile(string strLanguage)
		{
			if (Session["AsposeOMRResources"] == null)
				Session["AsposeOMRResources"] = new GlobalAppHelper(HttpContext.Current, Application, Configuration.ResourceFileSessionName, strLanguage);
		}

		void RegisterCustomRoutes(RouteCollection routes)
		{
			routes.RouteExistingFiles = true;
			routes.Ignore("{resource}.axd/{*pathInfo}");
					

			routes.MapRoute(
				name: "Default",
				url: "Default",
				defaults: new { controller = "Home", action = "Default" }
			);
			routes.MapRoute(
				"OMRCreateRoute",
				"omr/create",
				new { controller = "omr", action = "create" }
			);
			routes.MapRoute(
				"OMRCreateAnswerSheetRoute",
				"omr/create-answer-sheet",
				new { controller = "omr", action = "CreateAnswerSheet" }
			);
			routes.MapRoute(
				"OMRCreateTestRoute",
				"omr/create-test",
				new { controller = "omr", action = "CreateTest" }
			);
			routes.MapRoute(
				"OMRCreateSurveyRoute",
				"omr/create-survey",
				new { controller = "omr", action = "CreateSurvey" }
			);

			routes.MapRoute(
				"OMRScanRoute",
				"omr/scan",
				new { controller = "omr", action = "scan" }
			);
			routes.MapRoute(
				"OMRScanAnswerSheetRoute",
				"omr/scan-answer-sheet",
				new { controller = "omr", action = "ScanAnswerSheet" }
			);
			routes.MapRoute(
				"OMRScanSurveyRoute",
				"omr/scan-survey",
				new { controller = "omr", action = "ScanSurvey" }
			);
			routes.MapRoute(
				"OMRScanTestRoute",
				"omr/scan-test",
				new { controller = "omr", action = "ScanTest" }
			);

			routes.MapRoute(
				"OMRRecognizeRoute",
				"omr/recognize",
				new { controller = "omr", action = "Recognize" }
			);
			routes.MapRoute(
				"OMRGenerateRoute",
				"omr/generate",
				new { controller = "omr", action = "Generate" }
			);

			routes.MapRoute(
				"OMRGradeCalculatorRoute",
				"omr/grade-calculator",
				new { controller = "omr", action = "GradeCalculator" }
			);
			routes.MapRoute(
				"DownloadFileRoute",
				"common/download",
				new { controller = "Common", action = "DownloadFile" }
				
				
			);
			
			

		}

		
	}
}
