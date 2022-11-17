using Microsoft.EntityFrameworkCore;
using PizzaWebApi.Models;

namespace PizzaWebApi.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaContext _context;

        public PizzaRepository(PizzaContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Create(Pizza pizza)
        {
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task Delete(int id)
        {
            var book = await _context.Pizzas.FindAsync(id);
            if (book is not null)
            {
                _context.Pizzas.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza?> Get(int id)
        {
            return await _context.Pizzas.FindAsync(id);
        }

        public async Task Update(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
