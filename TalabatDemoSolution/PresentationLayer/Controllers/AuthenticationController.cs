using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOS.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IServiceManager serviceManager)
        : ControllerBase
    {

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
            => Ok(await serviceManager.AuthenticationServices.LoginAsync(request));
       
        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
        => Ok(await serviceManager.AuthenticationServices.RegisterAsync(request));
        // CheckEmail(string email) => bool;
       
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmail([EmailAddress] string email)
            => Ok(await serviceManager.AuthenticationServices.CheckEmailAsync(email));


        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await serviceManager.AuthenticationServices.GetUserByEmailAsync(email!));
        }
        // [Authorize] Get User Address => AddressDTO 

        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDTO>> GetAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await serviceManager.AuthenticationServices.GetAddressAsync(email!));
        }
        // [Authorize] Update User Address => AddressDTO 

        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO addressDTO)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await serviceManager.AuthenticationServices.UpdateAddressAsync(addressDTO, email!));
        }

    }
}
 