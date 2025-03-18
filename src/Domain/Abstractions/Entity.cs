namespace Assessments.Users.Domain.Abstractions;

public abstract class Entity(Guid id)
{
    public Guid Id { get; } = id;
}
