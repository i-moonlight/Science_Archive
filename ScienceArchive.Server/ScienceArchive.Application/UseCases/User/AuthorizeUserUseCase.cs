using System;
using System.IdentityModel.Tokens.Jwt;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Utils;

namespace ScienceArchive.Application.UseCases
{
    public class AuthorizeUserUseCase
    {
        private IUserRepository _userRepository;

        public AuthorizeUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Authorize user by his credentials
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>JWT token</returns>
        public async Task<User> Execute(string login, string password)
        {
            var userExist = await CheckUserExist(login, password);
            return userExist;
        }

        private async Task<User> CheckUserExist(string login, string password)
        {
            User? foundUser = null;

            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Login or password are empty!");
            }

            var users = await _userRepository.GetAll();
            foundUser = users.Find(u => u.Login == login || u.Email == login);
            _ = foundUser ?? throw new Exception($"Wrong login or password!");

            var passwordHash = StringGenerator.HashPassword(password, foundUser.PasswordSalt);

            if (passwordHash != foundUser.Password)
            {
                throw new Exception("Wrong login or password!");
            }

            return foundUser;
        }
    }
}

