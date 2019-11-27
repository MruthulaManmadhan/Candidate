using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidate.DataAccess;
using Candidate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Controllers
{
    public class TeacherController : Controller
    {
        List<UserInfo> Students = new List<UserInfo>();
        ExamMark examMark = new ExamMark();
        TeacherDA teacherDA = new TeacherDA();
        public IActionResult StudentList(string message)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 2)
                {
                    AdminDA adminDAObj = new AdminDA();
                    Students = adminDAObj.GetStudents();
                    ViewBag.message = message;
                    return View(Students);
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the pageof student list.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpGet]
        public IActionResult AssignMark(int userId)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 2)
                {
                    StudentDA student = new StudentDA();
                    examMark = student.GetMark(userId);
                    return View(examMark);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the page for assigning marks.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpPost]
        public IActionResult AssignMark(ExamMark examMark)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 2)
                {
                    examMark.Calculate();
                    teacherDA.UpdateMark(examMark);
                    string success = "Marks entered successfully";
                    return RedirectToAction("StudentList", new { message = success });
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in assigning marks.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
    }
}