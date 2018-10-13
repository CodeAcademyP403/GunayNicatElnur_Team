using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogezy_App.Data;
using Blogezy_App.Models;
using Blogezy_App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogezy_App.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly BlogezyDbContext _blogezyDb;

        public AccountController(UserManager<UserApp> userManager,
                                    SignInManager<UserApp> signInManager,
                                        BlogezyDbContext blogezyDb)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _blogezyDb = blogezyDb;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();

                UserApp appUser = await _userManager.FindByEmailAsync(loginModel.Email);

                if (appUser !=null)
                {
                    await _signInManager.PasswordSignInAsync(appUser, loginModel.Password, true, true);

                    //string User = appUser.UserName;

                    //HttpContext.Session.SetString("UserName", User);

                    //HttpContext.Session.SetString("Id", appUser.Id);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                UserApp userApp = new UserApp()
                {
                    Name = registerModel.Name,
                    SurName = registerModel.SurName,
                    Email = registerModel.Email,
                    UserName = registerModel.UserName
                };

                IdentityResult identityResult = await _userManager.CreateAsync(userApp,registerModel.Password);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    AddErrorToModelState(identityResult.Errors);
                    return View();
                }
            }
            return View();
        }

        private void AddErrorToModelState(IEnumerable<IdentityError> errors)
        {
            foreach (IdentityError error in errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}