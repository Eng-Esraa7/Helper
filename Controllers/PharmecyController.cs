using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;//include
using Helper.Migrations;

namespace Helper.Controllers
{
    public class PharmecyController : Controller
    {
        // GET: Pharmecy
        private ApplicationDbContext PharmecyDb;

        public PharmecyController()
        {
            PharmecyDb = new ApplicationDbContext();
        }

        public ActionResult Pharmecy()
        {
            var ph = PharmecyDb.pharmecies.ToList();
            return View(ph);
        }

        public ActionResult NewPh()
        {
            var newPh = new Pharmecy();
            return View("NewPh", newPh);
        }

        [HttpPost]
        public ActionResult SavePh(Pharmecy pharmcy)
        {
            if (!ModelState.IsValid)   //validation
            {
                var ph = new Pharmecy
                {
                    Name = pharmcy.Name,
                    Phone = pharmcy.Phone,
                    Location = pharmcy.Location,
                };
                return View("Newph", ph);
            }
            PharmecyDb.pharmecies.Add(pharmcy);
            PharmecyDb.SaveChanges();
            return RedirectToAction("Pharmecy", "Pharmecy");
        }
        public ActionResult Editph(int id)
        {
            var ph = PharmecyDb.pharmecies.SingleOrDefault(c => c.id == id);
            if (ph == null)
            {
                return HttpNotFound();
            }
            Pharmecy p = ph;
            return View("newEditph", p);
        }

        public ActionResult SaveEditph(Pharmecy pharmecy)
        {
            var ph = PharmecyDb.pharmecies.Single(m => m.id == pharmecy.id);
            ph.Name = pharmecy.Name;
            ph.Phone = pharmecy.Phone;
            ph.Location = pharmecy.Location;
            ph.Email = pharmecy.Email;
            PharmecyDb.SaveChanges();
            return RedirectToAction("Pharmecy", "Pharmecy");
        }

        public ActionResult newEditph()
        {
            var editph = new Pharmecy();
            return View("newEditph", editph);
        }
        public ActionResult Deleteph(int id)
        {
            var ph = PharmecyDb.pharmecies.SingleOrDefault(c => c.id == id);
            if (ph == null)
                return HttpNotFound();
            return View(ph);
        }
        [HttpPost, ActionName("Deleteph")]
        public ActionResult SaveDeleteph(int id)
        {
            var ph = PharmecyDb.pharmecies.Find(id);
            PharmecyDb.pharmecies.Remove(ph);
            PharmecyDb.SaveChanges();
            return RedirectToAction("Pharmecy", "Pharmecy");
        }
        //medicines
        public ActionResult Choose(int id , String Searching)
        {
            ViewBag.num = 1;
            var medicine = PharmecyDb.medicines.Where(d => d.pharmecyId == id);
            var ph = PharmecyDb.pharmecies.ToList();
            if (medicine == null)
                return HttpNotFound();
            ViewBag.list = ph;
            ViewBag.Id = id;

            //in cart
            var cart = PharmecyDb.addtoCart;
            ViewBag.cart = cart;
            return View(medicine.Where(x => x.name.StartsWith(Searching) || Searching == null).ToList());
        }

        //add new medicine
        public ActionResult Newm(int idpharmecy)
        {
            ViewBag.Id = idpharmecy;
            var pharmecy = PharmecyDb.pharmecies.ToList();
            var viewmodel = new newModelMedicine
            {
                medicines = new Medicines(),
                pharmecy = pharmecy
            };
            return View("Newm", viewmodel);
        }

