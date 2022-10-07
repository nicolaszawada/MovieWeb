using Microsoft.EntityFrameworkCore;
using MovieWeb.Database;
using MovieWeb.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Services.Impl
{
    public class ActorService : IActorService
    {
        private readonly MovieContext _movieContext;

        public ActorService(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task CreateAsync(Actor actor)
        {
            await _movieContext.Actors.AddAsync(actor);
            await _movieContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _movieContext.Actors.FindAsync(id);

            _movieContext.Actors.Remove(actor);

            await _movieContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAsync()
        {
            return await _movieContext.Actors.ToListAsync();
        }

        public async Task<Actor> GetAsync(int id)
        {
            return await _movieContext.Actors.FindAsync(id);
        }

        public async Task<Actor> UpdateAsync(int id, Actor updateActor)
        {
            var actor = await _movieContext.Actors.SingleOrDefaultAsync(x => x.Id == id);

            if(actor == null)
            {
                return null;
            }

            actor.FirstName = updateActor.FirstName;
            actor.LastName = updateActor.LastName;


            await _movieContext.SaveChangesAsync();

            return null;
        }
    }
}
