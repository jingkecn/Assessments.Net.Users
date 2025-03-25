using System.Reflection;
using Assessments.Users.Application.Users.AddUser;
using Assessments.Users.Domain.Abstractions;
using Assessments.Users.Infrastructure;

namespace Assessments.Users.ArchitectureTests.Abstractions;

public abstract class TestBase
{
    private const string RootNamespace = "Assessments.Users";
    protected const string ApplicationNamespace = $"{RootNamespace}.Application";
    protected const string InfrastructureNamespace = $"{RootNamespace}.Infrastructure";
    protected const string CommandApiNamespace = $"{RootNamespace}.Command.Api";
    protected const string QueryApiNamespace = $"{RootNamespace}.Query.Api";

    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(AddUserCommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(DefaultDbContext).Assembly;
}
