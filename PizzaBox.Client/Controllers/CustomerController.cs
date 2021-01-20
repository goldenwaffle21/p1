using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaBox.Client.Controllers
{
    public class CustomerController : Controller
    {
        private readonly PizzaBoxRepository _repo;

        public CustomerController(PizzaBoxRepository context)
        {
            _repo = context;
        }

        //Customer home
        [HttpGet]
        public IActionResult Home()
        {
            string userid = sessionStorage.getItem("user");
            var user = _repo.Get<User>().FirstOrDefault(u => u.Id == userid);
            if (user != null)
            {
                return View("Home", new CustomerViewModel(user));
            }
            else
            {
                sessionStorage.setItem("user",null);
                return View("SignIn", new SignInViewModel(_repo));
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            sessionStorage.setItem("user",null);
            return View("SignIn", new SignInViewModel(_repo));

        }

        //Explicit Sign In
        [HttpPost]
        //[ValidateAntiforgeryToken]
        public IActionResult Post(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user;
                if (model.User != "")
                {
                    user = _repo.Get<User>().FirstOrDefault(u => u.Name == model.User);
                    sessionStorage.setItem("user",user.Id);
                }
                else
                {
                    user = new User()
                    {
                        Name = model.UserName,
                        Address = model.Address
                    };
                    _repo.Add(user);
                    user = _repo.Get<User>().Last();    //now with auto-generated ID
                    sessionStorage.setItem("user",user.Id);
                }

                return View("Home", new CustomerViewModel(sessionStorage.getItem("user")));
            }
            return View("SignIn",model);
        }
    }
}
