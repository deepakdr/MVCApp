using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace NewsAndWeather
{
    public class NewsService : INewsService
    {
        public string GetWeekBOHit()
        {
            Thread.Sleep(2000);
            return "300 Rise of an empire";
        }
    }
}
