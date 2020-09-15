using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OhmValueCalc.Models;


namespace OhmValueCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ResistorModel resistor)
        {
            // colors are now CSS values

            string v1 = resistor.bandAColor;
            string v2 = resistor.bandBColor;
            string v3 = resistor.bandCColor;
            string v4 = resistor.bandDColor;

            ViewBag.ResistorOhms = "0 ohms";           // first setting
            ViewBag.ResistorTolerance = "0% tolerance";

            if (v1 != null)
            {
                // may need to convert to string on exit
                ViewBag.ResistorOhms = 
                    ResistorModel.CalculateOhmValue(v1, v2, v3, v4);
                ViewBag.ResistorTolerance =
                    ResistorModel.CalculateToleranceValue(v1, v2, v3, v4);

                // how refresh the text boxes with background colors?
                ViewBag.vb_BandA_Color = resistor.bandAColor;
                ViewBag.vb_BandB_Color = resistor.bandBColor;
                ViewBag.vb_BandC_Color = resistor.bandCColor;
                ViewBag.vb_BandD_Color = resistor.bandDColor;

            }
            else
            {

                ViewBag.vb_BandA_Color = "white";
                ViewBag.vb_BandB_Color = "white";
                ViewBag.vb_BandC_Color = "white";
                ViewBag.vb_BandD_Color = "white";

            }

            return View();          // refresh is done here
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}