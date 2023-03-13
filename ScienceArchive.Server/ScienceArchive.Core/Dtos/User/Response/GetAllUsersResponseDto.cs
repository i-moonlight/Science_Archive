using System;
namespace ScienceArchive.Core.Dtos.UserResponse
{
    public record class GetAllUsersResponseDto
    {
        public required List<UserDto> Users { get; set; }
    }
}

