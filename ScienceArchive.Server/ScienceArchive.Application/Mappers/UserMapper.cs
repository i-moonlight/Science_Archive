using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Application.Mappers;

public class UserMapper : IApplicationMapper<User, UserDto>
{
    public UserDto MapToDto(User user)
    {
        var rolesIds = user.RolesIds.Select(r => r.ToString()).ToList();
        
        return new UserDto
        {
            Id = user.Id.ToString(),
            RolesIds = rolesIds,
            Name = user.Name,
            Email = user.Email,
            Login = user.Login
        };
    }

    public User MapToEntity(UserDto model)
    {
        var userId = model.Id is not null
            ? UserId.CreateFromString(model.Id)
            : UserId.CreateNew();

        var rolesIds = model.RolesIds.Select(RoleId.CreateFromString).ToList();
        
        return new User(userId)
        {
            Name = model.Name,
            Email = model.Email,
            Login = model.Login,
            RolesIds = rolesIds,
            Password = new UserPassword()
        };
    }
}