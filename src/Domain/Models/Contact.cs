using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessments.Users.Domain.Models;

/// <summary>
///     Represents a contact information.
/// </summary>
/// <remarks>
///     [!NOTE]
///     We’re not using a primary constructor for the Contact type because EF Core does not yet support constructor
///     injection of complex type values.
///     Vote for <see href="https://github.com/dotnet/efcore/issues/31621">Issue #31621</see> if this is important to you.
/// </remarks>
[ComplexType]
public sealed record Contact
{
    [Required] public Address Address { get; init; } = null!;
    [Required] public string Email { get; init; } = null!;
    [Required] public Phone Phone { get; init; } = null!;
}
