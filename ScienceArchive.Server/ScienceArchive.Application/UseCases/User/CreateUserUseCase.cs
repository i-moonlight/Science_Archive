using System;
using ScienceArchive.Application.Mappers;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases
{
    public class CreateUserUseCase : IUseCase<CreateUserResponseDto, CreateUserRequestDto>
    {
        private IUserRepository _userRepository;

        public CreateUserUseCase(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponseDto> Execute(CreateUserRequestDto contract)
        {
            User userToCreate = UserMapper.MapToEntity(contract.User);
            userToCreate.HashAndSetPassword(contract.Password);

            var users = await _userRepository.GetAll();

            _ = users.Any(user => user.Email == userToCreate.Email) ?
                throw new Exception("This email is already in use") : false;

            _ = users.Any(user => user.Login == userToCreate.Login) ?
                throw new Exception("This login is already in use") : false;

            var createdUser = await _userRepository.Create(userToCreate);

            var createdUserDto = UserMapper.MapToDto(createdUser);

            return new CreateUserResponseDto(createdUserDto);
        }
    }
}

