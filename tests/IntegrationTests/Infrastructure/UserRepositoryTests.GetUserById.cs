using Assessments.Users.Domain.Models;
using FluentAssertions;

namespace Assessments.Users.IntegrationTests.Infrastructure;

public sealed partial class UserRepositoryTests
{
    [Fact]
    public async Task GetUserById_Should_ReturnUser()
    {
        // Arrange
        var user = User.Create("John", "DOE",
            new Contact
            {
                Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
                Email = "john.doe@test.com",
                Phone = new Phone(33, 666666666)
            });
        await mUserRepository.AddUserAsync(user, CancellationToken.None);

        // Act
        var result = await mUserRepository.GetUserByIdAsync(user.Id, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(user);
    }
}
