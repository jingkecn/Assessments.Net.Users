using Assessments.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assessments.Users.IntegrationTests.Fixtures;

public sealed class DatabaseFixture : IDisposable
{
    private readonly IServiceScope mServiceScope;

    public DatabaseFixture()
    {
        var services = new ServiceCollection();
        var provider = services
            .AddDbContext<DefaultDbContext>(options => options.UseInMemoryDatabase("users-db"))
            .BuildServiceProvider();

        mServiceScope = provider.CreateScope();
        DbContext = mServiceScope.ServiceProvider.GetRequiredService<DefaultDbContext>();
    }

    public DefaultDbContext DbContext { get; }

    public void Dispose() => mServiceScope.Dispose();
}
