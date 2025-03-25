using System.ComponentModel.DataAnnotations;

namespace Assessments.Users.Command.Api.Models;

public sealed record AddUserResponse([property: Required] Guid Id);
