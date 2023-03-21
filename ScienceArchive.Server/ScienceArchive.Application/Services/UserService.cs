using System;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Application.UseCases;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Services;

namespace ScienceArchive.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AuthorizeUserUseCase _authorizeUseCase;
        private readonly GetAllUsersUseCase _getAllUseCase;
        private readonly CreateUserUseCase _createUseCase;
        private readonly DeleteUserUseCase _deleteUseCase;
        private readonly UpdateUserUseCase _updateUseCase;

        public UserService(
            AuthorizeUserUseCase checkUserExistUseCase,
            GetAllUsersUseCase getAllUseCase,
            CreateUserUseCase createUserUseCase,
            DeleteUserUseCase deleteUserUseCase,
            UpdateUserUseCase updateUserUseCase)
        {
            _authorizeUseCase = checkUserExistUseCase;
            _getAllUseCase = getAllUseCase;
            _createUseCase = createUserUseCase;
            _deleteUseCase = deleteUserUseCase;
            _updateUseCase = updateUserUseCase;
        }

        /// <inheritdoc/>
        public async Task<AuthorizeUserResponseDto> Authorize(AuthorizeUserRequestDto contract)
        {
            var user = await _authorizeUseCase.Execute(contract.Login, contract.Password);

            if (user is null)
            {
                throw new Exception("No such user exist!");
            }

            return new AuthorizeUserResponseDto
            {
                UserExist = true,
                User = user
            };
        }

        /// <inheritdoc/>
        public async Task<GetAllUsersResponseDto> GetAll()
        {
            List<User> users = await _getAllUseCase.Execute();

            return GetAllUsersMapper.MapToResponse(users);
        }

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> Create(CreateUserRequestDto contract)
        {
            User userToCreate = CreateUserMapper.MapToEntity(contract);
            User createdUser = await _createUseCase.Execute(userToCreate);

            return CreateUserMapper.MapToResponse(createdUser);
        }

        /// <inheritdoc/>
        public async Task<DeleteUserResponseDto> Delete(DeleteUserRequestDto contract)
        {
            Guid deletedUserId = await _deleteUseCase.Execute(contract.Id);

            return DeleteUserMapper.MapToResponse(deletedUserId);
        }

        /// <inheritdoc/>
        public async Task<UpdateUserResponseDto> Update(UpdateUserRequestDto contract)
        {
            User userToUpdate = UpdateUserMapper.MapToEntity(contract);
            User updatedUser = await _updateUseCase.Execute(contract.Id, userToUpdate);

            return UpdateUserMapper.MapToResponse(updatedUser);
        }

    }
}

