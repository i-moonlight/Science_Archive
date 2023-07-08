using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;

public class UserMapper : IPersistenceMapper<User, UserModel>
{
    public UserModel MapToModel(User user)
    {
        if (string.IsNullOrWhiteSpace(user.PasswordSalt))
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
            PasswordSalt = userModel.PasswordSalt ?? "",
        };

        return user;
    }
}