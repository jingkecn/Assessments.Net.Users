using Assessments.Users.Domain.Contracts;

namespace Assessments.Users.Infrastructure;

internal sealed class UnitOfWork(DefaultDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await dbContext.SaveChangesAsync(cancellationToken);
}
