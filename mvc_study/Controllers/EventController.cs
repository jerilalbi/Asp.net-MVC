using mvc_study.Models;
using mvc_study.repositry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_study.Controllers
{
    public class EventController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Events events = new Events();
                    DataTable dataTable = events.loginUser(loginModel);
                    if(dataTable.Rows.Count > 0)
                    {
                        string userId = dataTable.Rows[0]["id"].ToString();
                        string name = dataTable.Rows[0]["name"].ToString();
                        string email = dataTable.Rows[0]["email"].ToString();
                        string userType = dataTable.Rows[0]["usertype"].ToString();

                        Session["user_id"] = userId;
                        Session["name"] = name;
                        Session["email"] = email;

                        if(userType.ToLower() == "admin")
                        {
                            return RedirectToAction("AdminHome");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("users");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Login Credintials";
                    }
                }
            }
            catch{ }
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    Events events = new Events();
                    if (events.registerNewUser(registerModel))
                    {
                        ViewBag.Message = "New User Added!";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "User Not Added!";
                    }

                }
                return View();
            }catch {

                return View();
            }
        }

        public ActionResult AdminHome()
        {
            Events events = new Events();
            return View(events.showData());
        }

        public ActionResult adminDeleteUser(int id)
        {
            Events events = new Events();
            bool res = events.deleteUser(id);
                return RedirectToAction("AdminHome");
        }
    }
}