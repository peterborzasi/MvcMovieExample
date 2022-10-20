﻿using Domain.Entities;
using Domain.Getaways;

namespace Persistence.Getaways;

public sealed class CreateMovieGetaway : ICreateMovieGetaway
{
    private readonly MvcMovieContext _context;

    public CreateMovieGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task Create(Movie movie)
    {
        var dbSet = _context.Set<Movie>();

        await dbSet.AddAsync(movie);

        await _context.SaveChangesAsync();
    }
}