using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessMonitor.Models;
using Logic;
using DAL.Interface;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;

namespace BusinessMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserLogic _userLogic;

        public HomeController()
        {
            _userLogic = new UserLogic();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reference()
        {
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }

        [Route("Registration")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegistrationForm([Bind("Username, Password, Firstname, Lastname, Address, Zipcode, Place, Phone, Email, Admin")] RegisterViewModel viewmodel)
        {
            var newUser = new User()
            {
                Username = viewmodel.Username,
                Password = viewmodel.Password,
                Firstname = viewmodel.Firstname,
                Lastname = viewmodel.Lastname,
                Address = viewmodel.Address,
                Zipcode = viewmodel.Zipcode,
                Place = viewmodel.Place,
                Phone = viewmodel.Phone,
                Email = viewmodel.Email,
                Admin = viewmodel.Admin
            };
            if (!ModelState.IsValid || !_userLogic.Registration(newUser))
            { return View("Registration"); }
            return RedirectToAction("Login", "Session");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
