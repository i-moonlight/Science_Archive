using System;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases
{
    public class GetAllUsersUseCase : IUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllUsersResponseDto> Execute(GetAllUsersRequestDto contract)
        {
            List<User> users = await _userRepository.GetAll();

            return GetAllUsersMapper.MapToResponse(users);
        }
    }
}

