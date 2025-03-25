using Assessments.Users.Domain.Models;
using FluentAssertions;

namespace Assessments.Users.UnitTests.Domain;

public sealed class UserTests
{
    [Fact]
    public void Create_Should_ReturnUserWithExpectedInformation()
    {
        // Arrange
        var (firstName, lastName) = ("John", "DOE");
        var contact = new Contact
        {
            Address = new Address("France", "Nantes", "Rue de la Paix", "44000"),
            Email = "john.doe@test.com",
            Phone = new Phone(33, 666666666)
        };

        // Act
        var result = User.Create(firstName, lastName, contact);

        // Assert
        result.Should().BeOfType<User>();
        result.Id.Should().NotBeEmpty();
        result.FirstName.Should().Be(firstName);
        result.LastName.Should().Be(lastName);
        result.Contact.Should().BeEquivalentTo(contact);
    }
}
