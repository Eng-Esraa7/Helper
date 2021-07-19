using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covide19.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult instruction()
        {
            return View();
        }

        public ActionResult instructionArabic()
        {
            return View();
        }

        public ActionResult CommonQ()
        {
            return View();
        }

    }
}