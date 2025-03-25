using Assessments.Users.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.MsSql;

namespace Assessments.Users.FunctionalTests.Query.Api.Fixtures;

public class QueryApiFixture : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer mDbContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:latest")
        .WithPassword("$tr0ngP@$$w0rd")
        .Build();

    public async Task InitializeAsync() => await mDbContainer.StartAsync();

    public new async Task DisposeAsync() => await mDbContainer.StopAsync();

    protected override void ConfigureWebHost(IWebHostBuilder builder) =>
        builder.ConfigureTestServices(services =>
        {
            services
                .RemoveAll<DbContextOptions<DefaultDbContext>>()
                .AddDbContext<DefaultDbContext>(options => options.UseSqlServer(mDbContainer.GetConnectionString()));
        });
}
