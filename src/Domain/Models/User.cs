using Assessments.Users.Domain.Abstractions;

namespace Assessments.Users.Domain.Models;

public sealed class User : Entity
{
    private User() { }

    private User(Guid id, string firstName, string lastName, Contact contact) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Contact = contact;
    }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public Contact Contact { get; private set; } = null!;

    public static User Create(string firstName, string lastName, Contact contact) =>
        new(Guid.NewGuid(), firstName, lastName, contact);

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
