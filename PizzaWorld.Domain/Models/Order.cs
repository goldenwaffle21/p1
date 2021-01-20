using PizzaBox.Domain.Abstracts;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Order : AEntity
    {
        public DateTime DateModified {get;set;}

        public Store Store {get;set;}

        public User User {get;set;}
    
        public List<Pizza> Pizzas {get;set;}

        public string Status {get;set;}

        public int NumberOfPizzas {get;set;}

        public decimal TotalPrice {get;set;}
    }
}
