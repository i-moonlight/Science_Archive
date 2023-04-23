using System;
using ScienceArchive.Application.Mappers;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases
{
    public class UpdateUserUseCase : IUseCase<UpdateUserResponseDto, UpdateUserRequestDto>
    {
        private IUserRepository _userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponseDto> Execute(UpdateUserRequestDto contract)
        {
            User userToUpdate = UpdateUserMapper.MapToEntity(contract);
            User updatedUser = await _userRepository.Update(contract.Id, userToUpdate);

            return UpdateUserMapper.MapToResponse(updatedUser);
        }
    }
}

