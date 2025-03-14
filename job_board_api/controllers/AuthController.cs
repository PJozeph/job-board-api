using JobBoard.Dtos;
using JobBoard.Models;
using JobBoard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            User user = _authRepository.Register(registerDTO);
            if (user == null)
            {
                return BadRequest("User could not be added");
            }
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            string token = _authRepository.Login(loginDTO);
            return Ok(
                new Dictionary<string, string>
                {
                    {"token", token}
                }
            );
        }
    }
}