using Assessments.Users.Domain.Models;

namespace Assessments.Users.Domain.Contracts;

public interface IUserRepository
{
    Task<Guid> AddUserAsync(User user, CancellationToken cancellationToken = default);

    Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
