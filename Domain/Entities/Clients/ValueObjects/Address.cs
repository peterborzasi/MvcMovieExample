using Domain.Base;

namespace Domain.Clients.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }
    public int Number { get; }
    public string City { get; }
    public string County { get; }
    public int Postcode { get; }
    public string Country { get; }

    private Address(string street, int number, string city, string county, int postcode, string country)
    {
        Street = street;
        Number = number;
        City = city;
        County = county;
        Postcode = postcode;
        Country = country;
    }

    public static Result<Address> Create(string street, int number, string city, string county, int postcode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            return Result.Failure<Address>("Street name should not be empty.");
        }

        if (number <= 0)
        {
            return Result.Failure<Address>("Address number should not be empty.");

        }

        if (string.IsNullOrWhiteSpace(city))
        {
            return Result.Failure<Address>("City name should not be empty.");
        }

        street = street.Trim();
        city = city.Trim();

        if (street.Length > 50)
        {
            return Result.Failure<Address>("Street name cannot be longer than 50 characters");

        }

        if (city.Length > 50)
        {
            return Result.Failure<Address>("City name cannot be longer than 50 characters");

        }

        if (county.Length > 50)
        {
            return Result.Failure<Address>("County name cannot be longer than 50 characters");

        }

        if (country.Length > 50)
        {
            return Result.Failure<Address>("Country name cannot be longer than 50 characters");

        }

        return Result.Success(new Address(street, number, city, county, postcode, country));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return City;
        yield return County;
        yield return Postcode;
        yield return Country;
    }
}
