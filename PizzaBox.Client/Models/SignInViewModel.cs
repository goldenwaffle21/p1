using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class SignInViewModel
    {
        public List<User> Users {get;set;}
        public User user {get;set;}
        public string UserName {get;set;}
        public string Address {get;set;}

        private PizzaBoxRepository _repo = new PizzaBoxRepository();
        public SignInViewModel()
        {
            let data = sessionStorage.getItem("user");
            if (data != null)
            {
                user = _repo.Get<User>().FirstOrDefault(u => u.Id == data);
            }
        }
    }
}
