using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageProcessing.Models;
namespace ImageProcessing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public ContentResult UploadFile()
        {
           var r = new List<ImageProcessing.Models.FileResult>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                r.Add(new ImageProcessing.Models.FileResult()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
        }
        public ActionResult zooming()
        {
            return View();
        }

        public ActionResult resize()
        {
            return View();
        }

        public ActionResult camanjsdemo()
        {
            return View();
        }

        public ActionResult fabricdemo()
        {
            return View();
        }

        public ActionResult fabricundoredo()
        {
            return View();
        }
    }
}
