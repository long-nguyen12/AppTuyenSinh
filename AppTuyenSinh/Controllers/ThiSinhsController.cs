using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTuyenSinh.Models;

namespace AppTuyenSinh.Controllers
{
    public class ThiSinhsController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: ThiSinhs
        public ActionResult Index()
        {
            var thiSinhs = db.ThiSinhs.Include(t => t.Nganh);
            return View(thiSinhs.ToList());
        }

        // GET: ThiSinhs/Create
        public ActionResult Create()
        {
            ViewBag.Nganh_ID = new SelectList(db.Nganhs, "Nganh_ID", "Nganh_Ma_Ten");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThiSinh thiSinh, HttpPostedFileBase[] files)
        {
            TempData["Result"] = "";
            ViewBag.Nganh_ID = new SelectList(db.Nganhs, "Nganh_ID", "Nganh_Ma_Ten", thiSinh.Nganh_ID);
            var fileCCCD = Request.Files["fileCCCD"];
            var fileTN = Request.Files["fileTN"];
            //Kiểm tra điều kiện
            thiSinh.ThiSinh_HoSoDinhKem = "";
            thiSinh.ID_Nganh1 = thiSinh.ID_Nganh2 = thiSinh.ID_Nganh3 = 0;
            if (ModelState.IsValid)
            {   //Duyệt các file được upload lên server

                if (fileCCCD != null && fileCCCD.ContentLength > 0)
                {
                    var InputFileName = Path.GetFileName(fileCCCD.FileName);
                    InputFileName = thiSinh.ThiSinh_DienThoai + "_" + DateTime.Now.ToFileTime() + "_" + InputFileName;
                    var urlFile = Server.MapPath("~/UploadedCCCD/") + InputFileName;
                    fileCCCD.SaveAs(urlFile);
                    thiSinh.ThiSinh_CCCD = "/UploadedCCCD/" + InputFileName; ;
                    ViewBag.UploadStatus = InputFileName + " file uploaded successfully";
                }

                if (fileTN != null && fileTN.ContentLength > 0)
                {
                    var InputFileName = Path.GetFileName(fileTN.FileName);
                    InputFileName = thiSinh.ThiSinh_DienThoai + "_" + DateTime.Now.ToFileTime() + "_" + InputFileName;
                    var urlFile = Server.MapPath("~/UploadedBangTN/") + InputFileName;
                    fileTN.SaveAs(urlFile);
                    thiSinh.ThiSinh_BangTN = "/UploadedBangTN/" + InputFileName;
                    ViewBag.UploadStatus = InputFileName + " file uploaded successfully";
                }

                foreach (HttpPostedFileBase file in files)
                {
                    //Kiểm tra tập tin có sẵn để lưu.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        InputFileName = thiSinh.ThiSinh_DienThoai + "_" + DateTime.Now.ToFileTime() + "_" + InputFileName;
                        var urlFile = Server.MapPath("~/UploadedFiles/") + InputFileName;
                        // Lưu file vào thư mục trên server  
                        file.SaveAs(urlFile);
                        // lấy đường dẫn các file
                        thiSinh.ThiSinh_HoSoDinhKem += "/UploadedFiles/" + InputFileName + "@#";
                        // Hiển thị thông báo tổng số tệp đã lưu trên server.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully";
                        TempData["Result"] = "THANHCONG";
                    }
                    else
                    {
                        TempData["Result"] = "THATBAI";
                    }

                }
                // lưu vào cơ sở dữ liệu thông tin thí sinh 
                db.ThiSinhs.Add(thiSinh);
                db.SaveChanges();
                // gọi lại form và hiển thị toats thông báo nộp học bạ thành công
                return RedirectToAction("Create");
            }
            return View(thiSinh);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
