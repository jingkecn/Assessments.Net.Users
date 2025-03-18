using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessments.Users.Domain.Models;

[ComplexType]
public sealed record Contact(
    [property: Required] Address HomeAddress,
    [property: Required] Address WorkAddress,
    [property: Required] PhoneNumber MobilePhone,
    [property: Required]
    [property: EmailAddress]
    string Email);
