using System;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Application.UseCases
{
    public class GetAllUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Execute()
        {
            return await _userRepository.GetAll();
        }
    }
}

