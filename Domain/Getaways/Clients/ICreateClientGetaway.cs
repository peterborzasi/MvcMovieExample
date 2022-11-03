using Domain.Entities.Clients;

namespace Domain.Getaways.Clients;

public interface ICreateClientGetaway
{
    Task Create(Client client);
}