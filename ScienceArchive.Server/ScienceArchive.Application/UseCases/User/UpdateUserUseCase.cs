using System;
using ScienceArchive.Application.Mappers;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Interfaces.UseCases;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Dtos;

namespace ScienceArchive.Application.UseCases
{
    public class UpdateUserUseCase : IUseCase<UpdateUserResponseDto, UpdateUserRequestDto>
    {
        private IUserRepository _userRepository;
        private IMapper<User, UserDto> _mapper;

        public UpdateUserUseCase(IUserRepository userRepository, IMapper<User, UserDto> mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponseDto> Execute(UpdateUserRequestDto contract)
        {
            User userToUpdate = _mapper.MapToEntity(contract.User);
            User updatedUser = await _userRepository.Update(contract.UserId, userToUpdate);

            var updatedUserDto = _mapper.MapToDto(updatedUser);

            return new UpdateUserResponseDto(updatedUserDto);
        }
    }
}

