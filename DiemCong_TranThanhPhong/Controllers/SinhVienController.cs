using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_TranThanhPhong.Models;
namespace DiemCong_TranThanhPhong.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();
        

        public ActionResult ListSinhVien()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }
        public ActionResult Detail(String id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNghanh = collection["MaNghanh"];
            if (string.IsNullOrEmpty(E_MaSV))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_MaSV.ToString();
                s.HoTen = E_HoTen.ToString();
                s.GioiTinh = E_GioiTinh.ToString();
                s.NgaySinh = E_NgaySinh;
                s.Hinh = E_Hinh.ToString();
                s.MaNganh = E_MaNghanh;
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Create();
        }
        public ActionResult Edit(String id)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(String id, FormCollection collection)
        {
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNghanh = collection["MaNghanh"];
            if (string.IsNullOrEmpty(E_MaSV))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
                E_sinhvien.MaSV = E_MaSV;
                E_sinhvien.HoTen = E_HoTen;
                E_sinhvien.GioiTinh = E_GioiTinh;
                E_sinhvien.NgaySinh = E_NgaySinh;
                E_sinhvien.Hinh = E_Hinh;
                E_sinhvien.MaNganh = E_MaNghanh;
                UpdateModel(E_sinhvien);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Edit(id);
        }
        //-----------------------------------------
        public ActionResult Delete(String id)
        {
            var D_masv = data.SinhViens.First(m => m.MaSV == id);
            return View(D_masv);
        }
        [HttpPost]
        public ActionResult Delete(String id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("ListSinhVien");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }

            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));

            return "/Content/images/" + file.FileName;
        }
    }
}