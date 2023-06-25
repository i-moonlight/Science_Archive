using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.Auth.Request;
using ScienceArchive.Application.Dtos.Auth.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.AuthContracts;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Application.Interactors;

public class AuthInteractor : IAuthInteractor
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IApplicationMapper<User, UserDto> _userMapper;

    public AuthInteractor(
        IAuthService authService, 
        IUserService userService,
        IApplicationMapper<User, UserDto> userMapper)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
    }

    /// <inheritdoc/>
    public async Task<LoginResponseDto> Login(LoginRequestDto dto)
    {
        var contract = new LoginContract(dto.Login, dto.Password);
        var user = await _authService.Login(contract);
        
        return new(_userMapper.MapToDto(user));
    }

    /// <inheritdoc/>
    public async Task<SignUpResponseDto> SignUp(SignUpRequestDto dto)
    {
        var contract = new CreateUserContract(_userMapper.MapToEntity(dto.User));
        var createdUser = await _userService.Create(contract);

        return new(_userMapper.MapToDto(createdUser));
    }
}