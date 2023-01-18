using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.Site.Data;
using Movie.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movie.Site.Controllers
{
    [AllowAnonymous] //Kurallardan muaf olmalı.

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager; //register için
        private readonly SignInManager<IdentityUser> _signInManager; //login için

        public AccountController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserMail,
                    Email = model.UserMail,
                };

                var result = await _userManager.CreateAsync(user, model.UserPassword);

                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login", "Account");
                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    //ModelState.AddModelError(string.Empty, "Geçersiz Giriş Denemesi")

                }
            }
            return View(model);
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Login()
        {      
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
           
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movie");
                }

                ModelState.AddModelError(string.Empty, "Hatalı Giriş Denemesi");

            }
            return View(login);
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}















//[AllowAnonymous]
