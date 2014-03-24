using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class MovieServiceController : ApiController
    {

        private DemoMvDb db = new DemoMvDb();

        // GET api/movieservice
        public IEnumerable<Movie> GetAllMovies()
        {
           
            return db.Movies.ToList();
        }

        // GET api/movieservice/5
        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        // POST api/movieservice
        public void Post([FromBody]string value)
        {
        }

        // PUT api/movieservice/5
        public void Put(int id, Movie model)
        {
            if (ModelState.IsValid && id == model.Id)
            {
                db.Entry(model).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

        }

        // DELETE api/movieservice/5
        public void Delete(int id)
        {
        }
    }
}
