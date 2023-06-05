using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Infrastructure.Persistence.Models;

namespace ScienceArchive.Infrastructure.Persistence.Mappers
{
    public class UserMapper : IMapper<User, UserModel>
    {
        public UserModel MapToModel(User user)
        {
            if (String.IsNullOrWhiteSpace(user.PasswordSalt))
            {
                throw new NullReferenceException("Password salt is invalid!");
            }

            var userModel = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt,
            };

            return userModel;
        }

        public User MapToEntity(UserModel userModel, Guid? id = null)
        {
            var user = new User(userModel.Id, userModel.PasswordSalt)
            {
                Email = userModel.Email,
                Login = userModel.Login,
                Name = userModel.Name,
                Password = userModel.Password ?? "",
            };

            return user;
        }
    }
}

