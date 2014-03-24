using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.ViewModel
{
    public class ExternalRatingViewModel
    {
        public string StartTime { get; set; }
        public string RottenTomatoRating { get; set; }
        public string IMDB { get; set; }
        public string EndTime { get; set; }
    }
}