using Domain.Getaways.Clients;
using Domain.Base;
using Domain.Clients.ValueObjects;

namespace Application.Contexts.Clients;

public sealed class DeleteClientContext
{
    private readonly IDeleteClientGetaway _getaway;

    public DeleteClientContext(IDeleteClientGetaway getaway)
    {
        _getaway = getaway;
    }

    public async Task<DeleteClientRequest> GetClientDetailsForDelete(long clientId)
    {
        var client = await _getaway.GetClientForDelete(clientId);

        return new DeleteClientRequest
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Address = client.Address,
        };
    }

    public async Task<Result> Execute(long id, DeleteClientRequest request)
    {

        var client = await _getaway.GetClientForDelete(id);

        if (client == null) return Result.Failure($"Cannot find client with id: {id}");

        var clientToDelete = client.Delete(request.Id, request.Name, request.Email, request.Address);

        if (clientToDelete.IsFailure)
        {
            return Result.Failure(clientToDelete.Error);
        }

        await _getaway.Delete(clientToDelete.Value);

        return Result.Success();
    }


}

public class DeleteClientRequest
{
    public long Id { get; set; }
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
}