using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcApp.ViewModel
{
    public class MovieReviewViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfReviews { get; set; }


    }
}