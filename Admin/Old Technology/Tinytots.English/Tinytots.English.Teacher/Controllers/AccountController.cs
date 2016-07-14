using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Teacher.Controllers
{
    public class AccountController : Controller
    {
        UserBL _UserBL = null;
        public AccountController()
        {
            _UserBL = new UserBL();
        }
        [AllowAnonymous]        
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _UserBL.CheckUser(model);
                if (user > 0)
                {
                    FormsAuthentication.SetAuthCookie(user.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}