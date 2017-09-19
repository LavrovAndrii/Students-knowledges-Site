using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROZKLAD.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autorization()
        {
            ViewBag.Message = "Autorization page.";

            return View();
        }

        public ActionResult Autorization1()
        {
            ViewBag.Message = "Autorization page.";

            return View();
        }
    }
}