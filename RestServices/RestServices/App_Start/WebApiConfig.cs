using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestServices
{
    public static class WebApiConfig
    {
        public const string BaseEndpoint = "api/v" + VersionNumber + "/";

        public const string VersionNumber = "1";

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
