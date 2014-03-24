

using MvcApp.Filters;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.ViewModel;

namespace MvcApp.Controllers
{
   [Log]
    public class HomeController : Controller
    {
      
       private DemoMvDb db = new DemoMvDb();

       public ActionResult Autocomplete(string term)
       {
           var result = db.Movies
              .Where(r => r.Name.StartsWith(term))
              .Take(10)
              .Select(r => new
              {
                  label = r.Name
              });

           return Json(result, JsonRequestBehavior.AllowGet);

           

       }


       protected override void Dispose(bool disposing)
       {
           if (db!=null)
           {
               db.Dispose();
           }
           base.Dispose(disposing);
       }

       [ChildActionOnly]
       public ActionResult TopMovie()
       {
           var topMovie = lstMovies.OrderByDescending(r => r.Name).Take(1);

           return PartialView("_MovieList", topMovie);

       }

       
       public ActionResult SmallCache()
       {
           return Content("Hello");
       }

        
        public ActionResult Index(string searchterm=null)
        {

            var result = db.Movies
                .Where(r => searchterm ==null || r.Name.Contains(searchterm))
                .Select(r =>
                    new MovieReviewViewModel
                    {
                        Name = r.Name,
                        Category = r.Category,
                        NumberOfReviews = r.Reviews.Count,
                        YearOfRelease = r.YearOfRelease,
                        Id = r.Id
                    });

            if (Request.IsAjaxRequest())
            {
                return PartialView("_MoviePartial", result);
            }

            return View(result);

            //return Content(string.Format("Controller: {0}, Action: {1}", cont, action));
            

        }
       [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {

            
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Help()
        {

            ViewBag.Message = "Help Contents";
            //return Content("This is about Help");
            //return Json(new { HelpTopic = "Navigation" },JsonRequestBehavior.AllowGet);
            return View();
        }

        [HttpPost]
        public ActionResult Help(string message)
        {

            //ViewBag.Message = "Help Contents";
            return Content("This is about Help");
            //return Json(new { HelpTopic = "Navigation" },JsonRequestBehavior.AllowGet);
            //return View();
        }

        [AllowAnonymous]
        public ActionResult PingDemo(string message, int id = 0)
        {
          

            return Content(message.ToString()+id.ToString());
        }

        public ActionResult List()
        {
            var model = lstMovies.OrderBy(m => m.Name);


            return View(model);
        }


        static List<Movie> lstMovies = new List<Movie>(){
           new Movie{Name="Avatar", Id=1, Category="SciFi",YearOfRelease=2011},
           new Movie{Name="Shutter Island", Id=2, Category="Thriller",YearOfRelease=2011},
           new Movie{Name="Grudge", Id=3, Category="Horror",YearOfRelease=2011}};
           
    }
}
