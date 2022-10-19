using System.Net.Sockets;
using Domain.Base;
using Domain.Clients.ValueObjects;
using Domain.Entities;

namespace Domain.Clients;

public class Client : Entity
{
    public Name Name { get; set; }
    public Email Email { get; set; }
    //public Address Address { get; set; }
    public ICollection<Movie> Movies { get; set; }
}

public class Address
{
}