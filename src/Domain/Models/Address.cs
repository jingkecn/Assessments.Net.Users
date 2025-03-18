using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessments.Users.Domain.Models;

[ComplexType]
public sealed record Address(
    [property: Required] string Country,
    [property: Required] string City,
    [property: Required] string Postcode,
    [property: Required] string Street);
