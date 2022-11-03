using Domain.Getaways.Clients;
using Domain.Base;
using Domain.Entities.Clients;
using Domain.Clients.ValueObjects;

namespace Application.Contexts.Clients;

public sealed class EditClientContext
{
    private readonly IEditClientGetaway _getaway;

    public EditClientContext(IEditClientGetaway getaway)
    {
        _getaway = getaway;
    }

    public async Task<EditClientRequest> GetClientDetailsForEdit(long clientId)
    {
        var client = await _getaway.GetClientForEdit(clientId);

        return new EditClientRequest
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Address = client.Address
        };
    }

    public async Task<Result> Execute(long id, EditClientRequest request)
    {

        var client = await _getaway.GetClientForEdit(id);

        if (client == null) return Result.Failure($"Cannot find client with id: {id}");

        var clientToEdit = client.Edit(request.Name, request.Email, request.Address);

        if (clientToEdit.IsFailure)
        {
            return Result.Failure(clientToEdit.Error);
        }

        await _getaway.Edit(clientToEdit.Value);

        return Result.Success();
    }


}

public class EditClientRequest
{
    public long Id { get; set; }
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
}