        [HttpPost]
        public ActionResult Savem(Medicines medicines)
        {
            if (!ModelState.IsValid)   //validation
            {
                var viewmodel = new newModelMedicine
                {
                    medicines = medicines,
                    
                    pharmecy = PharmecyDb.pharmecies.ToList()
                };
                return View("Newm", viewmodel);
            }
                PharmecyDb.medicines.Add(medicines);
            PharmecyDb.SaveChanges();
            return RedirectToAction("Pharmecy", "Pharmecy");
        }
        //Edit medicine
        public ActionResult Editm(int id)
        {
            var m = PharmecyDb.medicines.SingleOrDefault(c => c.id == id);
            if (m == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new newModelMedicine
            {
                medicines = m,
                pharmecy = PharmecyDb.pharmecies.ToList()
            };
            return View("newEditm", viewmodel);
        }

        public ActionResult SaveEditm(Medicines medicines)
        {
            var m = PharmecyDb.medicines.Single(n => n.id == medicines.id);
            m.name = medicines.name;
            m.price = medicines.price;
            m.NoOfPiece = medicines.NoOfPiece;
            m.pharmecyId = medicines.pharmecyId;
            PharmecyDb.SaveChanges();
            return RedirectToAction("Pharmecy", "Pharmecy");
        }

        public ActionResult newEditm()
        {
            var ph = PharmecyDb.pharmecies.ToList();
            var viewmodel = new newModelMedicine
            {
                medicines = new Medicines(),
                pharmecy = ph
            };
            return View("Newm", viewmodel);
        }
        //delete medicine
        public ActionResult Deletem(int id, int idPharmecy)
        {
            ViewBag.Id = idPharmecy;
            var ph = PharmecyDb.medicines.SingleOrDefault(c => c.id == id);
            if (ph == null)
                return HttpNotFound();
            return View(ph);
        }
        [HttpPost, ActionName("Deletem")]
        public ActionResult SaveDeletem(int id)
        {
            var m = PharmecyDb.medicines.Find(id);
            PharmecyDb.medicines.Remove(m);
            PharmecyDb.SaveChanges();
            return RedirectToAction("Pharmecy", "Choose");
        }

  
        public ActionResult addToCart(int? id, int? idPharmecy) // id of medicine
        {
            //back to same medicine pharmecy
                ViewBag.Id = idPharmecy;
                ViewBag.check_id_medicine_in_cart = false;
            var addToCart = PharmecyDb.addtoCart;
            var medicines = PharmecyDb.medicines;
             if (id != null || idPharmecy != null)
              {
                var medicine = medicines.SingleOrDefault(d => d.id == id);
                var cart = new AddtoCart()
                {
                    UserId = User.Identity.GetUserId(),
                    name = medicine.name,
                    price = (float)medicine.price,
                    noCategory = medicine.noOfCategory,
                    medId = medicine.id
                };

                //check
                foreach(var c in addToCart)
                {
                    if (c.medId == id) {
                        ViewBag.check_id_medicine_in_cart = true;
                            break;
                    }
                }
                medicine.NoOfPiece -= 1;
                medicine.addToCart = true;
                PharmecyDb.addtoCart.Add(cart);
                PharmecyDb.SaveChanges();
            }

            //to view total
            float tot = 0;
            foreach (var d in addToCart)
            {
                if (d.UserId == (String)User.Identity.GetUserId() && d.check==false){
                    tot += (float)d.price;
                }
            }
            ViewBag.total = tot;

            return View(addToCart);
        }
        //delete from cart
        public ActionResult Deletec(int id, int ?idPharmecy)
        {
            ViewBag.Id = idPharmecy;
            var ph = PharmecyDb.addtoCart.SingleOrDefault(c => c.id == id);
            if (ph == null)
                return HttpNotFound();
            return View(ph);
        }
        [HttpPost, ActionName("Deletec")]
        public ActionResult SaveDeletec(int id)
        {
            var m = PharmecyDb.addtoCart.Find(id);
            var medicine = PharmecyDb.medicines;
            foreach(var med in medicine)
            {
                if(med.name == m.name && med.price == m.price)
                {
                    med.NoOfPiece += 1;
                    med.addToCart = false;
                }
            }
            PharmecyDb.addtoCart.Remove(m);
            PharmecyDb.SaveChanges();
            return RedirectToAction("addToCart", "Pharmecy");
        }

        //check out
        public ActionResult Newc(float? total)
        {
            var cart = PharmecyDb.addtoCart.ToList();
            if (total == 0)
                return RedirectToAction("failedCart");
            var viewmodel = new newModelMedicine
            {
                checkOut = new checkOut()
                {
                    Total = (float)total,
                    UserId = User.Identity.GetUserId()
                },
                addtoCart = cart
            };
            return View("Newc", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Savec(checkOut checkOut)
        {
            if (!ModelState.IsValid)   //validation
            {
                var viewmodel = new newModelMedicine
                {
                    checkOut = checkOut,
                    addtoCart = PharmecyDb.addtoCart.ToList()
                };
                return View("Newc", viewmodel);
            }
            PharmecyDb.checkOut.Add(checkOut);
            foreach (var ch in PharmecyDb.addtoCart)
            {
                if (User.Identity.GetUserId() == ch.UserId)
                {
                    ch.check = true;
                }
            }
            PharmecyDb.SaveChanges();
            return RedirectToAction("AddToCart", "Pharmecy");
        }

        public ActionResult failedCart()
        {
            return View();
        }

        public ActionResult Request(int idpharmecy)
        {
            ViewBag.Idpharmecy = idpharmecy;
            var checkOut = PharmecyDb.checkOut.ToList();
            var cart = PharmecyDb.addtoCart.ToList();
            var med = PharmecyDb.medicines.ToList();
            ViewBag.cart = cart;
            ViewBag.checkout = checkOut;
            ViewBag.medicine = med;
            return View();
        }

        //finish order
        //public ActionResult finishOrder(int id, int? idPharmecy)
        //{
        //    ViewBag.Id = idPharmecy;
        //    var ph = PharmecyDb.addtoCart.SingleOrDefault(c => c.id == id);
        //    if (ph == null)
        //        return HttpNotFound();
        //    return View(ph);
        //}
        public ActionResult finishOrder(int id,int Idpharmecy)
        {
            var m = PharmecyDb.addtoCart.Find(id);
            PharmecyDb.addtoCart.Remove(m);
            PharmecyDb.SaveChanges();
            return RedirectToAction("Request", "Pharmecy", new { idPharmecy = Idpharmecy });
        }

    }
}