using System;
using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Dtos.User.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Application.Interactors
{
    public class UserInteractor : IUserInteractor
    {
        private readonly IApplicationMapper<User, UserDto> _userMapper;
        private readonly IUserService _userService;

        public UserInteractor(
            IApplicationMapper<User, UserDto> userMapper,
            IUserService userService)
        {
            if (userMapper is null)
            {
                throw new ArgumentNullException(nameof(userMapper));
            }

            if (userService is null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            _userMapper = userMapper;
            _userService = userService;
        }

        /// <inheritdoc/>
        public async Task<GetAllUsersResponseDto> GetAllUsers(GetAllUsersRequestDto dto)
        {
            var emptyContract = new GetAllUsersContract();
            var users = await _userService.GetAll(emptyContract);

            var usersDtos = users.Select((user) => _userMapper.MapToDto(user)).ToList();
            return new(usersDtos);
        }

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto dto)
        {
            var userToCreate = _userMapper.MapToEntity(dto.User);
            var createUserContract = new CreateUserContract(userToCreate);

            var createdUser = await _userService.Create(createUserContract);
            var createdUserDto = _userMapper.MapToDto(createdUser);

            return new(createdUserDto);
        }

        /// <inheritdoc/>
        public Task<DeleteUserResponseDto> DeleteUser(DeleteUserRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

