using Assessments.Users.Command.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assessments.Users.Command.Api.Extensions;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/users");
        api.MapPost("/", CreateUserAsync);
        return api;
    }

    private static async Task CreateUserAsync([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
