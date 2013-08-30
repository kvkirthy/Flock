using System.Web.Http.Dispatcher;
using Flock.DependencyResolution;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;

namespace Flock
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

    //    internal static DocumentStore FlockDocumentStore;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
         //   GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "application/json"));
          //  FlockDocumentStore = new DocumentStore { Url = ConfigurationManager.AppSettings["RavenDbUrl"] };
           // FlockDocumentStore.Initialize();

         
            //ObjectFactory.Initialize(x =>
            //                             {
            //                                 x.Scan(scan =>
            //                                 {
            //                                     scan.TheCallingAssembly();
            //                                     scan.WithDefaultConventions();
            //                                 });

            //                                 x.AddRegistry(new RavenRegistry());
            //                                 x.AddRegistry(new FacadeRegistry());
            //                                 x.AddRegistry(new RepositoryRegistry());
            //      
                     //  });
        }
    }
}