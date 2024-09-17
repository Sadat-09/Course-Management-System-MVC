using Exam.Auth;
using Exam.DTOs;
using Exam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Controllers
{
    [Logged]
    public class AdminController : Controller
    {
        ExamdbEntities1 db = new ExamdbEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addcourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addcourse(courseDTO s)
        {
            ExamdbEntities1 db = new ExamdbEntities1();

            if (ModelState.IsValid)
            {
                var st = Convert(s);
                db.courses.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);

        }
        public ActionResult viewcourse()
        {

            var data = db.courses.ToList();
            var converted = Convert(data);
            return View(converted);


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var exobj = db.courses.Find(id);
            return View(exobj);

        }
        [HttpPost]
        public ActionResult Edit(course s)
        {
           
            var exobj = db.courses.Find(s.id);

            exobj.cname = s.cname;
            exobj.duration = s.duration;
            exobj.instructor = s.instructor;


            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.courses.Find(id);
            return View(exobj);
        }
       
        [HttpPost]
        public ActionResult Delete(course t)
        {
            var exobj = db.courses.Find(t.id);
            db.courses.Remove(exobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ViewEnrollments()
        {
            var enrollments = db.enrollments
                .Select(e => new EnrollmentDetailsDTO
                {
                    Id = e.id,
                    CourseName = e.course.cname,
                    UserName = e.user.username,
                    
                })
                .ToList();

            return View(enrollments);
        }
        public static courseDTO Convert(course s)

        {

            return new courseDTO()
            {

                id = s.id,
                cname = s.cname,
                duration = s.duration,
                instructor = s.instructor,



            };
        }
        public static course Convert(courseDTO s)
        {
            return new course()
            {

                id = s.id,
                cname = s.cname,
                duration = s.duration,
                instructor = s.instructor,
               
            };
        }
        public static List<courseDTO> Convert(List<course> courses)
        {
            var list = new List<courseDTO>();
            foreach (var s in courses)
            {
                var st = Convert(s);
                list.Add(st);
            }
            return list;
        }
    }
}