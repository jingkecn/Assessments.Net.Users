using Assessments.Users.Domain.Contracts;
using Assessments.Users.Domain.Models;

namespace Assessments.Users.Infrastructure.Repositories;

public sealed class UserRepository(DefaultDbContext context) : IUserRepository
{
    public async Task<Guid> AddUserAsync(User user, CancellationToken cancellationToken = default)
    {
        var result = await context.Users.AddAsync(user, cancellationToken);
        return result.Entity.Id;
    }
}
