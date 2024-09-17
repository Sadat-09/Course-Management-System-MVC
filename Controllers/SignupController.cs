using Exam.DTOs;
using Exam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        // GET: signup
        ExamdbEntities1 db = new ExamdbEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup(userDTO s)
        {


            if (ModelState.IsValid)
            {
                var st = Convert(s);
                db.users.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            return View(s);

        }

        public static userDTO Convert(user s)
        {

            return new userDTO()
            {
                id = s.id,
                username = s.username,
                password = s.password,
                email = s.email,
                Type = s.Type
            };
        }
        public static user Convert(userDTO s)
        {
            return new user()
            {
                id = s.id,
                username = s.username,
                password = s.password,
                email = s.email,
                 Type = s.Type
            };
        }
        public static List<userDTO> Convert(List<user> u)
        {
            var list = new List<userDTO>();
            foreach (var s in u)
            {
                var st = Convert(s);
                list.Add(st);
            }
            return list;
        }

    }
}