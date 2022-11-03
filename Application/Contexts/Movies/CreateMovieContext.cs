using Domain.Getaways.Movies;
using Domain.Base;
using Domain.Entities;

namespace Application.Contexts.Movies;

public sealed class CreateMovieContext
{
    private readonly ICreateMovieGetaway _getaway;

    public CreateMovieContext(ICreateMovieGetaway getaway)
    {
        _getaway = getaway;
    }

    public async Task<Result> Execute(CreateMovieRequest request)
    {
        var movie = Movie.Create(request.Title, request.ReleaseDate, request.Price, request.Genre, request.Rating);

        if (movie.IsFailure)
        {
            return Result.Failure(movie.Error);
        }

        await _getaway.Create(movie.Value);

        return Result.Success();
    }
}

public class CreateMovieRequest
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}
