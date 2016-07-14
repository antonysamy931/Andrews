using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;

namespace Tinytots.English.Teacher.Controllers
{
    public class AccentController : Controller
    {
        private AccentBL _AccentBL = null;
        public AccentController()
        {
            _AccentBL = new AccentBL();
        }

        // GET: Accent
        public ActionResult Index(int? page = null)
        {
            var model = _AccentBL.GetAll(page);
            return View(model);
        }
    }
}