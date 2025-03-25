using System.ComponentModel.DataAnnotations;
using Assessments.Users.Domain.Models;
using Mediator;

namespace Assessments.Users.Application.Users.AddUser;

public sealed record AddUserCommand(
    [property: Required] string FirstName,
    [property: Required] string LastName,
    [property: Required] Contact Contact) : ICommand<Guid>;
