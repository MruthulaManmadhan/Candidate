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
    public class AdminController : Controller
    {
        AdminDA adminDAObj = new AdminDA();
        List<UserInfo> Students = new List<UserInfo>();
        public IActionResult StudentList(string message)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
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
                string exMessage = "oops! There is a problem in loading the students details page .";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
                    return View();
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the page for adding students.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpPost]
        public IActionResult AddStudent(UserInfo student)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
                    adminDAObj.AddStudent(student);
                    string success = "Student added successfully";
                    return RedirectToAction("StudentList", new { message = success });
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in adding student.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpGet]
        public IActionResult DeleteStudent(int Userid)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
                    UserInfo student = new UserInfo();
                    student = adminDAObj.GetStudent(Userid);
                    return View(student);
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the page.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpPost]
        public IActionResult DeleteStudent(UserInfo student)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
                    adminDAObj.DeleteStudent(student.UserID);
                    string Success = "Student Deleted successfully";
                    return RedirectToAction("StudentList", new { message = Success });
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in deleting student.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpGet]
        public IActionResult EditStudent(int Userid)// view need to create
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
                    UserInfo student = new UserInfo();
                    student = adminDAObj.GetStudent(Userid);
                    return View(student);
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the page.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpPost]
        public IActionResult EditStudent(UserInfo student)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                int User = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (Logged == 1 && User == 1)
                {
                    adminDAObj.UpdateStudent(student);
                    string Success = "Student Details Updated successfully";
                    return RedirectToAction("StudentList", new { message = Success });
            }
                else
            {
                return RedirectToAction("Login", "Home");
            }
        }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in editing student.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
    }
}