using Microsoft.AspNetCore.Identity;
using Clinic1712Angular.Models;
using Clinic1712Angular.data;

namespace Clinic1712Angular.services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUpDTO signUpDTO);

        Task<SignInResult> SignIn(SignInDTO signInDTO);

        Task<IdentityResult> CreateRole(RoleDTO dto);

        Task<List<UserDTO>> GetUsers();

        Task<List<UserRolesDTO>> GetRoles(string UserId);

        Task UpdateUserRoles(List<UserRolesDTO> userRoles);

        Task Logout();

        Task<ApplicationUser> GetUserInfo(string username);

        Task<IList<string>> GetUserRoles(ApplicationUser user);
    }
}
