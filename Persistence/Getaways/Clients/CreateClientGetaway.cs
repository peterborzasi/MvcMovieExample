using Domain.Entities.Clients;
using Domain.Getaways.Clients;

namespace Persistence.Getaways.Clients;

public sealed class CreateClientGetaway : ICreateClientGetaway
{
    private readonly MvcMovieContext _context;

    public CreateClientGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task Create(Client client)
    {
        var dbSet = _context.Set<Client>();

        await dbSet.AddAsync(client);

        await _context.SaveChangesAsync();
    }
}