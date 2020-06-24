using Aspose.OMR.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.OMR.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Free Online Apps to Generate and Recognize OMR Files";
			ViewBag.MetaDescription = "On Premise APIs and free apps for OMR file formats. Generate &amp; recognize your OMR images from anywhere.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
