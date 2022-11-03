using Domain.Entities;

namespace Domain.Getaways.Movies;

public interface IDeleteMovieGetaway
{
    Task<Movie> GetMovieForDelete(long movieId);
    Task Delete(Movie movie);
}