using System;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Dtos.User.Response;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.UserUseCases
{
    public class GetAllUsersUseCase : IUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDto> _mapper;

        public GetAllUsersUseCase(IUserRepository userRepository, IMapper<User, UserDto> mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetAllUsersResponseDto> Execute(GetAllUsersRequestDto contract)
        {
            List<User> users = await _userRepository.GetAll();
            var userDtos = users.Select((user) => _mapper.MapToModel(user)).ToList();

            return new GetAllUsersResponseDto(userDtos);
        }
    }
}

