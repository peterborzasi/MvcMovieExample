using Domain.Base;

namespace Domain.Clients.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; }
    public string LastName { get; }

    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Result<Name> Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Name>("First name should not be empty.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Name>("Last name should not be empty.");

        }

        firstName = firstName.Trim();
        lastName = lastName.Trim();

        if (firstName.Length > 20)
        {
            return Result.Failure<Name>("First name cannot be longer than 20 characters");

        }

        if (lastName.Length > 20)
        {
            return Result.Failure<Name>("Last name cannot be longer than 20 characters");

        }

        return Result.Success(new Name(firstName, lastName));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}