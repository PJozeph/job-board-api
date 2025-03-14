using JobBoard.Models;

namespace JobBoard.Repository {
    public class AuthRepository: IAuthRepository {
        private readonly IConfiguration configuration;

        public AuthRepository(IConfiguration config) {
            configuration = config;
        }

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        public User UserExists(string email)
        {
            throw new NotImplementedException();
            
        }
    }
}