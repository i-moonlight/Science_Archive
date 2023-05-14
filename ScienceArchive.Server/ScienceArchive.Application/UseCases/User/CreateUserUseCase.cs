using System;
using ScienceArchive.Application.Mappers;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Interfaces.UseCases;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.UseCases
{
    public class CreateUserUseCase : IUseCase<CreateUserResponseDto, CreateUserRequestDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDto> _mapper;

        public CreateUserUseCase(IUserRepository userRepository, IMapper<User, UserDto> mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponseDto> Execute(CreateUserRequestDto contract)
        {
            User userToCreate = _mapper.MapToEntity(contract.User);
            userToCreate.HashAndSetPassword(contract.Password);

            var users = await _userRepository.GetAll();

            _ = users.Any(user => user.Email == userToCreate.Email) ?
                throw new Exception("This email is already in use") : false;

            _ = users.Any(user => user.Login == userToCreate.Login) ?
                throw new Exception("This login is already in use") : false;

            var createdUser = await _userRepository.Create(userToCreate);

            var createdUserDto = _mapper.MapToDto(createdUser);

            return new CreateUserResponseDto(createdUserDto);
        }
    }
}

