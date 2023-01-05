using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using APISiteBTZ.Core.Exceptions;
using System.Security.Claims;
using APISiteBTZ.Auth.Dtos;
using FluentValidation;
using System.Text;

namespace APISiteBTZ.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IValidator<LoginRequest> _loginValidator;

        public AuthService(IValidator<LoginRequest> loginValidator, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _loginValidator = loginValidator;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            await _loginValidator.ValidateAndThrowAsync(request);

            var user = await _userManager.FindByNameAsync(request.Username);

            if (user is null)
            {
                throw new BadCredentialsException();
            }

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new BadCredentialsException();
            }

            var key = Encoding.ASCII.GetBytes("super secret key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                })
            };

            var roles = await _userManager.GetRolesAsync(user);

            roles.ToList().ForEach(role => tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role)));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponse
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
