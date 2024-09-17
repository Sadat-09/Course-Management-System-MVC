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
    public class UserController : Controller
    {
        ExamdbEntities1 db = new ExamdbEntities1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult viewcourse()
        {
            
            var data = db.courses.ToList();
            var converted = Convert(data);
            return View(converted);


        }
        [AdminAcess]
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var exobj = db.courses.Find(id);
            return View(exobj);

        }
        [AdminAcess]
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
        [AdminAcess]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.courses.Find(id);
            return View(exobj);
        }
        [AdminAcess]
        [HttpPost]
        public ActionResult Delete(course t)
        {
            var exobj = db.courses.Find(t.id);
            db.courses.Remove(exobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Enroll(int id)
        {
           

            var user = (user)Session["user"];

            

            var enrollment = new enrollment
            {
                uid = user.id,
                cid = id
            };

            db.enrollments.Add(enrollment);
            db.SaveChanges();

            
            return RedirectToAction("Index");
        }
        public ActionResult MyEnrollments()
        {
        

            var user = (user)Session["user"];

            var enrollments = db.enrollments
                .Where(e => e.uid == user.id)
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