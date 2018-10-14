using Blogezy_App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogezy_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogezy_App.Models.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Blogezy_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class HomeController : Controller
    {
        private BlogezyDbContext _blogezyDbContext;
        public HomeController(BlogezyDbContext blogezyDbContext)
        {
            _blogezyDbContext = blogezyDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //from session
            ViewBag.Author = HttpContext.User.Identity.Name;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                articleModel.UserApp = HttpContext.User.Identity.Name;

                string fileName = articleModel.File.FileName;
                IFormFile formFile = articleModel.File;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "main","images", fileName);

                using (FileStream info = new FileStream(path, FileMode.Create))
                {
                    await articleModel.File.CopyToAsync(info);
                }

                Article article = articleModel;
                article.UserAppId = HttpContext.Session.GetString("id");

                await _blogezyDbContext.Articles.AddAsync(article);
                await _blogezyDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }
    }
}
