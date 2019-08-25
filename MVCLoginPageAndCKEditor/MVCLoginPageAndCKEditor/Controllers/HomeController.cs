using MVCLoginPageAndCKEditor.Models.Data.Context;
using MVCLoginPageAndCKEditor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLoginPageAndCKEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(ApplicationUser user)
        {
            ProjectContext db = new ProjectContext();
            ApplicationUser newUser = new ApplicationUser();
            newUser.Name = user.Name;
            newUser.Password = user.Password;
            newUser.Email = user.Email;
            db.User.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult EnterBlog()
        {
            return View();
        }
    }
}