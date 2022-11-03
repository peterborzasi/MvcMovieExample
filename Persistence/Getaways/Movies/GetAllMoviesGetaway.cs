using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Getaways.Movies;

namespace Persistence.Getaways.Movies;

public class GetAllMoviesGetaway : IGetAllMoviesGetaway
{
    private readonly MvcMovieContext _context;

    public GetAllMoviesGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<ICollection<string>> GetGenres()
    {
        var movieDbSet = _context.Set<Movie>();

        ICollection<string> genreQuery = await movieDbSet
            .OrderBy(p => p.Genre)
            .Select(p => p.Genre).Distinct().ToListAsync();

        return genreQuery;
    }

    public async Task<ICollection<Movie>> GetAllMovies(string movieGenre, string searchString)
    {
        var movieDbSet = _context.Set<Movie>();


        var movies = from m in movieDbSet select m;

        if (!string.IsNullOrEmpty(searchString))
        {
            movies = movies.Where(s => s.Title!.Contains(searchString));
        }

        if (!string.IsNullOrEmpty(movieGenre))
        {
            movies = movies.Where(x => x.Genre == movieGenre);
        }

        return await movies.ToListAsync();
    }
}
