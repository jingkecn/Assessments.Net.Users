using System.ComponentModel.DataAnnotations;
using Assessments.Users.Application.Users.GetUserById;
using Assessments.Users.Query.Api.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Assessments.Users.Query.Api.Extensions;

internal static class UserEndpoints
{
    internal static RouteGroupBuilder MapUserApis(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/users");

        // api.MapGet("/", GetUsersAsync);
        api.MapGet("/{id:guid}", GetUserByIdAsync);
        // api.MapPut("/{id:guid}", UpdateUserAsync);
        // api.MapDelete("/{id:guid}", DeleteUserAsync);

        return api;
    }

    internal static async Task<IResult> GetUserByIdAsync(
        [Required] Guid id,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUserByIdQuery(id);
        var response = await mediator.Send(query, cancellationToken);
        return TypedResults.Ok(new GetUserByIdResponse(response));
    }
}
