using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NguyenAnhTuanSachOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Khởi tạo giá trị mặc định cho "HitCounter" và "Online"
            Application["HitCounter"] = 0;
            Application["Online"] = 0;


            StreamReader strReader = new StreamReader(HttpContext.Current.Server.MapPath("~/LuotTruyCap.txt"));
            string s = strReader.ReadLine();
            strReader.Close();
            int hitCounter;
            if (int.TryParse(s, out hitCounter))
            {
                Application["HitCounter"] = hitCounter;
            }
            Application["Online"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Online"] = int.Parse(Application["Online"].ToString()) + 1;
            Application["HitCounter"] = int.Parse(Application["HitCounter"].ToString()) + 1;
            Application.UnLock();
            StreamWriter strWriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/LuotTruyCap.txt"));
            strWriter.Write(Application["HitCounter"]);
            strWriter.Close();
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Online"] = int.Parse(Application["Online"].ToString()) - 1;
            Application.UnLock();
        }
    }
}
