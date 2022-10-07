using MovieWeb.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAsync();
        Task<Actor> GetAsync(int id);
        Task<Actor> UpdateAsync(int id, Actor actor);
        Task CreateAsync(Actor actor);
        Task DeleteAsync(int id);
    }
}
