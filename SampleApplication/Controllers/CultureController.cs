using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SampleApplication.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Languages = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "-select-", Value = "-1", Selected = true },
                new SelectListItem() { Text = "English", Value = "en" },
                new SelectListItem() { Text = "France", Value = "fr" },
                new SelectListItem() { Text = "Spain", Value = "es" },
                new SelectListItem() { Text = "Germany", Value = "de" },
                new SelectListItem() { Text = "Japan", Value = "ja" }
            };
            return View();
        }

        
        [ActionName("Change")]
        public ActionResult ChangeCulture(string lang)
        {
            int numberToDisplay = 12566;
            double percent = 6.44;
            
            var cul = string.IsNullOrEmpty(lang) ? "en-US" : System.Globalization.CultureInfo.CreateSpecificCulture(lang).Name;

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cul);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cul);

            ViewBag.Number = numberToDisplay.ToString("N", CultureInfo.CurrentCulture);
            ViewBag.Percent = percent.ToString("P", CultureInfo.CurrentCulture);
            ViewBag.Currency = numberToDisplay.ToString("C", CultureInfo.CurrentCulture);
            ViewBag.DateNow = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            ViewBag.EnglishName = Thread.CurrentThread.CurrentCulture.EnglishName;
            ViewBag.NativeName = Thread.CurrentThread.CurrentCulture.NativeName;
            ViewBag.Message = "";
            ViewBag.Languages = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "English", Value = "en" },
                new SelectListItem() { Text = "France", Value = "fr" },
                new SelectListItem() { Text = "Spain", Value = "es" },
                new SelectListItem() { Text = "Germany", Value = "de" },
                new SelectListItem() { Text = "Japan", Value = "ja" }
            };
            return View("Change");
        }

        [ActionName("CultureData")]
        public ActionResult GetCultureData(string lang)
        {
            int numberToDisplay = 12566;
            double percent = 6.44;

            var cul = string.IsNullOrEmpty(lang) ? "en-US" : System.Globalization.CultureInfo.CreateSpecificCulture(lang).Name;

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cul);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cul);

            ViewBag.Number = numberToDisplay.ToString("N", CultureInfo.CurrentCulture);
            ViewBag.Percent = percent.ToString("P", CultureInfo.CurrentCulture);
            ViewBag.Currency = numberToDisplay.ToString("C", CultureInfo.CurrentCulture);
            ViewBag.DateNow = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
            ViewBag.Message = "";
            ViewBag.Languages = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "English", Value = "en" },
                new SelectListItem() { Text = "France", Value = "fr" },
                new SelectListItem() { Text = "Spain", Value = "es" },
                new SelectListItem() { Text = "Germany", Value = "de" },
                new SelectListItem() { Text = "Japan", Value = "ja" }
            };
            var modelObj = new
            {
            Number = numberToDisplay.ToString("N", CultureInfo.CurrentCulture),
            Percent = percent.ToString("P", CultureInfo.CurrentCulture),
            Currency = numberToDisplay.ToString("C", CultureInfo.CurrentCulture),
            DateNow = DateTime.Now.ToString("D", CultureInfo.CurrentCulture),
            Message = ""
        };
            return PartialView(modelObj);
        }

    }
}