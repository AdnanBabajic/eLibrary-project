using eLibrary_project.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLibrary_project.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        ApplicationDbContext dbObj = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EBooks()
        {
            return View(dbObj.EBooks);
        }

        public ActionResult PhysicalBooks()
        {
            return View(dbObj.PhysicalBooks);
        }

        public ActionResult RentPhysicalBook(PhysicalBook model)
        {
            Request request = new Request();
            request.BookId = model.Id;
            request.UserId = User.Identity.GetUserId();

            dbObj.Requests.Add(request);
            dbObj.SaveChanges();

            return View();
        }

        public ActionResult OpenEBook(EBook model)
        {
            return RedirectToAction(model.PdfLink);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditEBook(EBook model)
        {
            return RedirectToAction("EditEBook", "Admin", new { model.Id, model.PdfLink, model.Name, model.Author, model.Genre, model.ReleaseYear, model.CoverImg });
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteEBook(EBook model)
        {
            return RedirectToAction("DeleteEBook", "Admin", new { id = model.Id });
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditPhyisicalBook(PhysicalBook model)
        {
            return RedirectToAction("EditPhysicalBook", "Admin", new { model.Id, model.Location, model.IsAvailable, model.Name, model.Author, model.Genre, model.ReleaseYear, model.CoverImg });
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeletePhysicalBook(PhysicalBook model)
        {
            return RedirectToAction("DeletePhysicalBook", "Admin", new { id = model.Id });
        }

        public ActionResult DetailsEBook(EBook model)
        {
            var book = dbObj.EBooks.Where(x => x.Id == model.Id).First();

            return View(book);
        }

        public ActionResult DetailsPhysicalBook(PhysicalBook model)
        {
            var book = dbObj.PhysicalBooks.Where(x => x.Id == model.Id).First();

            return View(book);
        }
    }
}