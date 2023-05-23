using System;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Application.UseCases;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;
using System.Diagnostics.Contracts;

namespace ScienceArchive.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<GetAllUsersResponseDto> GetAll()
        {
            var emptyDto = new GetAllUsersRequestDto();

            return await ExecuteUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto>(emptyDto);
        }

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> Create(CreateUserRequestDto contract)
        {
            return await ExecuteUseCase<CreateUserResponseDto, CreateUserRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<DeleteUserResponseDto> Delete(DeleteUserRequestDto contract)
        {
            return await ExecuteUseCase<DeleteUserResponseDto, DeleteUserRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<UpdateUserResponseDto> Update(UpdateUserRequestDto contract)
        {
            return await ExecuteUseCase<UpdateUserResponseDto, UpdateUserRequestDto>(contract);
        }

    }
}

