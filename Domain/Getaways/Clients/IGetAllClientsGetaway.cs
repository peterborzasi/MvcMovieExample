using Domain.Entities.Clients;
using Domain.Entities;

namespace Domain.Getaways.Clients;

public interface IGetAllClientsGetaway
{
    Task<ICollection<Client>> GetAllClients();
    //Task<ICollection<Movie>> GetOwnedMovies();
}