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
    /// Create new user
    /// </summary>
    /// <param name="dto">DTO contract to create new user</param>
    /// <returns>Response DTO</returns>
    Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto dto);

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