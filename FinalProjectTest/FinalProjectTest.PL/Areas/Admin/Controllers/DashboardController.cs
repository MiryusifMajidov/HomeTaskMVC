﻿using Microsoft.AspNetCore.Mvc;

namespace FinalProjectTest.PL.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
