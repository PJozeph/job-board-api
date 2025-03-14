using JobBoard.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        public AuthController()
        {
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}