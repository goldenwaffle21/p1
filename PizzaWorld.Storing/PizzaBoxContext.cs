using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public class PizzaBoxContext : DbContext
    {
        public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) {}

        public DbSet<Store> Stores {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Order> Orders {get;set;}
        //Don't need to save Pizzas or Toppings since their content already exists in 
        //the other data.

        /*protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_configuration.GetConnectionString("sqlserver"));
            //Storing the server string in appsettings.json allows you to isolate it
            //for additional security.
        }*/
        //Now injected automatically

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.Id); 
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<Pizza>().HasKey(p => p.Id);
            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<Topping>().HasKey(t => t.Id);

            builder.Entity<Store>().Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(o => o.Id).ValueGeneratedOnAdd();

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>
                {
                    new Store() {Id = "1", Name = "Washington"},
                    new Store() {Id = "2", Name = "Florida"},
                    new Store() {Id = "3", Name = "Texas"}
                }
            );
        }
    }
}
