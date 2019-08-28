using MVCLoginPageAndCKEditor.Models.Data.Context;
using MVCLoginPageAndCKEditor.Models.Entities;
using MVCLoginPageAndCKEditor.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCLoginPageAndCKEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.welcome = "Welcome " + User.Identity.Name.ToUpper();
                ProjectContext db = new ProjectContext();
                var blogs = db.Blog.ToList();
                return View(blogs);
            }
            return RedirectToAction("SignIn", "Home");
        }

        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.welcome = "Welcome " + User.Identity.Name.ToUpper();
                return View();
            }
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

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.welcome = "Welcome " + User.Identity.Name.ToUpper();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                using (ProjectContext context = new ProjectContext())
                {
                    var user = context.User.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.Name, true);
                        ViewBag.aa = user.ID;
                        return RedirectToAction("EnterBlog", "Home");
                    }
                }
            }
            ViewBag.Massage = "Incorrect username or password";
            return View();
        }


        public ActionResult EnterBlog()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.welcome = "Welcome " + User.Identity.Name.ToUpper();
                return View();
            }
            return RedirectToAction("SignIn", "Home");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EnterBlog(Blogs blg, FormCollection frm)
        {
            string article = frm.Get("article");
            ProjectContext db = new ProjectContext();
            Blogs newBlog = new Blogs();
            newBlog.Title = blg.Title;
            newBlog.Time = DateTime.Now;
            newBlog.Text = article;
            db.Blog.Add(newBlog);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Home");
        }
    }
}