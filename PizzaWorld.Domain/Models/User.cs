using PizzaBox.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class User : AEntity
    {
        public List<Order> Orders {get;set;}
        public Store SelectedStore {get;set;}
        public string Name {get;set;}
        public string Address {get;set;}
        
        public User()
        {
            Orders = new List<Order>(){};
        }
    }
}