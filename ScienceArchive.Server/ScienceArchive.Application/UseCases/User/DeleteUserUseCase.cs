using System;
using ScienceArchive.Application.Mappers;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Dtos.User.Response;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UserUseCases
{
    public class DeleteUserUseCase : IUseCase<DeleteUserResponseDto, DeleteUserRequestDto>
    {
        private IUserRepository _userRepository;

        public DeleteUserUseCase(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }
        public async Task<DeleteUserResponseDto> Execute(DeleteUserRequestDto contract)
        {
            var deletedUserId = await _userRepository.Delete(contract.Id);

            return new DeleteUserResponseDto(deletedUserId);
        }
    }
}

