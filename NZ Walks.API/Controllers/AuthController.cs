using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.Models.DTO;

namespace NZ_Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Email,
            };


            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User registered sucessfully. Please login now.");
                    }
                }
            }
            return BadRequest("Somthing Went wrong!");

        }
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginReqeustDto loginReqeustDto)
        {
            var user = await userManager.FindByNameAsync(loginReqeustDto.Username);

            if(user != null)
            {
                var checkLogin = await userManager.CheckPasswordAsync(user, loginReqeustDto.Password);

                if(checkLogin)
                {
                    return Ok();
                }

            }
            return BadRequest("Username or passowrd is incorrect");
        }

    }
}
