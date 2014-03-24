using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class ReviewsController : Controller
    {

        private DemoMvDb db = new DemoMvDb();

        protected override void Dispose(bool disposing)
        {
            if (db!=null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //
        // GET: /Reviews/

        public ActionResult Index(int id)
        {

            var result = db.Movies.Find(id);
            return View(result);
        }

        //
        // GET: /Reviews/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reviews/Create

        public ActionResult Create(int movieid)
        {
            return View();
        }

        //
        // POST: /Reviews/Create

        [HttpPost]
        public ActionResult Create(MovieReview moviereview)
        {
            if (ModelState.IsValid)
            {
                db.MovieReviews.Add(moviereview);
                db.SaveChanges();
            }

            return RedirectToAction("Index", new { id = moviereview.MovieId });
        }

        //
        // GET: /Reviews/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reviews/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
