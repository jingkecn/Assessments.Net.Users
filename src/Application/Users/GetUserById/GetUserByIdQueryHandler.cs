using Assessments.Users.Domain.Contracts;
using Assessments.Users.Domain.Models;
using Mediator;

namespace Assessments.Users.Application.Users.GetUserById;

internal sealed class GetUserByIdQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserByIdQuery, User>
{
    public async ValueTask<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken) =>
        await userRepository.GetUserByIdAsync(query.Id, cancellationToken);
}
