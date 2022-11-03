using Domain.Getaways.Movies;
using Domain.Base;

namespace Application.Contexts.Movies;

public sealed class DeleteMovieContext
{
    private readonly IDeleteMovieGetaway _getaway;

    public DeleteMovieContext(IDeleteMovieGetaway getaway)
    {
        _getaway = getaway;
    }

    public async Task<DeleteMovieRequest> GetMovieDetailsForDelete(long movieId)
    {
        var movie = await _getaway.GetMovieForDelete(movieId);

        return new DeleteMovieRequest
        {
            Id = movie.Id,
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            Genre = movie.Genre,
            Rating = movie.Rating
        };
    }

    public async Task<Result> Execute(long id, DeleteMovieRequest request)
    {

        var movie = await _getaway.GetMovieForDelete(id);

        if (movie == null) return Result.Failure($"Cannot find movie with id: {id}");

        var movieToDelete = movie.Delete(request.Title, request.ReleaseDate, request.Price, request.Genre, request.Rating);

        if (movieToDelete.IsFailure)
        {
            return Result.Failure(movieToDelete.Error);
        }

        await _getaway.Delete(movieToDelete.Value);

        return Result.Success();
    }


}

public class DeleteMovieRequest
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}