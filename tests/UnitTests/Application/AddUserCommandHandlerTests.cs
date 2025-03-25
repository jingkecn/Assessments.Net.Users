using Assessments.Users.Application.Users.AddUser;
using Assessments.Users.Domain.Models;
using Assessments.Users.UnitTests.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace Assessments.Users.UnitTests.Application;

public sealed class AddUserCommandHandlerTests : TestBase
{
    [Fact]
    public async Task Handle_Should_AddUserAndReturnId()
    {
        // Arrange
        var (firstName, lastName) = ("John", "DOE");
        var contact = new Contact
        {
            Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
            Email = "john.doe@test.com",
            Phone = new Phone(33, 666666666)
        };

        var command = new AddUserCommand(firstName, lastName, contact);
        var handler = new AddUserCommandHandler(UnitOfWork, UserRepository);

        UserRepository
            .AddUserAsync(Arg.Any<User>(), Arg.Any<CancellationToken>())
            .Returns(info => info.Arg<User>().Id);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeEmpty();
        await UserRepository
            .Received(1)
            .AddUserAsync(
                Arg.Is<User>(u => u.FirstName == firstName && u.LastName == lastName && u.Contact == contact),
                Arg.Any<CancellationToken>());
        await UnitOfWork.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
