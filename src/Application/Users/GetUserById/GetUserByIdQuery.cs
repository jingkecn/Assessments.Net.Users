using System.ComponentModel.DataAnnotations;
using Assessments.Users.Domain.Models;
using Mediator;

namespace Assessments.Users.Application.Users.GetUserById;

public sealed record GetUserByIdQuery([property: Required] Guid Id) : IQuery<User>;
