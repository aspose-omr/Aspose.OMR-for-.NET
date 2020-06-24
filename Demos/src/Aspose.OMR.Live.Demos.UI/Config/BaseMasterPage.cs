using Aspose.OMR.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Aspose.OMR.Live.Demos.UI.Config
{
    public class BaseMasterPage : MasterPage
    {
        private AsposeOMRContext _atContext;

        /// <summary>
        /// Main context object to access all the SybContent specific context info
        /// </summary>
        public AsposeOMRContext AsposeOMRContext
		{
            get
            {
                if (_atContext == null) _atContext = new AsposeOMRContext(HttpContext.Current);
                return _atContext;
            }
        }

		private Dictionary<string, string> _resources;

		/// <summary>
		/// key/value pair containing all the error messages defined in resources.xml file
		/// </summary>
		public Dictionary<string, string> Resources
		{
			get
			{
				if (_resources == null) _resources = AsposeOMRContext.Resources;
				return _resources;
			}
		}

		protected override void OnLoad(EventArgs e)
        {
			// Sync the central context store with the first loaded context for this page
			AsposeOMRContext.atcc = AsposeOMRContext;
            base.OnLoad(e);
        }
    }
}
