using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blogezy_App.Data;
using Blogezy_App.Models;
using Blogezy_App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlogAppCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ArticlesController : Controller
    {

        private BlogezyDbContext _blogezyDbContext;
        public ArticlesController(BlogezyDbContext blogezyDbContext)
        {
            _blogezyDbContext = blogezyDbContext;
        }
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            //from session
            ViewBag.Author = HttpContext.User.Identity.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                articleModel.UserApp = HttpContext.User.Identity.Name;

                if (articleModel.File.ContentType == "image/png")
                {
                    using (FileStream fs = new FileStream(articleModel.File.Name, FileMode.Create))
                    {
                        articleModel.File.CopyTo(fs);
                    }

                }
                Article article = articleModel;
                article.UserAppId = HttpContext.Session.GetString("id");
                await _blogezyDbContext.Articles.AddAsync(article);
                await _blogezyDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            else
                return View();
        }
    }


}