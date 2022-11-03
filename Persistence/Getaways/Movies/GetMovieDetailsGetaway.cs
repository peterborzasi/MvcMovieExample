using Domain.Entities;
using Domain.Getaways.Movies;

namespace Persistence.Getaways.Movies;

public class GetMovieDetailsGetaway : IGetMovieDetailsGetaway
{
    private readonly MvcMovieContext _context;

    public GetMovieDetailsGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieDetails(long movieId)
    {
        var movieDbSet = _context.Set<Movie>();

        var movie = await movieDbSet.FindAsync(movieId);

        return movie;
    }

}
