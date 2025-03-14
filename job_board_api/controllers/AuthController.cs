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
            if (registerDTO.ConfirmPassword != registerDTO.Password)
            {
                User userIsExist = _authRepository.UserExists(registerDTO.Email);
                if (userIsExist != null)
                {

                }
                throw new Exception("User already exists");
            }
            throw new Exception("Passwords do not match");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}