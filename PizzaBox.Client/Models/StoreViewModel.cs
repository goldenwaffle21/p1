using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public List<Store> Stores {get;set;}
    
    public StoreViewModel()
    {
        Stores = new List<>{};
        //Pull all stores from database and add to Stores.
    }

    public StoreViewModel(string store)
    {
        Stores = new List<>{};
        //single store
    }
}