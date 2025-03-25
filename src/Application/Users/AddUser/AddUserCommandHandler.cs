using Assessments.Users.Domain.Contracts;
using Assessments.Users.Domain.Models;
using Mediator;

namespace Assessments.Users.Application.Users.AddUser;

internal sealed class AddUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository) : ICommandHandler<AddUserCommand, Guid>
{
    public async ValueTask<Guid> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = User.Create(command.FirstName, command.LastName, command.Contact);
        var result = await userRepository.AddUserAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
