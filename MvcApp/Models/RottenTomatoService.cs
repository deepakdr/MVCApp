using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class RottenTomatoService : IExternalMovieService
    {



        public string TopBoxOfficeHit()
        {
            return "300 Rise of an empire";
        }



    }
}