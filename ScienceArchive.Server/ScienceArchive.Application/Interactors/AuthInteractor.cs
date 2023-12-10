using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.Auth.Request;
using ScienceArchive.Application.Dtos.Auth.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.RoleContracts;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Application.Interactors;

internal class AuthInteractor : IAuthInteractor
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IApplicationMapper<User, UserDto> _userMapper;

    public AuthInteractor(
        IUserService userService,
        IRoleService roleService,
        IApplicationMapper<User, UserDto> userMapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
    }

    /// <inheritdoc/>
    public async Task<LoginResponseDto> Login(LoginRequestDto dto)
    {
        var preparedDto = new LoginRequestDto(dto.Login.Trim(), dto.Password.Trim());
        
        var contract = new GetUserByCredentialsContract(preparedDto.Login, preparedDto.Password);
        var user = await _userService.GetUserByCredentials(contract);

        if (user is null)
        {
            throw new Exception("User with specified credentials was not found!");
        }
        
        return new(_userMapper.MapToDto(user));
    }

    /// <inheritdoc/>
    public async Task<SignUpResponseDto> SignUp(SignUpRequestDto dto)
    {
        var preparedDto = new SignUpRequestDto(
            new UserDto
            {
                Name = dto.User.Name.Trim(),
                Email = dto.User.Email.Trim(),
                Login = dto.User.Login.Trim(),
                RolesIds = dto.User.RolesIds
            },
            dto.Password.Trim()
        );
        
        var userToCreate = _userMapper.MapToEntity(preparedDto.User);
        userToCreate.Password.Value = preparedDto.Password;
        
        var contract = new CreateUserContract(userToCreate);
        var createdUser = await _userService.Create(contract);

        return new(_userMapper.MapToDto(createdUser));
    }

    /// <inheritdoc/>
    public async Task<CheckUserClaimsResponseDto> CheckUserClaims(CheckUserClaimsRequestDto dto)
    {
        if (dto.RequiredClaims is null)
        {
            return new(true);
        }
        
        var getClaimsContract = new GetUserClaimsContract(UserId.CreateFromString(dto.UserId));
        var userClaims = await _roleService.GetUserClaims(getClaimsContract);
        
        foreach (var requiredClaim in dto.RequiredClaims)
        {
            if (!userClaims.Exists(uc => uc.Value == requiredClaim))
            {
                return new(false);
            }
        }

        return new(true);
    }
}