using System;
namespace ScienceArchive.Application.Dtos.User.Response
{
    /// <summary>
    /// Response contract to delete user request
    /// </summary>
    /// <param name="Id">ID of the deleted user</param>
    public record class DeleteUserResponseDto(Guid Id);
}

