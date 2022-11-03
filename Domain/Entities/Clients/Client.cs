using Domain.Base;
using Domain.Clients.ValueObjects;
using Domain.Entities;

namespace Domain.Entities.Clients;

public class Client : Entity
{
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
    public ICollection<Movie> OwnedMovies { get; set; }

    private Client()
    {
    }

    private Client(Name name, Email email, Address address)
    {
        Name = name;
        Email = email;
        Address = address;
    }

    public static Result<Client> Create(Name name, Email email, Address address)
    {
        if (string.IsNullOrWhiteSpace(name.FirstName) || string.IsNullOrWhiteSpace(name.LastName))
        {
            return Result.Failure<Client>("Name is mandatory");
        }
                
        var client = new Client(name, email, address);

        return Result.Success(client);
    }

    public Result<Client> Edit(Name name, Email email, Address address)
    {
        //

        Name = name;
        Email = email;
        Address = address;

        return Result.Success(this);
    }

    public Result<Client> Delete(long Id, Name Name, Email email, Address address)
    {


        return Result.Success(this);
    }
}