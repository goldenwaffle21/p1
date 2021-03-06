using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel
    {
        //purely output
        public List<Store> Stores {get;set;}
        public List<Pizza> Pizzas {get;set;}
        public List<string> Bases {get;set;}
        public List<string> Sizes {get;set;}
        public List<string> Crusts {get;set;}
        public List<string> Sauces {get;set;}
        public List<string> CurrentToppings {get;set;}

        [Required(ErrorMessage = "You must select a store")]
        public string Store {get;set;}

        public int NumberOfUniquePizzas {get;set;}

        //note: maybe go back through and make names plural
        [Required]
        public List<string> Base {get;set;}
        [Required]
        public List<string> Size {get;set;}
        [Required]
        public List<string> Crust {get;set;}
        [Required]
        public List<string> GlutenFree {get;set;}
        [Required]
        public List<string> Sauce {get;set;}
        [Required]
        public List<List<string>> Toppings {get;set;}
        [Required]
        public List<int> Quantity {get;set;}
        [Required]
        public List<decimal> Price {get;set;}

        [Required]
        [Range(2,50, ErrorMessage = "You must order at least 2 and no more than 50 pizzas")]
        public int NumberOfPizzas {get;set;}

        [Required]
        [Range(0,250, ErrorMessage = "Price cannot exceed $250 for a single order")]
        public decimal TotalPrice {get;set;}

        [Required(ErrorMessage = "Customer name is required")]
        public string UserName {get;set;}

        public string Address {get;set;}


        private PizzaBoxRepository _repo;

        public OrderViewModel(PizzaBoxRepository context)
        {
            _repo = context;
            Stores = _repo.Get<Store>(); //retrieve from database.
            Pizzas = new List<Pizza>{new Pizza(), new Pizza()};
            Bases = new List<string>{"Custom","Cheese","Hawaiian","Meat","Pesto"};
            Sizes = new List<string>{"Small","Medium","Large"};
            Crusts = new List<string>{"Regular","Deep Dish","Stuffed","Thin"};
            Sauces = new List<string>{"Alfredo","Pesto","Tomato"};

            //sessionStorage exists only in the browser; it can only be accessed through View.
            //Store the current user (or lack thereof) in the context instead
            if (sessionStorage.getItem("user") != null)
            {
                User user = _repo.Get<User>().FirstOrDefault(u => u.Id == sessionStorage.getItem("user"));
                UserName = user.Name;
                Address = user.Address;
                Store = user.SelectedStore.Name;
            }
        }

        public OrderViewModel(PizzaBoxRepository context, Order order)
        {
            _repo = context;
            Stores = _repo.Get<Store>();    //retrieve from database.
            Store = order.Store.Name;
            Pizzas = order.Pizzas;
            Bases = new List<string>{"Custom","Cheese","Hawaiian","Meat","Pesto"};
            Sizes = new List<string>{"Small","Medium","Large"};
            Crusts = new List<string>{"Regular","Deep Dish","Stuffed","Thin"};
            Sauces = new List<string>{"Alfredo","Pesto","Tomato"};
            UserName = order.User.Name;
            Address = order.User.Address;
        }
    }
}
