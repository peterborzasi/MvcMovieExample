using Domain.Entities;

namespace Domain.Getaways;

public interface IEditMovieGetaway
{
    Task Edit(Movie movie);
}