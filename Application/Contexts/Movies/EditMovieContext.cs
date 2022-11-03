using Domain.Getaways.Movies;
using Domain.Base;
using Domain.Entities;

namespace Application.Contexts.Movies;

public sealed class EditMovieContext
{
    private readonly IEditMovieGetaway _getaway;

    public EditMovieContext(IEditMovieGetaway getaway)
    {
        _getaway = getaway;
    }

    public async Task<EditMovieRequest> GetMovieDetailsForEdit(long movieId)
    {
        var movie = await _getaway.GetMovieForEdit(movieId);

        return new EditMovieRequest
        {
            Id = movie.Id,
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            Genre = movie.Genre,
            Rating = movie.Rating
        };
    }

    public async Task<Result> Execute(long id, EditMovieRequest request)
    {

        var movie = await _getaway.GetMovieForEdit(id);

        if (movie == null) return Result.Failure($"Cannot find movie with id: {id}");

        var movieToEdit = movie.Edit(request.Title, request.ReleaseDate, request.Price, request.Genre, request.Rating);

        if (movieToEdit.IsFailure)
        {
            return Result.Failure(movieToEdit.Error);
        }

        await _getaway.Edit(movieToEdit.Value);

        return Result.Success();
    }


}

public class EditMovieRequest
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}