using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Tinytots.English.Teacher.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["Name"]))
            {
                FormsAuthentication.SetAuthCookie(collection["Name"].ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Name is required to login.");
            return View(collection);
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