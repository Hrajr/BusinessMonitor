using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Interface;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMonitor.Controllers
{
    public class SessionController : Controller
    {
        private readonly UserLogic _userLogic;

        public SessionController(iUser context)
        {
            _userLogic = new UserLogic(context);
        }

        [Route("Login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return User.Identity.IsAuthenticated ? View("Profile") : View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult LoginSubmit([Bind("Password, Username")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            if (_userLogic.Login(user))
            {
                InitUser(user);
                if (_userLogic.AdminCheck(user))
                {
                    return RedirectToAction("AdminPage", "Home");
                }
                return RedirectToAction("Profile", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            LogOut();
            return RedirectToAction("Login", "Session");
        }

        private async void LogOut()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async void InitUser(User user)
        {
            user.Admin = _userLogic.AdminCheck(user);
            var claims = new List<Claim>
            { new Claim(ClaimTypes.Name, user.ID) };
            if (user.Admin)
            { claims.Add(new Claim(ClaimTypes.Role, "Admin")); }
            else
            { claims.Add(new Claim(ClaimTypes.Role, "User")); }


            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            var authProp = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20) //Cookies will be saved for 20 minutes
            };
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProp);
        }
    }
}