using System.Net;
using System.Net.Http.Json;
using Assessments.Users.Command.Api.Models;
using Assessments.Users.Domain.Models;
using Assessments.Users.FunctionalTests.Command.Api.Abstractions;
using Assessments.Users.FunctionalTests.Command.Api.Fixtures;
using FluentAssertions;

namespace Assessments.Users.FunctionalTests.Command.Api;

public sealed class AddUserTests(CommandApiFixture fixture) : TestBase(fixture)
{
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

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/users", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var result = await response.Content.ReadFromJsonAsync<AddUserResponse>();
        result
            .Should().BeOfType<AddUserResponse>()
            .Which.Id.Should().NotBeEmpty();
    }
}
