﻿using System;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;
using ScienceArchive.Core.Utils;

namespace ScienceArchive.Application.UseCases
{
    public class AuthorizeUserUseCase : IUseCase<AuthorizeUserResponseDto, AuthorizeUserRequestDto>
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
        public async Task<AuthorizeUserResponseDto> Execute(AuthorizeUserRequestDto contract)
        {
            var login = contract.Login;
            var password = contract.Password;

            var user = await GetUserByCredentials(login, password);

            if (user is null)
            {
                throw new Exception("No such user exist!");
            }

            return new AuthorizeUserResponseDto
            {
                UserExist = true,
                User = UserMapper.MapToResponse(user),
            };
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

