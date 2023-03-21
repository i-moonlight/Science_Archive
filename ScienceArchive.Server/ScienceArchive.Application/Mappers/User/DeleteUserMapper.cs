using System;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Application.Mappers
{
    public class DeleteUserMapper
    {
        public static DeleteUserResponseDto MapToResponse(Guid id)
        {
            return new DeleteUserResponseDto
            {
                Id = id,
            };
        }
    }
}

