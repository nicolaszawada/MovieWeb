using MovieWeb.Domain;
using System;
using System.Linq;

namespace MovieWeb.Database
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();

            if (context.Actors.Any())
            {
                return;
            }

            var actors = new Actor[]
            {
                new Actor(){ FirstName = "Tom", LastName = "Cruise", Birthdate = DateTime.Now.AddYears(-5)},
                new Actor(){ FirstName = "Johnny", LastName = "Depp", Birthdate = DateTime.Now.AddYears(-6)},
            };

            foreach (var actor in actors)
            {
                context.Actors.Add(actor);
            }

            context.SaveChanges();
        }
    }
}
