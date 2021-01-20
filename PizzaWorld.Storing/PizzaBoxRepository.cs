using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Storing
{
    public class PizzaBoxRepository
    {
        private readonly PizzaBoxContext _ctx;
        //Used to be static, but is now dependent on an instance

        public PizzaBoxRepository(PizzaBoxContext context)
        {
            _ctx = context;
        }

        public List<T> Get<T>() where T : AEntity
        {
            return _ctx.Set<T>().ToList();
            //returns all T from the context as a list.
            //Example was static, but this is definitely dependent on an instance of the class
        }

        public void Add(Store store)
        {
            _ctx.Stores.Add(store);
            _ctx.SaveChanges();
        }
        public void Add(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void Update(Store store)
        {
            _ctx.Stores.Update(store);
            _ctx.SaveChanges();
        }
        public void Update(User user)
        {
            _ctx.Users.Update(user);
            _ctx.SaveChanges();
        }

        public void Delete(string orderid)
        {
            Order order = Get<Order>().FirstOrDefault(o => o.Id == orderid);
            _ctx.Orders.Remove(order);
            _ctx.SaveChanges();
        }
    }
}