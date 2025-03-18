using Assessments.Users.Domain.Abstractions;

namespace Assessments.Users.Domain.Models;

public sealed class User : Entity
{
    private User() : base(Guid.NewGuid())
    {
    }

    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public Contact Contact { get; private set; } = null!;

    public static User Create(string firstName, string lastName, Contact contact) =>
        new() { FirstName = firstName, LastName = lastName, Contact = contact };
}
