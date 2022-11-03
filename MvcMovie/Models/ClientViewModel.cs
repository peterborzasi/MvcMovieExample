using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Contexts.Clients;

namespace MvcMovie.Models;

public class ClientViewModel
{   
    public List<ClientResponse> Clients { get; set; }

    //public SelectList? OwnedMovies { get; set; }
    //public string? Movie { get; set; }
    //public string? SearchString { get; set; }
}
