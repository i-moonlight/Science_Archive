using System;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Application.UseCases
{
    public class CreateUserUseCase
    {
        private IUserRepository _userRepository;

        public CreateUserUseCase(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(User user)
        {
            user.HashOwnPassword();
            var users = await _userRepository.GetAll();

            _ = users.Any(u => u.Email == user.Email) ?
                throw new Exception("This email is already in use") : false;

            _ = users.Any(u => u.Login == user.Login) ?
                throw new Exception("This login is already in use") : false;

            return await _userRepository.Create(user);
        }
    }
}

