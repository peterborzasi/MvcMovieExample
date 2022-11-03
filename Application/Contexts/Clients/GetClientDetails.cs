using Domain.Clients.ValueObjects;
using Domain.Getaways.Clients;

namespace Application.Contexts.Clients;

public class GetClientDetailsContext
{
    private readonly IGetClientDetailsGetaway _getaway;

    public GetClientDetailsContext(IGetClientDetailsGetaway getaway)
    {

        _getaway = getaway;
    }

    public async Task<GetClientDetailsResponse> Execute(long clientId)
    {
        var client = await _getaway.GetClientDetails(clientId);

        return new GetClientDetailsResponse
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Address = client.Address,
        };
    }
}

public class GetClientDetailsResponse
{
    public long Id { get; set; }
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
}