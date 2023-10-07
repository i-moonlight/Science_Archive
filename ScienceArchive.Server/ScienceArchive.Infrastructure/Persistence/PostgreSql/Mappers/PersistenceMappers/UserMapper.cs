using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

internal class UserMapper : IPersistenceMapper<User, UserModel>
{
    public UserModel MapToModel(User user)
    {
        var rolesIds = user.RolesIds.Select(r => r.Value).ToList();
        
        return new()
        {
            Id = user.Id.Value,
            RolesIds = rolesIds,
            Email = user.Email,
            Login = user.Login,
            Name = user.Name,
            Password = user.Password.Value,
            PasswordSalt = user.Password.Salt
        };
    }

    public User MapToEntity(UserModel model)
    {
        var userId = UserId.CreateFromGuid(model.Id);
        var rolesIds = model.RolesIds is not null
            ? model.RolesIds.Select(RoleId.CreateFromGuid).ToList()
            : new List<RoleId>();
        
        return new(userId)
        {
            RolesIds = rolesIds, 
            Email = model.Email,
            Login = model.Login,
            Name = model.Name,
            Password = new UserPassword
            {
                Value = model.Password ?? "",
                Salt = model.PasswordSalt ?? "", 
            }
        };
    }
}