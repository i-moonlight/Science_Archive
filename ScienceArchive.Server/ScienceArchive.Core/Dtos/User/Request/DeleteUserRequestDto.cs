using System;
namespace ScienceArchive.Core.Dtos.UserRequest
{
    /// <summary>
    /// Request contract to delete user
    /// </summary>
    /// <param name="Id">ID of the user to delete</param>
    public record class DeleteUserRequestDto(Guid Id);
}

