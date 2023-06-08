using AppTuyenSinh.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTuyenSinh.Controllers
{
    public class testController : Controller
    {
        public ActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create1(HttpPostedFileBase[] files)
        {
            //Ensure model state is valid  
          
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var urlFile = Server.MapPath("~/UploadedFiles/") + InputFileName;
                        //Save file to server folder  
                        file.SaveAs(urlFile);
                       
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
             
            }
            return View();
        }
        // GET: test
        private DbConnect db = new DbConnect();
        public ActionResult Create()
        {
            ViewBag.Nganh_ID = new SelectList(db.Nganhs, "Nganh_ID", "Nganh_Ma_Ten");
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(ThiSinh _thisinh, HttpPostedFileBase[] files)
        {
           
            //Ensure model state is valid  
            _thisinh.ThiSinh_HoSoDinhKem = "";
            
               //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var urlFile = Server.MapPath("~/UploadedFiles/") + InputFileName;
                        //Save file to server folder  
                        file.SaveAs(urlFile);
                        _thisinh.ThiSinh_HoSoDinhKem += "~/UploadedFiles/" + InputFileName + "@#";
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                
                db.ThiSinhs.Add(_thisinh);
                db.SaveChanges();
            }
            ViewBag.Nganh_ID = new SelectList(db.Nganhs, "Nganh_ID", "Nganh_Ma_Ten", _thisinh.Nganh_ID);
            return View();
        }
        
    }
}