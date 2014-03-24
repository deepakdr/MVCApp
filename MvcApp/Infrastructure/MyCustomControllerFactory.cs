using MvcApp.Controllers;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcApp.Infrastructure
{
    public class MyCustomControllerFactory: IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
           if (controllerName.ToLower().StartsWith("externalmoviereview"))
            {

                var rtsv = new RottenTomatoService();
                var controller = new ExternalMovieReviewController(rtsv);
                return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
          var disposable = controller as IDisposable;
          if (disposable != null)
          {
              disposable.Dispose();
          }
        }
    }
}