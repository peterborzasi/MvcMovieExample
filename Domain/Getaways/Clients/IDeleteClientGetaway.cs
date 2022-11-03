using Domain.Entities.Clients;

namespace Domain.Getaways.Clients;

public interface IDeleteClientGetaway
{
    Task<Client> GetClientForDelete(long clientId);
    Task Delete(Client client);
}