using PizzaWebApi.Models;

namespace PizzaWebApi.Repositories
{
    public interface IPizzaRepository : IDisposable
    {
        public Task<IEnumerable<Pizza>> Get();
        public Task<Pizza?> Get(int id);
        public Task<Pizza> Create(Pizza pizza);
        public Task Update(Pizza pizza);
        public Task Delete(int id);
    }
}
