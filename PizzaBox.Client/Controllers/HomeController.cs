using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly PizzaBoxRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PizzaBoxRepository context, ILogger<HomeController> logger)
        {
            _repo = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Order", new OrderViewModel(_repo));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
