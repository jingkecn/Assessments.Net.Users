using Assessments.Users.Domain.Models;

namespace Assessments.Users.FunctionalTests.Query.Api.Models;

public sealed record UserForTest(Guid Id, string FirstName, string LastName, Contact Contact);
