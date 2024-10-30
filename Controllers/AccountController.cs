using EcommerceApi.Models.Dtos;
using EcommerceApi.Models.User;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
    (UserManager<AppUser> userManager,
        ITokenService tokenService,
        SignInManager<AppUser> signInManager)
    : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var userPassword = registerDto.Password;
                if (string.IsNullOrEmpty(userPassword))
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };

                var createUser =
                    await userManager.CreateAsync(appUser, userPassword);

                if (!createUser.Succeeded)
                    return StatusCode(500, createUser.Errors);

                var roleResult =
                    await userManager.AddToRoleAsync(appUser, "Customer");

                return !roleResult.Succeeded ?
                    StatusCode(500, roleResult.Errors) :
                    Ok(new NewUserDto
                    {
                        Username = appUser.UserName!,
                        Email = appUser.Email!,
                        Token = tokenService.CreateToken(appUser)
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager
                .Users.FirstOrDefaultAsync(appUser =>
                    appUser.UserName == loginDto.UserName);
            if (user == null)
                return Unauthorized("Invalid username or password");

            var result = await signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized("Invalid username or password");
            return Ok(new LogonDto
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = tokenService.CreateToken(user)
            });
        }
    }
}
