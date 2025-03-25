using System.Diagnostics;
using Assessments.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessments.Users.Infrastructure;

public class DefaultDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        Debug.WriteLine(modelBuilder.Model.ToDebugString());
}
