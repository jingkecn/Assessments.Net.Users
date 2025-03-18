using System.ComponentModel.DataAnnotations;
using Assessments.Users.Domain.Models;

namespace Assessments.Users.Command.Api.Models;

public sealed record CreateUserResponse([property: Required] User User);
