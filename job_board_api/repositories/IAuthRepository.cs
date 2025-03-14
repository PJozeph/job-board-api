using JobBoard.Dtos;
using JobBoard.Models;

namespace JobBoard.Repository {

    public interface IAuthRepository
    {
        User Register(RegisterDTO registerDTO);
        string Login(LoginDTO loginDTO);
        User UserExists(string email);
    }
}