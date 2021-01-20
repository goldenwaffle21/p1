using PizzaBox.Domain.Abstracts;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Store : AEntity
    {
        public List<Order> Orders{get;set;}
        public string Name {get;set;}
        public Store()
        {
            Orders = new List<Order>();
        }
    }
}
