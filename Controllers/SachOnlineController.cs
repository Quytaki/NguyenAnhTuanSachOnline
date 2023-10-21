using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenAnhTuanSachOnline.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace NguyenAnhTuanSachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private DataClasses1DataContext dbContext = new DataClasses1DataContext();

        private DataClasses1DataContext data;
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a => a.SoLuongBan).Take(count).ToList();
        }

        public SachOnlineController()
        {
            data = new DataClasses1DataContext();
        }

        // GET: SachOnline
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var listSachMoi = LaySachMoi(20);
            return View(listSachMoi.ToPagedList(pageNum, pageSize));
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
        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNxb = data.NHAXUATBANs;
            return PartialView(listNxb);
        }
        public ActionResult FooterPartial()
        {
            return PartialView();
        }
        public ActionResult SachBanNhieu()
        {            
             // lấy ra 3 cuốn sách bán chạy nhất
                List<SACH> danhSachSachBanNhieu = dbContext.SACHs.OrderByDescending(s => s.SoLuongBan).Take(6).ToList();
                return PartialView(danhSachSachBanNhieu);        
        }

        public ActionResult NhaXuatBan()
        {
            // danh sách nhà xuất bản
            var danhSachNhaXuatBan = dbContext.NHAXUATBANes.ToList();
            return PartialView(danhSachNhaXuatBan);
        }
        public ActionResult Chitiet()
        {  
            return View();
        }

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHs
                       where s.MaSach == id
                       select s;
            return View(sach.Single());
        }
        public ActionResult SachTheoCD(int id, int? page)
        {
            ViewBag.MaCD = id;
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var sach = data.SACHes.Where(s => s.MaCD == id);
            return View(sach.ToPagedList(pageNum, pageSize));
        }

    }
}