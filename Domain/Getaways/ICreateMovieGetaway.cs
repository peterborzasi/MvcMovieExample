using Domain.Entities;

namespace Domain.Getaways;

public interface ICreateMovieGetaway
{
    Task Create(Movie movie);
}