using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Miniinstagram1.Database;
using Miniinstagram1.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Miniinstagram1.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return BadRequest("Some Error");
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid && vm != null)
            {
                var user = await ValidateUser(vm);
                if (user != null)
                {
                    return Ok(new { Token = GenerateToken(user) });
                }
            }
            return BadRequest(new { Message = "Login faild" });
        }

        private async Task<ApplicationUser> ValidateUser(LoginViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.Email);
            if (user != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, vm.Password);
                if (result != PasswordVerificationResult.Failed)
                {
                    return user;
                }
            }
            return null;
        }

        private string GenerateToken(ApplicationUser user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME),
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Audience = AuthOptions.AUDIENCE,
                Issuer = AuthOptions.ISSUER,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}