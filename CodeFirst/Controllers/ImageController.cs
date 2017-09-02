using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class ImageController : Controller
    {
        StudentDbContext baza = new StudentDbContext();

        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Image model, HttpPostedFileBase image)
        {
            if (image != null)
            {
                model.ImageFile = new byte[image.ContentLength];
                image.InputStream.Read(model.ImageFile, 0, image.ContentLength);
            }
            
            baza.Images.Add(model);
            baza.SaveChanges();
            return View(model);
        }

        public ActionResult Show()
        {
            
            return View(baza.Images.ToList());
        }
    }
}