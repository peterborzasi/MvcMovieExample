using Domain.Entities;

namespace Domain.Getaways.Movies;

public interface ICreateMovieGetaway
{
    Task Create(Movie movie);
}