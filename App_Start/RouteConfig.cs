using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NguyenAnhTuanSachOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ChuDe",
                url: "Chude/Index",
                defaults: new { controller = "ChuDe", action = "Index" }
            );
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "SachOnline", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "NguyenAnhTuanSachOnline.Controllers" }
         );

            routes.MapRoute(
    name: "DangNhap",
    url: "DangNhap",
    defaults: new { controller = "User", action = "DangNhap" }
);


        }

    }
}
