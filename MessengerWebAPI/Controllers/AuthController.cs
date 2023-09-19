using System;
using System.Threading.Tasks;
using MessengerWebAPI.Services;
using MessengerWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MessengerWebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _config = configuration;
        }

        public IActionResult Test()
        {
            return Ok(_config["AppSettings:Secret"]);
        }

        public async Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Register([FromBody] CreateUserViewModel userViewModel, [FromBody] AuthViewModel authViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
