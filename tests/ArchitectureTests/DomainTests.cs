using System.Reflection;
using Assessments.Users.ArchitectureTests.Abstractions;
using Assessments.Users.Domain.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;

namespace Assessments.Users.ArchitectureTests;

public sealed class DomainTests : TestBase
{
    [Fact]
    public void Entities_Should_BeSealed()
    {
        // Arrange
        // Act
        var result = Types
            .InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Entities_Should_HavePrivateParameterlessConstructor()
    {
        // Arrange
        var entityTypes = Types
            .InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();

        var failingTypes = entityTypes
            .Select(type => new
            {
                type, constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
            })
            .Where(t => !t.constructors.Any(c => c.IsPrivate && c.GetParameters().Length is 0))
            .Select(t => t.type);

        // Act

        // Assert
        failingTypes.Should().BeEmpty();
    }

    [Fact]
    public void Entities_ShouldNot_HaveNameEndingWithEntity()
    {
        // Arrange
        // Act
        var result = Types
            .InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .ShouldNot()
            .HaveNameEndingWith(nameof(Entity))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
