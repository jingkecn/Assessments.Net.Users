using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Assessments.Users.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection source) =>
        source
            .AddMediator(option => option.ServiceLifetime = ServiceLifetime.Scoped)
            .AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
}
