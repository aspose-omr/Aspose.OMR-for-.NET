using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.OMR.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.lic";		
		
		///<Summary>
		/// SetAsposeOMRLicense method to Aspose.OMR License
		///</Summary>
		public static void SetAsposeOMRLicense()
		{
			try
			{

				Aspose.OMR.License lic = new Aspose.OMR.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}	
		
	}
}
