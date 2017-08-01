using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortunrtellerMVC.Models;

namespace FortunrtellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerEntities db = new FortuneTellerEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else if (customer.ROYGBIV == "red")
            {

                ViewBag.Transporation = "a nice car.";
            }
            else if (customer.ROYGBIV == "orange")
            { 
                ViewBag.Transporation = "a jet pack.";
             }
            else if (customer.ROYGBIV == "yellow")
            {
                ViewBag.Transporation = "a submarine";
            }
            else if (customer.ROYGBIV == "green")
            {
                ViewBag.Transporation = "a rickshaw.";
            }
            else if (customer.ROYGBIV == "blue")
            {
                ViewBag.Transporation = "a work van.";
            }
            else if (customer.ROYGBIV == "indigo")
            {
                ViewBag.Transporation = "a private jet.";
            }
            else if (customer.ROYGBIV == "violet")
            {
                ViewBag.Transporation = "a roman chariot.";
            }
            else
            {
                ViewBag.Transporation = "a unicycle."; 
            }


            if (customer.Age % 2 == 0)
            {
                ViewBag.Age = 10;
            }

            else
            {
                ViewBag.Age = 40;
            }


            if (customer.Siblings == 0)
            {
                ViewBag.VacationHome = "Japan";
            }

            else if (customer.Siblings == 1)
            {
                ViewBag.VacationHome = "New Zealand";
            }

            else if (customer.Siblings == 2d)
            {
                ViewBag.VacationHome = "Hawaii";
            }

            else if (customer.Siblings == 3d)
            {
                ViewBag.VacationHome = "New York";
            }

            else if (customer.Siblings > 3d)
            {
                ViewBag.VacationHome = "Florida";
            }

            else
            {
                ViewBag.VacationHome = "a back ally";
            }


            if (customer.BirthMonth >= 1 && customer.BirthMonth <= 4)
            {
                ViewBag.BirthMonth = 10000;
            }

            else if (customer.BirthMonth >= 5 && customer.BirthMonth <= 8)
            {
                ViewBag.BirthMonth = 15000;
            }

            else if (customer.BirthMonth >= 9 && customer.BirthMonth <= 12)
            {
                ViewBag.BirthMonth = 200000;
            }

            else
            {
                ViewBag.BirthMonth = 5;
            }


            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,ROYGBIV,BirthMonth,Siblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,ROYGBIV,BirthMonth,Siblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
