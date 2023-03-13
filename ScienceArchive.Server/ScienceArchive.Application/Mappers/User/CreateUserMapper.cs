using System;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;

namespace ScienceArchive.Application.Mappers
{
    public static class CreateUserMapper
    {
        public static CreateUserResponseDto MapToResponse(User user)
        {
            return new CreateUserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
            };
        }

        public static User MapToEntity(CreateUserRequestDto request)
        {
            return new User(Guid.NewGuid())
            {
                Name = request.Name,
                Email = request.Email,
                Login = request.Login,
                Password = request.Password,
            };
        }
    }
}

