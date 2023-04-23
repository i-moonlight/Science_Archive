using System;
using ScienceArchive.Application.Mappers;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases
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

            Guid deletedUserId = await _userRepository.Delete(contract.Id);

            return DeleteUserMapper.MapToResponse(deletedUserId);
        }
    }
}

