using ScienceArchive.Application.Dtos.Auth.Request;
using ScienceArchive.Application.Dtos.Auth.Response;

namespace ScienceArchive.Application.Interfaces.Interactors;

/// <summary>
/// Application auth interactor
/// </summary>
public interface IAuthInteractor
{
    /// <summary>
    /// Login user, i.e. user authentication
    /// </summary>
    /// <param name="dto">DTO contract to authenticate user</param>
    /// <returns>Response DTO</returns>
    Task<LoginResponseDto> Login(LoginRequestDto dto);

    /// <summary>
    /// Sign up user, i.e. create new user
    /// </summary>
    /// <param name="dto">DTO contract to sign up user</param>
    /// <returns>Response DTO</returns>
    Task<SignUpResponseDto> SignUp(SignUpRequestDto dto);
}