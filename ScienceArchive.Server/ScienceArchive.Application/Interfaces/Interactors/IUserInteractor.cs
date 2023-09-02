using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Dtos.User.Response;

namespace ScienceArchive.Application.Interfaces.Interactors;

/// <summary>
/// Application user interactor
/// </summary>
public interface IUserInteractor
{
    /// <summary>
    /// Get all users
    /// </summary>
    /// <param name="dto">DTO contract to get all users</param>
    /// <returns>Response DTO</returns>
    Task<GetAllUsersResponseDto> GetAllUsers(GetAllUsersRequestDto dto);

    /// <summary>
    /// Get all users which have written any article
    /// </summary>
    /// <param name="dto">DTO contract to get all authors</param>
    /// <returns>Response DTO</returns>
    Task<GetAllAuthorsResponseDto> GetAllAuthors(GetAllAuthorsRequestDto dto);

    /// <summary>
    /// Get user by ID
    /// </summary>
    /// <param name="dto">DTO contract to get user by its ID</param>
    /// <returns>Response DTO</returns>
    Task<GetUserByIdResponseDto> GetUserById(GetUserByIdRequestDto dto);

    /// <summary>
    /// Update existing user
    /// </summary>
    /// <param name="dto">DTO contract to update user</param>
    /// <returns>Response DTO</returns>
    Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto dto);

    /// <summary>
    /// Delete existing user
    /// </summary>
    /// <param name="dto">DTO contract to delete user</param>
    /// <returns>Response DTO</returns>
    Task<DeleteUserResponseDto> DeleteUser(DeleteUserRequestDto dto);
}