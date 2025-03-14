using JobBoard.Models;

namespace JobBoard.Repository {

    public interface IAuthRepository
    {
        User Register(User user, string password);
        User Login(string email, string password);

        User UserExists(string email);
    }
}