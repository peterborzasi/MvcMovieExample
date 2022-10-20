using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Domain.Clients;

namespace Domain.Entities;

public class Movie : Entity
{
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string? Rating { get; set; }

    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    private Movie()
    {
    }

    private Movie(string title, DateTime releaseDate, decimal price, string? genre, string? rating)
    {
        Title = title;
        ReleaseDate = releaseDate;
        Price = price;
        Genre = genre;
        Rating = rating;
    }

    public static Result<Movie> Create(string title, DateTime releaseDate, decimal price, string? genre, string? rating)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Movie>("Movie title is mandatory");
        }

        title = title.Trim();

        if (title.Length is < 3 or > 60)
        {
            return Result.Failure<Movie>("Movie title must be between 3 and 60 characters");
        }

        var movie = new Movie(title, releaseDate, price, genre, rating);

        return Result.Success(movie);
    }

    public Result<Movie> Update(string title, DateTime releaseDate, decimal price, string? genre, string? rating)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Movie>("Movie title is mandatory");
        }

        title = title.Trim();

        if (title.Length is < 3 or > 60)
        {
            return Result.Failure<Movie>("Movie title must be between 3 and 60 characters");
        }

        Title = title;
        ReleaseDate = releaseDate;
        Price = price;
        Genre = genre;
        Rating = rating;

        return Result.Success(this);
    }
}