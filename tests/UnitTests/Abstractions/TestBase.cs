using Assessments.Users.Domain.Contracts;
using NSubstitute;

namespace Assessments.Users.UnitTests.Abstractions;

public abstract class TestBase
{
    protected IUnitOfWork UnitOfWork { get; } = Substitute.For<IUnitOfWork>();
    protected IUserRepository UserRepository { get; } = Substitute.For<IUserRepository>();
}
