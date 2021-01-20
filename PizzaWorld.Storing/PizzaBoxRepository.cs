namespace PizzaBox.Storing
{
    public class PizzaBoxRepository
    {
        private static readonly PizzaBoxContext _ctx;

        public PizzaBoxRepository(PizzaBoxContext context)
        {
            _ctx = context;
        }

        public static IEnumerable<T> Get<T>() where T : AEntity
        {
            return _ctx.Set<T>().ToList();
            //returns all T from the context as a list.
        }

        public void Add(Store store)
        {
            _ctx.Add(store);
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
            _ctx.Stores.Update(user);
            _ctx.SaveChanges();
        }

        public void Delete(string orderid)
        {
            _ctx.Orders.Remove(o => o.Id == orderid);
            _ctx.SaveChanges();
        }
    }
}