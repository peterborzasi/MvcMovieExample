using Domain.Entities.Clients;
using Domain.Getaways.Clients;

namespace Persistence.Getaways.Clients;

public class EditClientGetaway : IEditClientGetaway
{
    private readonly MvcMovieContext _context;

    public EditClientGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClientForEdit(long clientId)
    {
        var clientDbSet = _context.Set<Client>();

        var client = await clientDbSet.FindAsync(clientId);

        return client;
    }

    public async Task Edit(Client client)
    {
        var clientDbSet = _context.Set<Client>();

        clientDbSet.Update(client);

        await _context.SaveChangesAsync();
    }
}