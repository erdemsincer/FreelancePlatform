﻿using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
