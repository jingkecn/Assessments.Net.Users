using Assessments.Users.Application.Users.GetUserById;
using Assessments.Users.Domain.Models;
using Assessments.Users.UnitTests.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace Assessments.Users.UnitTests.Application;

public sealed class GetUserByIdQueryHandlerTests : TestBase
{
    [Fact]
    public async Task Handle_Should_ReturnUser()
    {
        // Arrange
        var user = User.Create("John", "DOE",
            new Contact
            {
                Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
                Email = "john.doe@test.com",
                Phone = new Phone(33, 666666666)
            });

        UserRepository
            .GetUserByIdAsync(user.Id, Arg.Any<CancellationToken>())
            .Returns(user);

        var handler = new GetUserByIdQueryHandler(UserRepository);
        var query = new GetUserByIdQuery(user.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(user);
        await UserRepository
            .Received(1)
            .GetUserByIdAsync(user.Id, Arg.Any<CancellationToken>());
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
