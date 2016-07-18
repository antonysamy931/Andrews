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
    public class PageController : Controller
    {
        PageBL _PageBL = null;
        LessonBL _LessonBL = null;
        public PageController()
        {
            _PageBL = new PageBL();
            _LessonBL = new LessonBL();
        }

        // GET: Page
        public ActionResult Index(int id)
        {
            var model = _PageBL.Gets(id);
            return View(model);
        }

        // GET: Page/Details/5
        public ActionResult Details(int id, int lessonId)
        {
            var model = _PageBL.Get(id, lessonId);
            return View(model);
        }

        // GET: Page/Create
        public ActionResult Create(int lessonId)
        {
            PageModel model = new PageModel();
            model.LessonId = lessonId;
            var lesson = _LessonBL.GetById(lessonId);
            if(lesson != null)
            {
                DTO.Lesson ls = new DTO.Lesson();
                ls.Description = lesson.Description;
                ls.Name = lesson.Name;
                ls.Id = lesson.Id.Value;
                model.Lesson = ls;
            }
            return View(model);
        }

        // POST: Page/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(PageModel model)
        {
            if (ModelState.IsValid)
            {
                var pageId = _PageBL.Insert(model);
                return RedirectToAction(nameof(Details), new { id = pageId, lessonId = model.LessonId });
            }
            var lesson = _LessonBL.GetById(model.LessonId.Value);
            if (lesson != null)
            {
                DTO.Lesson ls = new DTO.Lesson();
                ls.Description = lesson.Description;
                ls.Name = lesson.Name;
                model.Lesson = ls;
            }
            return View(model);
        }

        // GET: Page/Edit/5
        public ActionResult Edit(int id, int lessonId)
        {
            var model = _PageBL.Get(id, lessonId);
            return View(model);
        }

        // POST: Page/Edit/5
        [HttpPost]
        public ActionResult Edit(PageModel model)
        {
            if (ModelState.IsValid)
            {
                _PageBL.Update(model);
                return RedirectToAction(nameof(Details), new { id = model.Id.Value, lessonId = model.LessonId.Value });
            }
            model = _PageBL.Get(model.Id.Value, model.LessonId.Value);
            return View(model);
        }

        // GET: Page/Delete/5
        public ActionResult Delete(int id, int lessonId)
        {
            var model = _PageBL.Get(id, lessonId);
            return View(model);
        }

        // POST: Page/Delete/5
        [HttpPost]
        public ActionResult Delete(PageModel model)
        {
            _PageBL.Delete(model.Id.Value);
            return RedirectToAction("Details", "Lesson", new { id = model.LessonId.Value });
        }
    }
}
