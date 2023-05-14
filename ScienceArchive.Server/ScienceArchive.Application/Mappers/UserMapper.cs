using System;
using System.Xml.Linq;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.User;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Domain.Entities;
using Microsoft.Extensions.Configuration.UserSecrets;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login
            };
        }

        public User MapToEntity(UserDto userDto, Guid? id = null)
        {
            var userId = id ?? Guid.NewGuid();

            return new User(userId)
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Login = userDto.Login
            };
        }
    }
}

