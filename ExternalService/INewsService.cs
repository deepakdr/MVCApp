﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewsAndWeather
{    
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        string GetWeekBOHit();
    }
}
