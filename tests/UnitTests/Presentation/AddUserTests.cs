using Assessments.Users.Application.Users.AddUser;
using Assessments.Users.Command.Api.Extensions;
using Assessments.Users.Command.Api.Models;
using Assessments.Users.Domain.Models;
using FluentAssertions;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;

namespace Assessments.Users.UnitTests.Presentation;

public sealed class AddUserTests
{
    private readonly IMediator mMediator = Substitute.For<IMediator>();

    [Fact]
    public async Task Should_SendAddUserCommand()
    {
        // Arrange
        var request = new AddUserRequest("John", "DOE",
            new Contact
            {
                Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
                Email = "john.doe@test.com",
                Phone = new Phone(33, 666666666)
            });

        // Act
        _ = await UserEndpoints.AddUserAsync(request, mMediator);

        // Assert
        await mMediator
            .Received(1)
            .Send(Arg.Is<AddUserCommand>(c =>
                    c.FirstName == request.FirstName &&
                    c.LastName == request.LastName &&
                    c.Contact == request.Contact),
                Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Should_ReturnCreated()
    {
        // Arrange
        var request = new AddUserRequest("John", "DOE",
            new Contact
            {
                Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
                Email = "john.doe@test.com",
                Phone = new Phone(33, 666666666)
            });
        var command = new AddUserCommand(request.FirstName, request.LastName, request.Contact);
        var userId = Guid.NewGuid();

        mMediator
            .Send(command, Arg.Any<CancellationToken>())
            .Returns(userId);

        // Act
        var result = await UserEndpoints.AddUserAsync(request, mMediator);

        // Assert
        result
            .Should().BeOfType<Created<AddUserResponse>>()
            .Which.Value.Should().BeOfType<AddUserResponse>()
            .Which.Id.Should().Be(userId);
    }
}
