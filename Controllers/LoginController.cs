using Exam.DTOs;
using Exam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(loginDTO l)

        {
            ExamdbEntities1 db = new ExamdbEntities1();
            if (ModelState.IsValid)
            {
                var user = (from u in db.users
                            where u.username.Equals(l.username) &&
                                  u.password.Equals(l.password)
                            select u).SingleOrDefault();

                if (user == null)
                {
                    TempData["Msg"] = "User not found / Username and Password mismatch";
                    return RedirectToAction("Signup", "signup");
                }


                Session["user"] = user;
                TempData["Msg"] = "Login Successful";
                if (user.Type.Equals("admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "User");


               
            }


            return View(l);
        }
    }
}