using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PizzaBox.Client.Models
{
    public class SignInViewModel
    {
        public List<User> Users {get;set;}
        [Required]
        public string User {get;set;}
        public string UserName {get;set;}
        public string Address {get;set;}

        private PizzaBoxRepository _repo;
        public SignInViewModel(PizzaBoxRepository context)
        {
            _repo = context;
            var data = sessionStorage.getItem("user");
            if (data != null)
            {
                User = _repo.Get<User>().FirstOrDefault(u => u.Id == data);
            }
        }
    }
}
