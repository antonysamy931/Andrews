using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Master.Controllers
{
    [Authorize]
    public class LessonController : BaseController
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
        public ActionResult Details(int id)
        {
            var model = _LessonBL.GetById(id);
            return View(model);
        }

        // GET: Lesson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lesson/Create
        [HttpPost]
        public ActionResult Create(LessonModel model)
        {
            if (ModelState.IsValid)
            {
                _LessonBL.Insert(model.Mapping());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Lesson/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _LessonBL.GetById(id);

            return View(model);
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        public ActionResult Edit(LessonModel model)
        {
            if (ModelState.IsValid)
            {
                _LessonBL.Update(model.Mapping());
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Lesson/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _LessonBL.GetById(id);

            return View(model);
        }

        // POST: Lesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _LessonBL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
