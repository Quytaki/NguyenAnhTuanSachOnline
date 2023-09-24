using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace NguyenAnhTuanSachOnline.Controllers
{
 public class ChuDeController : Controller
{
    private DataClasses1DataContext data;

    public ChuDeController()
    {
        data = new DataClasses1DataContext(); 
    }

    public ActionResult Index()
    {
        // lay ra tat ca cac chu de
        var AllChuDe = from tt in data.CHUDEs select tt;
        return View(AllChuDe);
    }
}

}