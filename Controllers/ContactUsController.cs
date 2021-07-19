using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Helper.Controllers
{
    public class ContactUsController : Controller
    {
        ApplicationDbContext context;
        public ContactUsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: ContactUs
        public ActionResult Index()
        {
            return View(context.ContactUs.ToList());
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new ContactUs());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                context.ContactUs.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Success", "ContactUs");
            }
            return View(model);
        }
    }
}