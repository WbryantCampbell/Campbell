using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.BLL;
using DVDLibrary.Data.InMemRepos;
using DVDLibrary.Models;

namespace DVDLibrary.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = new DVDOperations().GetAllDvds();
            return View(model);
        }

        [HttpGet]
        public ActionResult SearchPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByTitle(string title)
        {
            var ops = new DVDOperations();
            var dvd = ops.GetDvdByTitle(title);
            if (dvd == null)
            {
                return View("DvdNotFound");
            }
            else
            {
                return View("DetailedView", dvd);
            }
        }

        [HttpGet]
        public ActionResult DetailedView(int id)
        {
            var ops = new DVDOperations();
            var dvd = ops.GetDvdById(id);
            return View(dvd);
        }


        public ActionResult Add()
        {
            return View(new DVD());
        }

        [HttpPost]
        public ActionResult Add(DVD dvd)
        {
            if (ModelState.IsValid)
            {
                var model = new DVDOperations();
                model.Add(dvd);
                return RedirectToAction("List");
            }
            return View("Add");
        }

        public ActionResult Edit(int id)
        {
            var ops = new DVDOperations();
            var dvd = ops.GetDvdById(id);
            return View(dvd);
        }

        [HttpPost]
        public ActionResult Edit(DVD dvd)
        {

            if (ModelState.IsValid)
            {
                var model = new DVDOperations();
                model.Edit(dvd);
                var dvds = model.GetAllDvds();
                return View("List", dvds);
            }
            return View("Edit");

        }

        public ActionResult Delete(int id)
        {
            var ops = new DVDOperations();
            var dvd = ops.GetDvdById(id);
            return View(dvd);
        }

        [HttpPost]
        public ActionResult Delete(DVD dvd)
        {
            new DVDOperations().Delete(dvd);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Borrower(int id)
        {
            var ops = new DVDOperations();
            var dvd = ops.GetDvdById(id);
            return View(dvd);
        }

        [HttpPost]
        public ActionResult Borrower(DVD dvd)
        {
            var ops = new DVDOperations();
            ops.SaveBorrowerInfo(dvd);
            return RedirectToAction("DetailedView", dvd);
        }
    }
}