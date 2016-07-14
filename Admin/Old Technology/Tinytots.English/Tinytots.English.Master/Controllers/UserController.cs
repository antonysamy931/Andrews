using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Master.Controllers
{
    public class UserController : BaseController
    {
        private UserBL _UserBL = null;
        public UserController()
        {
            _UserBL = new UserBL();
        }

        // GET: User
        public ActionResult Index()
        {
            var models = _UserBL.Get();
            return View(models);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var model = _UserBL.GetById(id);
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _UserBL.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _UserBL.GetById(id);
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            ModelState.Remove("Password");
            ModelState.Remove("RePassword");
            if (ModelState.IsValid)
            {
                _UserBL.Update(model);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _UserBL.GetById(id);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _UserBL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
