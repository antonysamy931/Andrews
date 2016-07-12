using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Teacher.Controllers
{
    public class LessonController : Controller
    {
        private LessonBL _LessonBL = null;
        public LessonController()
        {
            _LessonBL = new LessonBL();
        }
        // GET: Lesson
        public ActionResult Index()
        {
            var model = _LessonBL.Get();
            return View(model);
        }

        // GET: Lesson/Details/5
        public ActionResult Details(int id, int? page = null)
        {
            var model = _LessonBL.Detail(id, page);
            return View(model);
        }        
    }
}
