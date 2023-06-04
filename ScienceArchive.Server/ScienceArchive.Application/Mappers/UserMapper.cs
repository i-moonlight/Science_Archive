using System;
using System.Xml.Linq;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.User;
using ScienceArchive.Core.Domain.Entities;
using Microsoft.Extensions.Configuration.UserSecrets;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto MapToModel(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login
            };
        }

        public User MapToEntity(UserDto model, Guid? id = null)
        {
            var userId = id ?? Guid.NewGuid();

            return new User(userId)
            {
                Name = model.Name,
                Email = model.Email,
                Login = model.Login
            };
        }
    }
}

