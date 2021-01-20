using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("{controller}")]
    public class StoreController : Controller
    {
        [HttpGet()]    //http://localhost:5000/store
        public IActionResult Get()    //Get all stores
        {
            /*    //All this is weakly typed.
            var stores = (new StoreViewModel()).Stores;

            //1-way data binding; action to view
            ViewBag.Stores = stores;    //dynamic object; type determined by current value
            //ViewData["Stores"] = stores;    //dictionary object; Dictionary<string, object>

            //redirect data binding; survives for the lifetime of the request, until the final response
            //TempData["Stores"] = stores;

            return View("Store");
            */

            return View("Store", new StoreViewModel());    //allows for a strongly typed view; see view
        }

        [HttpGet("{store}")]    //http://localhost:5000/store/<specifier for individual store>
        public IActionResult Get(string store)    //Get current store.
        {
            return View("Store", store, new StoreViewModel);
        }

        //public void Post() {}

        //public void Put() {}

        //public void Delete() {}
    }
}
