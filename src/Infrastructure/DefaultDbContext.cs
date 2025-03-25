using System.Diagnostics;
using Assessments.Users.Domain.Contracts;
using Assessments.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessments.Users.Infrastructure;

public class DefaultDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        Debug.WriteLine(modelBuilder.Model.ToDebugString());
}
