using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class StoreViewModel
    {
        public List<string> Stores {get;set;}
        
        public StoreViewModel()
        {
            Stores = new List<string>{};
            //Pull all stores from database and add to Stores.
        }

        public StoreViewModel(string store)
        {
            Stores = new List<string>{store};
            //single store
        }
    }
}