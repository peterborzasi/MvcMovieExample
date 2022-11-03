using Domain.Entities.Clients;
using Domain.Getaways.Clients;

namespace Persistence.Getaways.Clients;

public class DeleteClientGetaway : IDeleteClientGetaway
{
    private readonly MvcMovieContext _context;

    public DeleteClientGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClientForDelete(long clientId)
    {
        var clientDbSet = _context.Set<Client>();

        var client = await clientDbSet.FindAsync(clientId);

        return client;
    }

    public async Task Delete(Client client)
    {
        var clientDbSet = _context.Set<Client>();

        clientDbSet.Remove(client);

        await _context.SaveChangesAsync();
    }
}