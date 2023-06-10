using System;
using System.Xml.Linq;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Interfaces;

namespace ScienceArchive.Application.Mappers
{
    public class UserMapper : IApplicationMapper<User, UserDto>
    {
        public UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Login = user.Login
            };
        }

        public User MapToEntity(UserDto model, string? id = null)
        {
            Guid? userId = id is not null
                ? new Guid(id)
                : null;

            return new User(userId)
            {
                Name = model.Name,
                Email = model.Email,
                Login = model.Login
            };
        }
    }
}

