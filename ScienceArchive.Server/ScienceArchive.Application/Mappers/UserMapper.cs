using System;
using System.Xml.Linq;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.User;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Application.Mappers
{
    public class UserMapper
    {
        public static IdentifiedUserDto MapToDto(User user)
        {
            return new IdentifiedUserDto(
                user.Id,
                user.Name,
                user.Email,
                user.Login);
        }

        public static User MapToEntity(UserDto userDto)
        {
            return new User(Guid.NewGuid())
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Login = userDto.Login
            };
        }
    }
}

