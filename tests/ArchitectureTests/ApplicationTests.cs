using Assessments.Users.ArchitectureTests.Abstractions;
using FluentAssertions;
using Mediator;
using NetArchTest.Rules;

namespace Assessments.Users.ArchitectureTests;

public sealed class ApplicationTests : TestBase
{
    [Fact]
    public void Commands_Should_HaveNameEndingWithCommand()
    {
        // Arrange
        // Act
        var result = Types
            .InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetTypes();

        // Assert
        result.Should().NotBeEmpty();
    }
}
