using System.ComponentModel.DataAnnotations;
using Assessments.Users.Domain.Models;

namespace Assessments.Users.Command.Api.Models;

public sealed record AddUserRequest(
    [property: Required] string FirstName,
    [property: Required] string LastName,
    [property: Required] Contact Contact);
