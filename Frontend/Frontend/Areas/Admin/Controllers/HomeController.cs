﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        // Nguoi dung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetailsUser()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();        }
        public ActionResult ListMovie()
        {
            return View();
        }
        public ActionResult CreateMovie()
        {
            return View();
        }
        public ActionResult DetailMovie()
        {
            return View();
        }
        public ActionResult ListCountry()
        {
            return View();
        }
        public ActionResult ListCategory()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}