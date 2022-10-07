using Microsoft.EntityFrameworkCore;
using MovieWeb.Domain;

namespace MovieWeb.Database
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) 
            : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
    }
}
