using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogezy_App.Models;
using Blogezy_App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogezy_App.Controllers
{
    public class LoginController : Controller
    {

        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            UserApp appUser = await _userManager.FindByEmailAsync(loginModel.Email);
            if (ModelState.IsValid)
            {
                 await _signInManager.PasswordSignInAsync(appUser, loginModel.Password,true, true);

                    HttpContext.Session.SetString("name", appUser.UserName);

                    HttpContext.Session.SetString("id", appUser.Id);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });

            }
            return View();
        }
    }
}