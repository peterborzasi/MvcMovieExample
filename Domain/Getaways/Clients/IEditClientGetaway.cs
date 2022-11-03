using Domain.Entities.Clients;

namespace Domain.Getaways.Clients;

public interface IEditClientGetaway
{
    Task<Client> GetClientForEdit(long clientId);
    Task Edit(Client client);
}