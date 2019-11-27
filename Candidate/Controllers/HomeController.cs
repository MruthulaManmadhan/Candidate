using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Candidate.Models;
using Candidate.DataAccess;
using Microsoft.AspNetCore.Http;

namespace Candidate.Controllers
{
    public class HomeController : Controller
    {
        UserDA userDAObj = new UserDA();
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the login page.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        [HttpPost]
        public IActionResult Login(UserInfo user)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                    UserInfo userInfo = userDAObj.Login(user.Email, user.Password);
                    if (userInfo.Role == "Admin")
                    {
                        HttpContext.Session.SetInt32("Logged", 1);
                        HttpContext.Session.SetInt32("User", 1);
                        HttpContext.Session.SetInt32("UserId", userInfo.UserID);
                        return RedirectToAction("StudentList", "Admin", "");
                    }
                    else if (userInfo.Role == "Teacher")
                    {
                        HttpContext.Session.SetInt32("Logged", 1);
                        HttpContext.Session.SetInt32("User", 2);
                        HttpContext.Session.SetInt32("UserId", userInfo.UserID);
                        return RedirectToAction("StudentList", "Teacher");
                    }
                    else if (userInfo.Role == "Student")
                    {
                        HttpContext.Session.SetInt32("Logged", 1);
                        HttpContext.Session.SetInt32("UserId", userInfo.UserID);
                        return RedirectToAction("Home", "Student", userInfo);
                    }
                    else
                    {
                        ViewBag.NotValidUser = "Invalid User";
                        return View();
                    }
                //}
                //else
                //{
                //    return View();
                //}
            }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loading the login.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }
        }
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetInt32("Logged", 0);
                HttpContext.Session.SetInt32("User", 0);
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                string exMessage = "oops! There is a problem in loggingout.";
                return RedirectToAction("Index", "ExeptionHandler", new { Exeption = exMessage });
            }

        }
    }
}
