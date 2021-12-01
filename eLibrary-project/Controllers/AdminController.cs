using eLibrary_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLibrary_project.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext dbObj = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEBook(EBook model)
        {

            if (ModelState.IsValid)
            {
                EBook book = new EBook();

                book = model;

                dbObj.EBooks.Add(book);
                dbObj.SaveChanges();

                ModelState.Clear();
            }

            return View();
        }

        public ActionResult AddPhysicalBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhysicalBook(PhysicalBook model)
        {

            if (ModelState.IsValid)
            {
                PhysicalBook book = new PhysicalBook();

                book = model;

                dbObj.PhysicalBooks.Add(book);
                dbObj.SaveChanges();

                ModelState.Clear();
            }

            return View();
        }

        public ActionResult RequestsList()
        {
            return View(dbObj.Requests);
        }

        public ActionResult AcceptRequest(Request model)
        {
            var res = dbObj.Requests.Where(x => x.Id == model.Id).First();

            Rental rental = new Rental();
            rental.UserId = res.UserId;
            rental.BookId = res.BookId;

            dbObj.Rentals.Add(rental);

            DeleteRequest(model);

            var book = dbObj.PhysicalBooks.Where(x => x.Id == model.BookId).First();
            book.IsAvailable = false;
            dbObj.Entry(book).State = EntityState.Modified;

            dbObj.SaveChanges();

            return RedirectToAction("RequestsList");
        }

        public ActionResult DeleteRequest()
        {
            return RedirectToAction("RequestsList");
        }

        [HttpDelete]
        public ActionResult DeleteRequest(Request model)
        {
            var res = dbObj.Requests.Where(x => x.Id == model.Id).First();
            dbObj.Requests.Remove(res);

            dbObj.SaveChanges();

            return RedirectToAction("RequestsList");
        }

        public ActionResult EditPhysicalBook(PhysicalBook model)
        {
            if (ModelState.IsValid)
            {
                PhysicalBook book = new PhysicalBook();
                book = model;

                dbObj.Entry(book).State = EntityState.Modified;
                dbObj.SaveChanges();
                ModelState.Clear();
            }

            return View("EditPhysicalBook", model);
        }

        public ActionResult DeletePhysicalBook(PhysicalBook model)
        {
            var res = dbObj.PhysicalBooks.Where(x => x.Id == model.Id).First();
            dbObj.PhysicalBooks.Remove(res);
            dbObj.SaveChanges();

            return RedirectToAction("PhysicalBooks");
        }

        public ActionResult EditEBook(EBook model)
        {
            if (ModelState.IsValid)
            {
                EBook book = new EBook();
                book = model;

                dbObj.Entry(book).State = EntityState.Modified;
                dbObj.SaveChanges();
                ModelState.Clear();
            }

            return View("EditEBook", model);
        }

        public ActionResult DeleteEBook(EBook model)
        {
            var res = dbObj.EBooks.Where(x => x.Id == model.Id).First();
            dbObj.EBooks.Remove(res);
            dbObj.SaveChanges();

            return RedirectToAction("EBooks");
        }

        public ActionResult RentedList()
        {
            return View(dbObj.Rentals);
        }

        public ActionResult BookReturned(Rental model)
        {
            var res = dbObj.Rentals.Where(x => x.Id == model.Id).First();

            var book = dbObj.PhysicalBooks.Where(x => x.Id == res.BookId).FirstOrDefault();
            book.IsAvailable = true;
            dbObj.Entry(book).State = EntityState.Modified;

            dbObj.Rentals.Remove(res);
            dbObj.SaveChanges();

            return RedirectToAction("RentedList");
        }
    }
}