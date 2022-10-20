using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                context.Database.EnsureCreated();

                var movieDbSet = context.Set<Movie>();

                // Look for any movies.
                if (movieDbSet.Any())
                {
                    return;   // DB has been seeded
                }

                movieDbSet.AddRange(
                    Movie.Create("When Harry Met Sally", DateTime.Parse("1989-2-12"), 7.99M ,"Romantic Comedy", "R").Value

                    // new Movie
                    // {
                    //     Title = "Ghostbusters ",
                    //     ReleaseDate = DateTime.Parse("1984-3-13"),
                    //     Genre = "Comedy",
                    //     Rating = "R",
                    //     Price = 8.99M
                    // },
                    //
                    // new Movie
                    // {
                    //     Title = "Ghostbusters 2",
                    //     ReleaseDate = DateTime.Parse("1986-2-23"),
                    //     Genre = "Comedy",
                    //     Rating = "R",
                    //     Price = 9.99M
                    // },
                    //
                    // new Movie
                    // {
                    //     Title = "Rio Bravo",
                    //     ReleaseDate = DateTime.Parse("1959-4-15"),
                    //     Genre = "Western",
                    //     Rating = "R",
                    //     Price = 3.99M
                    // }
                );
                context.SaveChanges();
            }
        }
    }
}