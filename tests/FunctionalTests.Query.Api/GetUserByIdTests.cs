using System.Net;
using System.Net.Http.Json;
using Assessments.Users.Domain.Models;
using Assessments.Users.FunctionalTests.Query.Api.Abstractions;
using Assessments.Users.FunctionalTests.Query.Api.Fixtures;
using Assessments.Users.FunctionalTests.Query.Api.Models;
using FluentAssertions;

namespace Assessments.Users.FunctionalTests.Query.Api;

public sealed class GetUserByIdTests(QueryApiFixture fixture) : TestBase(fixture)
{
    [Fact]
    public async Task Should_ReturnOk()
    {
        // Arrange
        var user = User.Create("John", "DOE",
            new Contact
            {
                Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
                Email = "john.doe@test.com",
                Phone = new Phone(33, 666666666)
            });

        var userId = await UserRepository.AddUserAsync(user);
        _ = await UnitOfWork.SaveChangesAsync();

        // Act
        var response = await HttpClient.GetAsync($"api/users/{userId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<GetUserByIdResponseForTest>();
        result
            .Should().BeOfType<GetUserByIdResponseForTest>()
            .Which.User.Should().BeEquivalentTo(user);
    }
}
