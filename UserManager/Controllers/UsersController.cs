using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private Microsoft.AspNetCore.Identity.SignInManager<AppUser> signInManager;
        private Microsoft.AspNetCore.Identity.IPasswordValidator<AppUser> passwordValidator;
        private Microsoft.AspNetCore.Identity.IPasswordHasher<AppUser> passwordHasher;

        public UsersController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userMgr,
            Microsoft.AspNetCore.Identity.SignInManager<AppUser> signinMgr,
            Microsoft.AspNetCore.Identity.IPasswordValidator<AppUser> passValidator,
            Microsoft.AspNetCore.Identity.IPasswordHasher<AppUser> passwordHash)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            passwordValidator = passValidator;
            passwordHasher = passwordHash;
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
                    "Invalid user or password");
            }
            return View(details);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateModel details)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = details.Name,
                    Email = details.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, details.Password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(details);
        }

        public IActionResult ChangePassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel details)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            IdentityResult validPassword = null;
            if (!string.IsNullOrEmpty(details.Password))
            {
                validPassword = await passwordValidator.ValidateAsync(userManager, user, details.Password);
                if (validPassword.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, details.Password);
                    return Redirect("/");
                }
                else
                {
                    foreach (IdentityError error in validPassword.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(details);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
