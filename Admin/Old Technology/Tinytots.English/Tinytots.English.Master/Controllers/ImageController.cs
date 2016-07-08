using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO;

namespace Tinytots.English.Master.Controllers
{
    public class ImageController : BaseController
    {
        ImageBL _imageBL = null;
        public ImageController()
        {
            _imageBL = new ImageBL();
        }
        // GET: Image
        public ActionResult ViewImage(int id)
        {
            Image image = _imageBL.Get(id);
            byte[] filecontent = CovertStringToByte(image.Content);
            return File(filecontent, "image/jpeg");
        }
    }
}