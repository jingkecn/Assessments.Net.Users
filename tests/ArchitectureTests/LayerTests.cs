using Assessments.Users.ArchitectureTests.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;

namespace Assessments.Users.ArchitectureTests;

public sealed class LayerTests : TestBase
{
    [Fact]
    public void Domain_ShouldNot_HaveDependenciesOn_OuterLayers()
    {
        // Arrange
        string[] outerLayers = [ApplicationNamespace, InfrastructureNamespace, CommandApiNamespace, QueryApiNamespace];

        // Act
        var result = Types
            .InAssembly(DomainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(outerLayers)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_ShouldNot_HaveDependenciesOn_OuterLayers()
    {
        // Arrange
        string[] outerLayers = [InfrastructureNamespace, CommandApiNamespace, QueryApiNamespace];

        // Act
        var result = Types
            .InAssembly(ApplicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(outerLayers)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    #region Infrastructure Layer

    [Fact]
    public void Infrastructure_ShouldNot_HaveDependenciesOn_OuterLayers()
    {
        // Arrange
        string[] outerLayers = [CommandApiNamespace, QueryApiNamespace];

        // Act
        var result = Types
            .InAssembly(InfrastructureAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(outerLayers)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    #endregion
}
