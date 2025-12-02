using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOS.Authentication
{
    public record RegisterRequest([EmailAddress] string Email, string DisplayName, string Password,
    string? UserName = "MMM", string? PhoneNumber = "");
}