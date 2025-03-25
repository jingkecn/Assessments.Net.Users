using Assessments.Users.Domain.Models;
using FluentAssertions;

namespace Assessments.Users.IntegrationTests.Infrastructure;

public sealed partial class UserRepositoryTests
{
    [Fact]
    public async Task AddUser_Should_ReturnUserId()
    {
        // Arrange
        var user = User.Create("John", "DOE",
            new Contact
            {
                Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
                Email = "john.doe@test.com",
                Phone = new Phone(33, 666666666)
            });

        // Act
        var result = await mUserRepository.AddUserAsync(user, CancellationToken.None);

        // Assert
        result.Should().NotBeEmpty().And.Be(user.Id);
        var userInDb = await mDbContext.Users.FindAsync(user.Id);
        userInDb.Should().BeEquivalentTo(user);
    }
}
