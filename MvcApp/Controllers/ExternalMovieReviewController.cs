using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class ExternalMovieReviewController : Controller
    {
        //
        // GET: /ExternalMovieReview/


        IExternalMovieService rtsv;

        public ExternalMovieReviewController(IExternalMovieService externalMovieService)
        {
            this.rtsv = externalMovieService;
        }

        public ActionResult Index()
        {
      
            return Content(rtsv.TopBoxOfficeHit().ToString());
        }

    }
}
