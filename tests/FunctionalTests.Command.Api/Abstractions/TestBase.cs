using Assessments.Users.FunctionalTests.Command.Api.Fixtures;

namespace Assessments.Users.FunctionalTests.Command.Api.Abstractions;

public abstract class TestBase(CommandApiFixture fixture) : IClassFixture<CommandApiFixture>
{
    protected HttpClient HttpClient { get; } = fixture.CreateClient();
}
