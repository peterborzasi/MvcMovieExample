using Domain.Base;

namespace Domain.Clients.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }
    public string Number { get; }
    public string City { get; }
    public string County { get; }
    public string Postcode { get; }
    public string Country { get; }

    private Address(string street, string number, string city, string county, string postcode, string country)
    {
        Street = street;
        Number = number;
        City = city;
        County = county;
        Postcode = postcode;
        Country = country;
    }

    public static Result<Address> Create(string street, string number, string city, string county, string postcode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            return Result.Failure<Address>("Street name should not be empty.");
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            return Result.Failure<Address>("Address number should not be empty.");
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            return Result.Failure<Address>("City name should not be empty.");
        }

        if (string.IsNullOrWhiteSpace(county))
        {
            return Result.Failure<Address>("County name should not be empty.");
        }

        if (string.IsNullOrWhiteSpace(postcode))
        {
            return Result.Failure<Address>("Postcode should not be empty.");
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            return Result.Failure<Address>("Country name should not be empty.");
        }

        street = street.Trim();
        number = number.Trim();
        city = city.Trim();
        county = county.Trim();
        postcode = postcode.Trim();
        country = country.Trim();

        if (street.Length > 20)
        {
            return Result.Failure<Address>("Street name cannot be longer than 20 characters");

        }

        if (number.Length > 10)
        {
            return Result.Failure<Address>("Street name cannot be longer than 10 characters");

        }

        if (city.Length > 20)
        {
            return Result.Failure<Address>("City name cannot be longer than 20 characters");

        }

        if (county.Length > 20)
        {
            return Result.Failure<Address>("County name cannot be longer than 20 characters");

        }

        if (postcode.Length > 10)
        {
            return Result.Failure<Address>("County name cannot be longer than 10 characters");

        }

        if (country.Length > 20)
        {
            return Result.Failure<Address>("Country name cannot be longer than 20 characters");

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
