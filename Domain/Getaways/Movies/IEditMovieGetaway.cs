using Domain.Entities;

namespace Domain.Getaways.Movies;

public interface IEditMovieGetaway
{
    Task<Movie> GetMovieForEdit(long movieId);
    Task Edit(Movie movie);
}