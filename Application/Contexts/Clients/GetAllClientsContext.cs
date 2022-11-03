using Domain.Clients.ValueObjects;
using Domain.Getaways.Clients;
using Application.Contexts.Movies;

namespace Application.Contexts.Clients;

public class GetAllClientsContext
{
    private readonly IGetAllClientsGetaway _getaway;

    public GetAllClientsContext(IGetAllClientsGetaway getaway)
    {

        _getaway = getaway;
    }

    public async Task<GetAllClientsResponse> Execute()
    {
         var clients = await _getaway.GetAllClients();

        return new GetAllClientsResponse
        {
            Clients = clients.Select(p => new ClientResponse
            {
                Name = p.Name,
                Email = p.Email,
                Address = p.Address,
            }).ToList()
        };
    }
}

public class GetAllClientsResponse
{
    public ICollection<ClientResponse> Clients { get; set; }
    public ICollection<MovieResponse> OwnedMovies { get; set; }
}

public class ClientResponse
{
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
}