using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessments.Users.Domain.Models;

[ComplexType]
public sealed record PhoneNumber([property: Required] int CountryCode, [property: Required] long Number);
