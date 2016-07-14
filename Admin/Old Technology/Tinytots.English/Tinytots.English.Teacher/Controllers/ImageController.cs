using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO;

namespace Tinytots.English.Teacher.Controllers
{
    public class ImageController : Controller
    {
        ImageBL _imageBL = null;
        public ImageController()
        {
            _imageBL = new ImageBL();
        }
        public ActionResult ViewImage(int id)
        {
            Image image = _imageBL.Get(id);
            byte[] filecontent = CovertStringToByte(image.Content);
            return File(filecontent, "image/jpeg");
        }

        private byte[] CovertStringToByte(string image)
        {
            return Convert.FromBase64String(image);
        }
    }
}