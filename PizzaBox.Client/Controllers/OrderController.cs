using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly PizzaBoxRepository _repo;

        public OrderController(PizzaBoxRepository context)
        {
            _repo = context;
        }

        //Creating an order does not require authorization.
        [HttpGet]
        public IActionResult Get()
        {
            return View("Order", new OrderViewModel(_repo));
        }

        //View an old order; requires authorization.
        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(string orderid)
        {
            Order order = _repo.Get<Order>().FirstOrDefault(o => o.Id == orderid);
            return View("Order", new OrderViewModel(_repo, order));
        }
        
        //Creating an order does not require authorization.
        [HttpPost]
        //[ValidateAntiforgeryToken]
        public IActionResult Order(OrderViewModel model)
        {
            if (ModelState.IsValid)    //validate user input
            {
                var order = new Order()
                {
                    DateModified = DateTime.Now,
                    Store = _repo.Get<Store>().FirstOrDefault(s => s.Name == model.Store),
                    Pizzas = new List<Pizza>(){},
                    NumberOfPizzas = model.NumberOfPizzas,
                    TotalPrice = model.TotalPrice,
                    Status = "not yet delivered"
                };
                for (int i = 1; i <= model.NumberOfUniquePizzas; i++)
                {
                    Pizza pizza = new Pizza()
                    {
                        Base = model.Base[i],
                        Size = model.Size[i],
                        Crust = model.Crust[i],
                        GlutenFree = model.GlutenFree[i],
                        Sauce = model.Sauce[i],
                        Price = model.Price[i]
                    };
                    foreach (string topping in model.Toppings[i])
                    {
                        pizza.Toppings.Add(new Topping(topping));
                    }
                    for (int j = 0; j <= model.Quantity[i]; j++)
                    {
                        if (j==0) {continue;}
                        order.Pizzas.Add(pizza);
                    }
                }

                User user;
                if (_repo.Get<User>().FirstOrDefault(u => u.Name == model.UserName) != null)
                {
                    order.User = _repo.Get<User>().FirstOrDefault(u => u.Name == model.UserName);
                    user = order.User;
                    user.Orders.Add(order);
                    _repo.Update(user);
                }
                else
                {
                    user = new User()
                    {
                        Name = model.UserName,
                        Address = model.Address,
                        SelectedStore = _repo.Get<Store>().FirstOrDefault(o => o.Name == model.Store)
                    };
                    user.Orders.Add(order);
                    order.User = user;
                    _repo.Add(user);
                }
                sessionStorage.setItem(user,user.Id);

                return View("OrderPlaced", new CustomerViewModel(order.User));
            }
            return View("Order", model);
        }

        //Modify an old order; requires authorization.
        //[Authorize]
        [HttpPut]
        public IActionResult Put(string orderid)
        {
            Order order = _repo.Get<Order>().FirstOrDefault(o => o.Id == orderid);
            return View("Order", new OrderViewModel(_repo, order));
        }

        //Deliver order
        //[Authorize(Store)]
        [HttpPut]
        public void Deliver(string orderid)
        {
            Order order = _repo.Get<Order>().FirstOrDefault(o => o.Id == orderid);
            order.Status = "delivered";
        }

        //Cancel an old order; requires authorization.
        //[Authorize]
        [HttpDelete]
        public void Delete(string orderid)
        {
            _repo.Delete(orderid);
        }
    }
}
