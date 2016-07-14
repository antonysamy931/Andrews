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
    public class VocabularyController : BaseController
    {
        private VocabularyBL _VocabularyBL = null;
        private ImageBL _ImageBL = null;
        public VocabularyController()
        {
            _VocabularyBL = new VocabularyBL();
            _ImageBL = new ImageBL();
        }

        // GET: Vocabulary
        public ActionResult Index()
        {
            var models = _VocabularyBL.GetAll();
            return View(models);
        }

        // GET: Vocabulary/Details/5
        public ActionResult Details(int id)
        {
            var model = _VocabularyBL.Get(id);
            if (model.ImageId != null)
            {
                var image = _ImageBL.Get(model.ImageId.Value);
                if (image != null)
                {
                    model.Name = image.Title;
                    model.Description = image.Description;
                }
            }
            return View(model);
        }

        // GET: Vocabulary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vocabulary/Create
        [HttpPost]
        public ActionResult Create(VocabularyModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    byte[] Image = ConvertStreamToByte(image.InputStream);
                    model.Image = ConvertByteToString(Image);
                }
                var accentId = _VocabularyBL.Insert(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Vocabulary/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _VocabularyBL.Get(id);
            if (model.ImageId != null)
            {
                var image = _ImageBL.Get(model.ImageId.Value);
                if (image != null)
                {
                    model.Name = image.Title;
                    model.Description = image.Description;
                }
            }
            return View(model);
        }

        // POST: Vocabulary/Edit/5
        [HttpPost]
        public ActionResult Edit(VocabularyModel model, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    byte[] Image = ConvertStreamToByte(image.InputStream);
                    model.Image = ConvertByteToString(Image);
                }
                _VocabularyBL.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Vocabulary/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _VocabularyBL.Get(id);
            if (model.ImageId != null)
            {
                var image = _ImageBL.Get(model.ImageId.Value);
                if (image != null)
                {
                    model.Name = image.Title;
                    model.Description = image.Description;
                }
            }
            return View(model);
        }

        // POST: Vocabulary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _VocabularyBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
