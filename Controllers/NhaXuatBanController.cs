using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace NguyenAnhTuanSachOnline.Controllers
{
    public class NhaXuatBanController : Controller
    {
        private DataClasses1DataContext data;
        private DataClasses1DataContext db = new DataClasses1DataContext();

        public NhaXuatBanController()
        {
            data = new DataClasses1DataContext();
        }
        public NHAXUATBAN GetNXB(int id)
        {
            return data.NHAXUATBANs.Where(nxb => nxb.MaNXB == id).SingleOrDefault();
        }
      
        public ActionResult Index()
        {
            List<NHAXUATBAN> danhSachNXB = db.NHAXUATBANs.ToList();

            // Trả về view và truyền danh sách nhà xuất bản đóng vai trò là model cho view
            return View(danhSachNXB);
        }
        // GET: Nxb/Details/5

        public ActionResult Details(int? id)
        {
            var nxb = db.NHAXUATBANs.Where(n => n.MaNXB == id).SingleOrDefault();
            return View(nxb);
        }
        // GET: Nxb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nxb/Create
        [HttpPost]
        public ActionResult Create(NHAXUATBAN collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NHAXUATBAN nxb = new NHAXUATBAN();
                    nxb.TenNXB = collection.TenNXB;
                    nxb.DiaChi = collection.DiaChi;
                    nxb.DienThoai = collection.DienThoai;
                    db.NHAXUATBANs.InsertOnSubmit(nxb);
                    db.SubmitChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nxb/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetNXB(id));
        }

        // POST: Nxb/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nxb = GetNXB(int.Parse(Request.Form["MaNXB"]));
                    nxb.TenNXB = Request.Form["TenNXB"];
                    nxb.DiaChi = Request.Form["DiaChi"];
                    nxb.DienThoai = Request.Form["DienThoai"];
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nxb/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetNXB(id));
        }

        // POST: Nxb/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                NHAXUATBAN nxb = db.NHAXUATBANs.Single(n => n.MaNXB == id);
                db.NHAXUATBANs.DeleteOnSubmit(nxb);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}