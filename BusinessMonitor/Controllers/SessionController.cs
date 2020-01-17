using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessMonitor.Models;
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

        public SessionController()
        {
            _userLogic = new UserLogic();
        }

        [Route("Login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var allUsers = new AdminViewModel(_userLogic.GetAllUsers());
            return User.Identity.IsAuthenticated ? View("Admin", allUsers) : View("Signin");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult LoginSubmit([Bind("Password, Username")] LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Signin");
            }

            if (_userLogic.Login(new User() { Username = user.Username, Password = user.Password }))
            {
                InitUser(user);
                return RedirectToAction("Admin");
            }
            return View("Signin");
        }

        [Route("Admin")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Admin()
        {
            var allUsers = new AdminViewModel(_userLogic.GetAllUsers());
            return User.Identity.IsAuthenticated ? View("Admin", allUsers) : View("Signin");
        }

        [HttpPost]
        public IActionResult RemoveUser(string id)
        {
            _userLogic.RemoveUser(id);
            return View("Item");
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

        private async void InitUser(LoginViewModel user)
        {
                var claims = new List<Claim>
            { new Claim(ClaimTypes.Name, MyID()) };
                if (AdminCheck())
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

        public string MyID()
        {
            return _userLogic.MyID();
        }

        private bool AdminCheck()
        {
            return _userLogic.AdminCheck();
        }
    }
}