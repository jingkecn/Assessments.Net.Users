using System.ComponentModel.DataAnnotations;
using Assessments.Users.Domain.Models;

namespace Assessments.Users.Query.Api.Models;

public sealed record GetUserByIdResponse([property: Required] User User);
