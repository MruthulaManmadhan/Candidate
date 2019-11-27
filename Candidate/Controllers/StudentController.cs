using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidate.Models;
using Candidate.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Candidate.Controllers
{
    public class StudentController : Controller
    {
        ExamMark examMark = new ExamMark();
        public IActionResult Home(UserInfo userInfo)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                if (Logged == 1)
                {
                    StudentDA student = new StudentDA();
                    examMark = student.GetMark(userInfo.UserID);
                    ViewBag.StudentId = userInfo.UserID;
                    return View(examMark);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the home page.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        public IActionResult ChangePassword()
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                if (Logged == 1)
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
                string exMessage = "oops! There is a problem in loading Change Password page.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        public IActionResult ChangePassword(UserInfo userInfo)
        {
            try
            {
                int Logged = Convert.ToInt32(HttpContext.Session.GetInt32("Logged"));
                if (Logged == 1)
                {
                    UserDA userDA = new UserDA();
                    int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

                    string Change =userDA.ChangePassword(userInfo);
                    return View();
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
    }
}