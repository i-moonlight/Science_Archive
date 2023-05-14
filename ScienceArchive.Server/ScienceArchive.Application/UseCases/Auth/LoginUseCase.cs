using System;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Core.Dtos.Auth.Request;
using ScienceArchive.Core.Dtos.Auth.Response;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;
using ScienceArchive.Core.Utils;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Dtos;

namespace ScienceArchive.Application.UseCases.Auth
{
    public class LoginUseCase : IUseCase<LoginResponseDto, LoginRequestDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDto> _mapper;

        public LoginUseCase(IUserRepository userRepository, IMapper<User, UserDto> mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Authorize user by his credentials
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>JWT token</returns>
        public async Task<LoginResponseDto> Execute(LoginRequestDto contract)
        {
            var login = contract.Login;
            var password = contract.Password;

            var user = await GetUserByCredentials(login, password);

            if (user is null)
            {
                throw new Exception("No such user exist!");
            }

            return new LoginResponseDto(_mapper.MapToDto(user));
        }

        private async Task<User> GetUserByCredentials(string login, string password)
        {
            User? foundUser = null;

            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Login or password are empty!");
            }

            var users = await _userRepository.GetAll();
            foundUser = users.Find(u => u.Login == login || u.Email == login);

            if (foundUser is null)
            {
                throw new Exception($"Wrong login or password!");
            }


            var passwordHash = StringGenerator.HashPassword(password, foundUser.PasswordSalt);

            if (passwordHash != foundUser.Password)
            {
                throw new Exception("Wrong login or password!");
            }

            return foundUser;
        }
    }
}

