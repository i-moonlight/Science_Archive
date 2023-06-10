using System;
using System.Diagnostics.Contracts;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases
{
    public class DeleteUserUseCase : IUseCase<Guid, DeleteUserContract>
    {
        private IUserRepository _userRepository;

        public DeleteUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Execute(DeleteUserContract contract)
        {
            return await _userRepository.Delete(contract.UserId);
        }
    }
}

