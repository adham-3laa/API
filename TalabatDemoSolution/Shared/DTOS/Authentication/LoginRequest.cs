global using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOS.Authentication
{
    public record LoginRequest([EmailAddress] string Email, string Password);

}