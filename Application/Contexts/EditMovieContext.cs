using Domain.Getaways;
using Domain.Base;
using Domain.Entities;

namespace Application.Contexts;

public sealed class EditMovieContext
{
    private readonly IEditMovieGetaway _getaway;

    public EditMovieContext(IEditMovieGetaway getaway)
    {
        _getaway = getaway;
    }


}


public class EditMovieRequest
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}