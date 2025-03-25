using Assessments.Users.Infrastructure;
using Assessments.Users.Infrastructure.Repositories;
using Assessments.Users.IntegrationTests.Fixtures;

namespace Assessments.Users.IntegrationTests.Infrastructure;

public sealed partial class UserRepositoryTests(DatabaseFixture databaseFixture) : IClassFixture<DatabaseFixture>
{
    private readonly DefaultDbContext mDbContext = databaseFixture.DbContext;
    private readonly UserRepository mUserRepository = new(databaseFixture.DbContext);
}
