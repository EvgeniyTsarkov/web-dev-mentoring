﻿using Microsoft.AspNetCore.Mvc;
using NorthwindWebsite.Models;
using System.Diagnostics;

namespace NorthwindWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Presentation/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View("~/Presentation/Views/Home/Privacy.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}