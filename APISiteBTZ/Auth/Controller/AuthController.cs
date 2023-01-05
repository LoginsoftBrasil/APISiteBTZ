using APISiteBTZ.Auth.Dtos;
using APISiteBTZ.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISiteBTZ.Auth.Controller
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request) 
        {
            var body = await _authService.Login(request);
            return Ok(body);
        }
    }
}
