using Domain.Entities;
using Domain.Getaways.Movies;

namespace Persistence.Getaways.Movies;

public class DeleteMovieGetaway : IDeleteMovieGetaway
{
    private readonly MvcMovieContext _context;

    public DeleteMovieGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieForDelete(long movieId)
    {
        var movieDbSet = _context.Set<Movie>();

        var movie = await movieDbSet.FindAsync(movieId);

        return movie;
    }

    public async Task Delete(Movie movie)
    {
        var movieDbSet = _context.Set<Movie>();

        movieDbSet.Remove(movie);

        await _context.SaveChangesAsync();
    }
}