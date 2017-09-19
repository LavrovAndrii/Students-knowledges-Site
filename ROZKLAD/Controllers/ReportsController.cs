using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using ROZKLAD.Models;
using ROZKLAD.Models.DbEntities;

namespace ROZKLAD.Controllers
{
    public class ReportsController : Controller
    {
        //// GET: Analityc
        //public ActionResult PopularSuppliers()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var allPopularSuppliers = context.Suppliers.Select(a => new ViewModel
        //        {
        //            Id = a.Id,
        //            Name = a.CompanyName,
        //            Count = a.Details.SelectMany(c => c.DetailTasks).Select(b => b.Task).Count()
        //        });

        //    return View(allPopularSuppliers.OrderByDescending(a=>a.Count).ToList());

        //    }
        //}


        private DatabaseContext db = new DatabaseContext();

        // GET: Ocinkas
        public ActionResult bestMarks()
        {
            var ocinkas = db.Ocinkas.Where(a=>a.Mark == 5);
            return View(ocinkas.ToList());
        }

    }
}
