using Domain.Entities.Clients;
using Domain.Getaways.Clients;

namespace Persistence.Getaways.Movies;

public class GetClientDetailsGetaway : IGetClientDetailsGetaway
{
    private readonly MvcMovieContext _context;

    public GetClientDetailsGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClientDetails(long clientId)
    {
        var movieDbSet = _context.Set<Client>();

        var client = await movieDbSet.FindAsync(clientId);

        return client;
    }

}
