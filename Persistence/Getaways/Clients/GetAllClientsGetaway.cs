using Microsoft.EntityFrameworkCore;
using Domain.Entities.Clients;
using Domain.Entities;
using Domain.Getaways.Clients;

namespace Persistence.Getaways.Clients;

public class GetAllClientsGetaway : IGetAllClientsGetaway
{
    private readonly MvcMovieContext _context;

    public GetAllClientsGetaway(MvcMovieContext context)
    {
        _context = context;
    }

    //public async Task<ICollection<Movie>> GetOwnedMovies()
    //{
    //    var movieDbSet = _context.Set<Movie>();

    //    ICollection<string> ownedMoviesQuery = await movieDbSet
    //        .Select(p => p.OwnedMovies).Distinct().ToListAsync();

    //    return ownedMoviesQuery;
    //}

    public async Task<ICollection<Client>> GetAllClients()
    {
        var clientDbSet = _context.Set<Client>();

        var clients = from m in clientDbSet select m;

        return await clients.ToListAsync();
    }
}
