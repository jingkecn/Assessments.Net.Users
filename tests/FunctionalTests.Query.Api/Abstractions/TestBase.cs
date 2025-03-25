using Assessments.Users.Domain.Contracts;
using Assessments.Users.FunctionalTests.Query.Api.Fixtures;
using Microsoft.Extensions.DependencyInjection;

namespace Assessments.Users.FunctionalTests.Query.Api.Abstractions;

public abstract class TestBase(QueryApiFixture fixture) : IClassFixture<QueryApiFixture>, IDisposable
{
    protected HttpClient HttpClient { get; } = fixture.CreateClient();
    private IServiceScope ServiceScope { get; } = fixture.Services.CreateScope();
    protected IServiceProvider Services => ServiceScope.ServiceProvider;

    protected IUnitOfWork UnitOfWork => Services.GetRequiredService<IUnitOfWork>();
    protected IUserRepository UserRepository => Services.GetRequiredService<IUserRepository>();

    public void Dispose()
    {
        HttpClient.Dispose();
        ServiceScope.Dispose();
        GC.SuppressFinalize(this);
    }
}
