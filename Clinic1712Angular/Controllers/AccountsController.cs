using Clinic1712Angular.Models;
using Clinic1712Angular.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic1712Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountService accountService;

        public AccountsController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        
        [HttpPost]
        [Route("SignUp")]

        public async Task SignUp(SignUpDTO signUp)
        {

            await accountService.CreateAccount(signUp);
        }

        [HttpPost]
        [Route("AddRole")]

        public async Task AddRole(RoleDTO dto)
        {
            var result = await accountService.CreateRole(dto);
        }

        [HttpGet]
        [Route("UserList")]
        public async Task<List<UserDTO>> UserList()
        {
            List<UserDTO> users = await accountService.GetUsers();
            return users;
        }

        [HttpGet]
        [Route("UserRole")]
        public async Task<List<UserRolesDTO>> UserRole(string UserId)
        {
            List<UserRolesDTO> userRoles = await accountService.GetRoles(UserId);
            return userRoles;
        }
        [HttpPost]
        [Route("UpdateRole")]
        public async Task<List<UserRolesDTO>> UpdateRole(List<UserRolesDTO> userRoles)
        {
            await accountService.UpdateUserRoles(userRoles);
            userRoles = await accountService.GetRoles(userRoles[0].UserId);
            return userRoles;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(SignInDTO signInDTO)
        {
            var result = await accountService.SignIn(signInDTO);
            if (result.Succeeded == true)
            {
                List<Claim> authClaim = new List<Claim>();

                Claim claim = new Claim(ClaimTypes.Name, signInDTO.Username);
                authClaim.Add(claim);

                claim = new Claim("currentDate", DateTime.Now.ToString());
                authClaim.Add(claim);

                claim = new Claim("UniqueValue", Guid.NewGuid().ToString());
                authClaim.Add(claim);

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisMySecurityKey"));

                var token = new JwtSecurityToken(
                            issuer: "http://localhost",
                            audience: "User",
                            expires: DateTime.Now.AddDays(15),
                            claims: authClaim,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
