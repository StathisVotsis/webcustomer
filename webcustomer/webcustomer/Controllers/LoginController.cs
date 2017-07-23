using Stathis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stathis.Data;

namespace webcustomer.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string pass)
        {
            var userRepo = new UserRepository();
            Session["username"] = userRepo.GetByPass(name, pass).UserName;
            if (Session["username"] == null)
            {
                return RedirectToAction("Login","Login");
            }
            else
            {
                return RedirectToAction("Index", "Stathis2");
            }
            //return View(userRepo.GetByPass(name,pass,mail));//return customer
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","Login");
        }
    }
}