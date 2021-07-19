using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace Helper.Controllers
{
    public class DonersController : Controller
    {
        // GET: Doners
        private ApplicationDbContext DonersDB;
        public DonersController()
        {
            DonersDB = new ApplicationDbContext();
        }
        public ActionResult Doners()
        {
            var Doners = DonersDB.Doners.ToList();
            return View(Doners);
        }

        public ActionResult New()
        {
            var newDoners = new Doners();
            return View("New", newDoners);
        }

        [HttpPost]
        public ActionResult Save(Doners Doners)
        {
            if (!ModelState.IsValid)   //validation
            {
                var d = new Doners
                {
                    Name = Doners.Name,
                    Phone = Doners.Phone,
                    Location = Doners.Location,
                    NoOfOxgen = Doners.NoOfOxgen,
                };
                return View("New", d);
            }
            DonersDB.Doners.Add(Doners);
               DonersDB.SaveChanges();
            return RedirectToAction("Doners", "Doners");
        }

        public ActionResult Edit(int id)
        {
            var doners = DonersDB.Doners.SingleOrDefault(c => c.id == id);
            if (doners == null)
            {
                return HttpNotFound();
            }
            Doners d = doners;
            return View("newEdit", d);
        }

        public ActionResult SaveEdit(Doners doners)
        {
            var don = DonersDB.Doners.Single(m => m.id == doners.id);
            don.Name = doners.Name;
            don.Phone = doners.Phone;
            don.Location = doners.Location;
            don.NoOfOxgen = doners.NoOfOxgen;
            don.Email = doners.Email;
            DonersDB.SaveChanges();
            return RedirectToAction("Doners", "Doners");
        }

        public ActionResult newEdit()
        {
            var editDoners = new Doners();
            return View("newEdit", editDoners);
        }

        public ActionResult Delete(int id)
        {
            var d = DonersDB.Doners.SingleOrDefault(c => c.id == id);
            if (d == null)
                return HttpNotFound();
            return View (d);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult SaveDelete(int id)
        {
            var d = DonersDB.Doners.Find(id);
            DonersDB.Doners.Remove(d);
            DonersDB.SaveChanges();
            return RedirectToAction("Doners", "Doners");
        }

        public ActionResult Done(int id)
        {
            var d = DonersDB.Doners.SingleOrDefault(c => c.id == id);
            if (d == null)
                return HttpNotFound();
            return View(d);
        }

        [HttpPost, ActionName("Done")]
        public ActionResult SaveDone(int id, int submitId)
        {
            var d = DonersDB.Doners.Find(id);
            ViewBag.c = d.NoOfOxgen;
            if (d.NoOfOxgen.Equals(1))
                d.NoOfOxgen = 111111;
            else
                d.NoOfOxgen -= 1;

            var submit = DonersDB.Submit.Find(submitId);
            submit.done = true;

            DonersDB.SaveChanges();

            return RedirectToAction("Doners", "Doners");
        }
    }
}