using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SponsorBulmaSitesi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        DBBonusSMEntities1 db = new DBBonusSMEntities1();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["ToplamZiyaretci"] = 0;
        }
    }
}
