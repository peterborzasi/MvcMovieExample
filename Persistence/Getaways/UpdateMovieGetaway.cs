using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Getaways;

public class UpdateMovieGetaway
{
    private readonly MvcMovieContext _context;

    public UpdateMovieGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Movie?> GetMovieForUpdate(long movieId)
    {
        var movieDbSet = _context.Set<Movie>();

        var movie = await movieDbSet.FindAsync(movieId);

        return movie;
    }

    public async Task Update(Movie movie)
    {
        var movieDbSet = _context.Set<Movie>();

        movieDbSet.Update(movie);

        await _context.SaveChangesAsync();
    }
}