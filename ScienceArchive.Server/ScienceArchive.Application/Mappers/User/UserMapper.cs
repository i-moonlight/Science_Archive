using System;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapToResponse(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
            };
        }
    }
}

