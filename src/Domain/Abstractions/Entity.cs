namespace Assessments.Users.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(Guid id) => Id = id;

    protected Entity() { }

    public Guid Id { get; protected set; }
}
