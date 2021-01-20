using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        public User User {get;set;}
        public string UserId {get;set;}

        public CustomerViewModel(User user)
        {
            User = user;
            UserId = User.Id;
        }
    }
}