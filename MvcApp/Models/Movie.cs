using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace MvcApp.Models
{

    public class Movie
    {
        public int Id { get; set; }

    
        public string Name { get; set; }

      
        public string Category { get; set; }
       
        
        public int YearOfRelease { get; set; }
        public virtual List<MovieReview> Reviews { get; set; }
    }
}