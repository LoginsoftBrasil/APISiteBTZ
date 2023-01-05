using APISiteBTZ.Auth.Dtos;

namespace APISiteBTZ.Auth.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
