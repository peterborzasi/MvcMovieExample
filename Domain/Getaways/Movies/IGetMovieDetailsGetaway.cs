using Domain.Entities;

namespace Domain.Getaways.Movies;

public interface IGetMovieDetailsGetaway
{
    Task<Movie> GetMovieDetails(long movieId);
}