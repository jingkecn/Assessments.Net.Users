using Assessments.Users.Application.Users.AddUser;
using Assessments.Users.Command.Api.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Assessments.Users.Command.Api.Extensions;

internal static class UserEndpoints
{
    internal static RouteGroupBuilder MapUserApis(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/users");

        api.MapPost("/", AddUserAsync);
        // api.MapGet("/", GetUsersAsync);
        // api.MapGet("/{id:guid}", GetUserByIdAsync);
        // api.MapPut("/{id:guid}", UpdateUserAsync);
        // api.MapDelete("/{id:guid}", DeleteUserAsync);

        return api;
    }

    internal static async Task<IResult> AddUserAsync(
        [FromBody] AddUserRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken = default)
    {
        var command = new AddUserCommand(request.FirstName, request.LastName, request.Contact);
        var response = await mediator.Send(command, cancellationToken);
        return TypedResults.Created($"api/users/{response}", new AddUserResponse(response));
    }
}
