using System.Text.RegularExpressions;
using Domain.Base;

namespace Domain.Clients.ValueObjects;

public class Email : ValueObject<Email>
{
    public string Value { get; set; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Email>("Email should not be empty");
        }

        email = email.Trim();

        if (!IsEmailValid(email))
        {
            return Result.Failure<Email>("Email is invalid");
        }

        return Result.Success(new Email(email));
    }

    protected override bool EqualsCore(Email other)
    {
        return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }

    private static bool IsEmailValid(string email)
    {
        const string pattern = @"^(.+)@(.+)$";
        const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        var matchTimeout = TimeSpan.FromSeconds(2);

        var regex = new Regex(pattern, options, matchTimeout);

        return regex.IsMatch(email);
    }
}