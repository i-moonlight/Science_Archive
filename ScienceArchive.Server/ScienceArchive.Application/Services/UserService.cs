using System;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Application.UseCases;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto> _getAllUseCase;
        private readonly IUseCase<CreateUserResponseDto, CreateUserRequestDto> _createUseCase;
        private readonly IUseCase<DeleteUserResponseDto, DeleteUserRequestDto> _deleteUseCase;
        private readonly IUseCase<UpdateUserResponseDto, UpdateUserRequestDto> _updateUseCase;

        public UserService(
            IUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto> getAllUseCase,
            IUseCase<CreateUserResponseDto, CreateUserRequestDto> createUserUseCase,
            IUseCase<DeleteUserResponseDto, DeleteUserRequestDto> deleteUserUseCase,
            IUseCase<UpdateUserResponseDto, UpdateUserRequestDto> updateUserUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _createUseCase = createUserUseCase;
            _deleteUseCase = deleteUserUseCase;
            _updateUseCase = updateUserUseCase;
        }

        /// <inheritdoc/>
        public async Task<GetAllUsersResponseDto> GetAll()
        {
            var emptyDto = new GetAllUsersRequestDto();

            return await _getAllUseCase.Execute(emptyDto);
        }

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> Create(CreateUserRequestDto contract)
        {
            return await _createUseCase.Execute(contract);
        }

        /// <inheritdoc/>
        public async Task<DeleteUserResponseDto> Delete(DeleteUserRequestDto contract)
        {
            return await _deleteUseCase.Execute(contract);
        }

        /// <inheritdoc/>
        public async Task<UpdateUserResponseDto> Update(UpdateUserRequestDto contract)
        {
            return await _updateUseCase.Execute(contract);
        }

    }
}

