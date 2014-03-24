using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcApp.ViewModel;
using System.Threading.Tasks;

namespace MvcApp.Controllers
{
    public class ExternalReviewController : Controller
    {
        //
        // GET: /ExternalReview/

        public  ActionResult Index()
        {

            var model = new ExternalRatingViewModel();
            model.StartTime = DateTime.Now.ToLongTimeString();

            //RottenTomatoServiceReference.Service1Client rtclient = new RottenTomatoServiceReference.Service1Client();

            //IMDBServiceReference.Service1Client imdbclient = new IMDBServiceReference.Service1Client();

            //rtclient.getwe
            ////var taskRT = rtclient.GetWeekTopMovieAsync();
            ////var taskImdb =  imdbclient.GetTopGrossingMovieAsync();

            model.EndTime = DateTime.Now.ToLongTimeString();
            return View(model);
        }

       
        //public ActionResult Index()
        //{

        //    var model = new ExternalRatingViewModel();
        //    model.StartTime = DateTime.Now.ToLongTimeString();

        //    RottenTomatoServiceReference.Service1Client rtclient = new RottenTomatoServiceReference.Service1Client();

        //    IMDBServiceReference.Service1Client imdbclient = new IMDBServiceReference.Service1Client();
          
        //   model.RottenTomatoRating =  rtclient.GetWeekTopMovie();
        //   model.IMDB = imdbclient.GetTopGrossingMovie();

        //   model.EndTime = DateTime.Now.ToLongTimeString();
        //   return View(model);
        //}

       
    }
}
