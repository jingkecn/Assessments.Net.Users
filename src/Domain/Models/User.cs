using Assessments.Users.Domain.Abstractions;

namespace Assessments.Users.Domain.Models;

public sealed class User : Entity
{
    private User() : base(Guid.NewGuid()) { }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public Contact Contact { get; private set; } = null!;

    public static User Create(string firstName, string lastName, Contact contact) =>
        new() { FirstName = firstName, LastName = lastName, Contact = contact };

    public bool Update(Contact contact)
    {
        if (contact == Contact)
        {
            return false;
        }

        Contact = contact;
        return true;
    }
}
