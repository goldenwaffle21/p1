using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
    public class Pizza : AEntity
    {
        [Required(ErrorMessage = "Every pizza must have a base")]
        public string Base {get;set;}

        [Required(ErrorMessage = "Every pizza must have a Crust")]
        public string Crust {get;set;}

        public string GlutenFree {get;set;}

        [Required(ErrorMessage = "Every pizza must have a size")]
        public string Size {get;set;}
        
        [Required(ErrorMessage = "Every pizza must have a sauce")]
        public string Sauce {get;set;}
        
        [Required]
        [Range(2,5, ErrorMessage = "Every pizza must have at least 2 and no more than 5 toppings")]
        public List<Topping> Toppings;

        [Required]
        public decimal Price {get;set;}
    }
}
