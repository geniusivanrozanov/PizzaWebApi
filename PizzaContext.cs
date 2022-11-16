using Microsoft.EntityFrameworkCore;
using PizzaWebApi.Models;

namespace PizzaWebApi
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
