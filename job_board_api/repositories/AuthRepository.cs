using System.Security.Cryptography;
using AutoMapper;
using JobBoard.Data;
using JobBoard.Dtos;
using JobBoard.Models;
using JobBoard.utils;

namespace JobBoard.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContextEntityFramework _dataContext;

        private readonly IMapper _registerMapper;
        private readonly AuthUtils _authUtils;

        public AuthRepository(IConfiguration config)
        {
            _registerMapper = new MapperConfiguration(
                cfg => cfg.CreateMap<RegisterDTO, User>()).CreateMapper();
            _dataContext = new DataContextEntityFramework(config);
            _authUtils = new AuthUtils(config);
        }

        public string Login(LoginDTO loginDTO)
        {
            User user = _dataContext.Users.FirstOrDefault(user => user.Email == loginDTO.Email)!;
            if (user != null)
            {
                byte[] passwordHash = _authUtils.GetPasswordHash(loginDTO.Password, user.PasswordSalt);

                if (passwordHash.SequenceEqual(user.PasswordHash))
                {
                    return _authUtils.CreateToken(user.UserId);
                }
                throw new Exception("Password is incorrect");
            }
            throw new Exception("User does not exist");
            
        }

        public User Register(RegisterDTO registerDTO)
        {
            if (registerDTO.ConfirmPassword == registerDTO.Password)
            {
                User userIsExist = _dataContext.Users.FirstOrDefault(user => user.Email == registerDTO.Email)!;
                if (userIsExist == null)
                {
                    User userToAdd = _registerMapper.Map<User>(registerDTO);
                    byte[] randomSalt = new byte[128 / 8];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(randomSalt);
                    }
                    byte[] passwordHash = _authUtils.GetPasswordHash(registerDTO.Password, randomSalt);
                    userToAdd.PasswordHash = passwordHash;
                    userToAdd.PasswordSalt = randomSalt;
                    _dataContext.Users.Add(userToAdd);
                    if (_dataContext.SaveChanges() > 0)
                    {
                        return userToAdd;
                    }
                    throw new Exception("User could not be added");
                }
                throw new Exception("User already exists");
            }
            throw new Exception("Passwords do not match");
        }

        public User UserExists(string email)
        {
            throw new NotImplementedException();

        }
    }
}