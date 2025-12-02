using Shared.DTOS.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer
{
    public interface IAuthenticationService
    {
        Task<UserResponse> LoginAsync(LoginRequest request);

        Task<UserResponse> RegisterAsync(RegisterRequest request);

        Task<UserResponse> GetUserByEmailAsync(string email);
        Task<bool> CheckEmailAsync(string email);
        Task<AddressDTO> GetAddressAsync(string email);
        Task<AddressDTO> UpdateAddressAsync(AddressDTO address, string email);
    }
}