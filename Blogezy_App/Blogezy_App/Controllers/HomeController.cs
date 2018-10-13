using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogezy_App.Data;
using Blogezy_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogezy_App.Controllers
{
    public class HomeController : Controller
    {
        private BlogezyDbContext _blogezyDb { get; set; }

        public HomeController(BlogezyDbContext blogezyDb)
        {
            _blogezyDb = blogezyDb;
        }

        public IActionResult Index()
        {
            List<Article> articles = _blogezyDb.Articles.ToList();

            return View(articles);
        }
    }
}