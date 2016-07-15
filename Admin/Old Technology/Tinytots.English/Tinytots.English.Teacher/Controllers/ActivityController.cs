using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;

namespace Tinytots.English.Teacher.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private ProseActivityBL _ProseActivityBL = null;
        public ActivityController()
        {
            _ProseActivityBL = new ProseActivityBL();
        }
        // GET: Activity
        public ActionResult Index(int? id = null)
        {
            _ProseActivityBL.Insert(Convert.ToInt32(User.Identity.Name));
            var model = _ProseActivityBL.GetById(Convert.ToInt32(User.Identity.Name), id);
            return View(model);
        }

        public ActionResult Report()
        {
            var model = _ProseActivityBL.Get(Convert.ToInt32(User.Identity.Name));
            return View(model);
        }

        public JsonResult Update(int id, string answer)
        {
            _ProseActivityBL.Update(id, answer);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}