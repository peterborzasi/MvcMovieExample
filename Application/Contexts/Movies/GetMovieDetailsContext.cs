using Domain.Getaways.Movies;

namespace Application.Contexts.Movies;

public class GetMovieDetailsContext
{
    private readonly IGetMovieDetailsGetaway _getaway;

    public GetMovieDetailsContext(IGetMovieDetailsGetaway getaway)
    {

        _getaway = getaway;
    }

    public async Task<GetMovieDetailsResponse> Execute(long movieId)
    {
        var movie = await _getaway.GetMovieDetails(movieId);

        return new GetMovieDetailsResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            Genre = movie.Genre,
            Rating = movie.Rating
        };
    }
}

public class GetMovieDetailsResponse
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}