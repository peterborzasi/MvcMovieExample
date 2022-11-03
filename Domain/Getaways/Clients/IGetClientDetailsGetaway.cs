using Domain.Entities.Clients;

namespace Domain.Getaways.Clients;

public interface IGetClientDetailsGetaway
{
    Task<Client> GetClientDetails(long clientId);
}