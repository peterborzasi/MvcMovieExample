using Domain.Base;
using Domain.Entities.Clients;
using Domain.Clients.ValueObjects;
using Domain.Getaways.Clients;

namespace Application.Contexts.Clients;

public sealed class CreateClientContext
{
    private readonly ICreateClientGetaway _getaway;

    public CreateClientContext(ICreateClientGetaway getaway)
    {
        _getaway = getaway;
    }

    public async Task<Result> Execute(CreateClientRequest request)
    {
        var client = Client.Create(request.Name, request.Email, request.Address);

        if (client.IsFailure)
        {
            return Result.Failure(client.Error);
        }

        await _getaway.Create(client.Value);

        return Result.Success();
    }
}

public class CreateClientRequest
{
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
}
