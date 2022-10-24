using Domain.Entities;
using Domain.Getaways;

namespace Persistence.Getaways;

public class EditMovieGetaway : IEditMovieGetaway
{
    private readonly MvcMovieContext _context;

    public EditMovieGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Movie?> GetMovieForEdit(long movieId)
    {
        var movieDbSet = _context.Set<Movie>();

        var movie = await movieDbSet.FindAsync(movieId);

        return movie;
    }

    public async Task Edit(Movie movie)
    {
        var movieDbSet = _context.Set<Movie>();

        movieDbSet.Update(movie);

        await _context.SaveChangesAsync();
    }
}