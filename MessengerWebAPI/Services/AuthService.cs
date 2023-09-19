using System.Threading.Tasks;
using MessengerWebAPI.Repositories;
using MessengerWebAPI.Models;
using MessengerWebAPI.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MessengerWebAPI.Services
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(AuthViewModel authViewModel);
        Task<LoginResponseViewModel> Register(CreateUserViewModel userViewModel, AuthViewModel authViewModel);
    }

    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        private string EncodeJwt(Auth auth)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, auth.Username),
                new Claim(ClaimTypes.Email, auth.User.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Secrets"]));

            return "";
        }

        public Task<LoginResponseViewModel> Login(AuthViewModel authViewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LoginResponseViewModel> Register(CreateUserViewModel userViewModel, AuthViewModel authViewModel)
        {
            Auth showAuthViewModel = await this._authRepository.Register(userViewModel, authViewModel);
            throw new System.Exception();
        }
    }
}
