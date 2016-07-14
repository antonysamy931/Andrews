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
    public class AccentController : BaseController
    {
        private AccentBL _AccentBL = null;
        private ImageBL _ImageBL = null;

        public AccentController()
        {
            _AccentBL = new AccentBL();
            _ImageBL = new ImageBL();
        }

        // GET: Accent
        public ActionResult Index()
        {
            return View(_AccentBL.GetAll());
        }

        // GET: Accent/Details/5
        public ActionResult Details(int id)
        {
            AccentModel model = _AccentBL.Get(id);
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

        // GET: Accent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accent/Create
        [HttpPost]
        public ActionResult Create(AccentModel model, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    byte[] Image = ConvertStreamToByte(image.InputStream);
                    model.Image = ConvertByteToString(Image);
                }
                var accentId = _AccentBL.Insert(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Accent/Edit/5
        public ActionResult Edit(int id)
        {
            AccentModel model = _AccentBL.Get(id);
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

        // POST: Accent/Edit/5
        [HttpPost]
        public ActionResult Edit(AccentModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    byte[] Image = ConvertStreamToByte(image.InputStream);
                    model.Image = ConvertByteToString(Image);
                }
                _AccentBL.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Accent/Delete/5
        public ActionResult Delete(int id)
        {
            AccentModel model = _AccentBL.Get(id);
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

        // POST: Accent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _AccentBL.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
