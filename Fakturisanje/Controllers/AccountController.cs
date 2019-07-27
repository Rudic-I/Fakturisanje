using Fakturisanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Fakturisanje.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            User user = Account.CheckUser(model);
            if (user != null)
            {
                Session["user"] = user.Role;
                return RedirectToAction("Index", "Invoice");
            }
            else
            {
                ViewBag.Error = "Korisničko ime ili lozinka nisu validni!";
                return View();
            }
        }

        //Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}