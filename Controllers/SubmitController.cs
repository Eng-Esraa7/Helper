using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Helper.Controllers
{
    public class SubmitController : Controller
    {
        // GET: Submit
        private ApplicationDbContext SubmitDb;
        public SubmitController()
        {
            SubmitDb = new ApplicationDbContext();
        }
        public ActionResult Submit()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Doners = SubmitDb.Doners.ToList(); ;
            return View(new Submit());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Submit model)
        {
            if (ModelState.IsValid)
            {
                SubmitDb.Submit.Add(model);
                await SubmitDb.SaveChangesAsync();
                return RedirectToAction("Submit");
            }
            var d = new Submit
            {
                name = model.name,
                Phone = model.Phone,
            };
            return View("Create", d);
        }

        public ActionResult Notification()
        {
            ViewBag.Doners = SubmitDb.Doners.ToList();
            ViewBag.Submit = SubmitDb.Submit.ToList();
            return View();
        }
    }
}