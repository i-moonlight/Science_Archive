using System;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Application.Mappers
{
    public static class UpdateUserMapper
    {
        public static UpdateUserResponseDto MapToResponse(User user)
        {
            return new UpdateUserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
            };
        }

        public static User MapToEntity(UpdateUserRequestDto request)
        {
            return new User(request.Id)
            {
                Name = request.Name,
                Email = request.Email,
                Login = request.Login,
                Password = request.Password,
            };
        }
    }
}

