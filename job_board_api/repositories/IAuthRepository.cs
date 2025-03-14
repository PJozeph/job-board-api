using JobBoard.Dtos;
using JobBoard.Models;

namespace JobBoard.Repository {

    public interface IAuthRepository
    {
        User Register(RegisterDTO registerDTO);
        User Login(string email, string password);

        User UserExists(string email);
    }
}