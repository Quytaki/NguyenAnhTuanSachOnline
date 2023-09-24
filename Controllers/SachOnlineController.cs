using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenAnhTuanSachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private DataClasses1DataContext dbContext = new DataClasses1DataContext();

        private DataClasses1DataContext data;

        public SachOnlineController()
        {
            data = new DataClasses1DataContext();
        }

        // GET: SachOnline
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChuDePartial()
        {
            // lấy ra danh sách chủ đề
      return PartialView(dbContext.CHUDEs.ToList());
        }
        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult SliderPatial()
        {
            return PartialView();
        }
        public ActionResult SachBanNhieu()
        {            
             // lấy ra 3 cuốn sách bán chạy nhất
                List<SACH> danhSachSachBanNhieu = dbContext.SACHs.OrderByDescending(s => s.SoLuongBan).Take(3).ToList();
                return PartialView(danhSachSachBanNhieu);        
        }

        public ActionResult NhaXuatBan()
        {
            // danh sách nhà xuất bản
            var danhSachNhaXuatBan = dbContext.NHAXUATBANes.ToList();
            return PartialView(danhSachNhaXuatBan);
        }
        public ActionResult Chitiet()
        {             return View();
        }
        
    }
}