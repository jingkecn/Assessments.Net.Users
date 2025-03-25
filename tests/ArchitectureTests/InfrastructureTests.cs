using Assessments.Users.ArchitectureTests.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;

namespace Assessments.Users.ArchitectureTests;

public sealed class InfrastructureTests : TestBase
{
    [Fact]
    public void Repositories_Should_BeSealed()
    {
        // Arrange
        // Act
        var result = Types
            .InAssembly(InfrastructureAssembly)
            .That()
            .HaveNameEndingWith("Repository")
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
