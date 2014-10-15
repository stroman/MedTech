using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using MedTech.Application.Mapping;

namespace MedTech.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //configure automapping in application layer
            AutoMapperConfiguration.Configure();

        }
    }
}
