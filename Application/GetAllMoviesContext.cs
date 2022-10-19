using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Getaways;

namespace Application;

public class GetAllMoviesContext
{
    private readonly IGetAllMoviesGetaway _getaway;

    public GetAllMoviesContext(IGetAllMoviesGetaway getaway)
    {

        _getaway = getaway;
    }

    public async Task<GetAllMoviesResponse> Execute(string movieGenre, string searchString)
    {
        var genres = await _getaway.GetGenres();
        var movies = await _getaway.GetAllMovies(movieGenre, searchString);

        return new GetAllMoviesResponse
        {
            Genres = genres,
            Movies = movies.Select(p => new MovieResponse
            {
                Id = p.Id,
                Title = p.Title,
                ReleaseDate = p.ReleaseDate,
                Price = p.Price,
                Genre = p.Genre,
                Rating = p.Rating
            }).ToList()
        };
    }
}

public class GetAllMoviesResponse
{
    public ICollection<string> Genres { get; set; }
    public ICollection<MovieResponse> Movies { get; set; }
}

public class MovieResponse
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}