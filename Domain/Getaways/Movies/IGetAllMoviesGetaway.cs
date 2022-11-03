using Domain.Entities;

namespace Domain.Getaways.Movies;

public interface IGetAllMoviesGetaway
{
    Task<ICollection<string>> GetGenres();
    Task<ICollection<Movie>> GetAllMovies(string movieGenre, string searchString);
}
