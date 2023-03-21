using System;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Application.Mappers
{
    public static class GetAllUsersMapper
    {
        public static GetAllUsersResponseDto MapToResponse(List<User> users)
        {
            var usersResponse = users.Select(user => UserMapper.MapToResponse(user)).ToList();

            return new GetAllUsersResponseDto
            {
                Users = usersResponse,
            };
        }
    }
}

