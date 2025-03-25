using Assessments.Users.Domain.Contracts;
using Assessments.Users.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Assessments.Users.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection source) =>
        source
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IUserRepository, UserRepository>();
}
