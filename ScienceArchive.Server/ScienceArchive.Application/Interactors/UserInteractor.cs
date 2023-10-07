using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Dtos.User.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Application.Interactors;

internal class UserInteractor : IUserInteractor
{
    private readonly IApplicationMapper<User, UserDto> _userMapper;
    private readonly IApplicationMapper<Author, AuthorDto> _authorMapper;
    private readonly IUserService _userService;

    public UserInteractor(
        IApplicationMapper<User, UserDto> userMapper,
        IApplicationMapper<Author, AuthorDto> authorMapper,
        IUserService userService)
    {
        _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
        _authorMapper = authorMapper ?? throw new ArgumentNullException(nameof(authorMapper));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    /// <inheritdoc/>
    public async Task<GetAllUsersResponseDto> GetAllUsers(GetAllUsersRequestDto dto)
    {
        var emptyContract = new GetAllUsersContract();
        var users = await _userService.GetAll(emptyContract);

        var usersDtos = users.Select((user) => _userMapper.MapToDto(user)).ToList();
        return new(usersDtos);
    }

    public async Task<GetAllAuthorsResponseDto> GetAllAuthors(GetAllAuthorsRequestDto dto)
    {
        var emptyContract = new GetAllAuthorsContract();
        var authors = await _userService.GetAllAuthors(emptyContract);

        var authorsDtos = authors.Select(_authorMapper.MapToDto).ToList();
        return new(authorsDtos);
    }

    public async Task<GetUserByIdResponseDto> GetUserById(GetUserByIdRequestDto dto)
    {
        var contract = new GetUserByIdContract(UserId.CreateFromString(dto.Id));
        var user = await _userService.GetById(contract);

        var userDto = user is not null
            ? _userMapper.MapToDto(user)
            : null;

        return new(userDto);
    }

    /// <inheritdoc/>
    public async Task<DeleteUserResponseDto> DeleteUser(DeleteUserRequestDto dto)
    {
        var contract = new DeleteUserContract(UserId.CreateFromString(dto.Id));
        var deletedUserId = await _userService.Delete(contract);

        return new(deletedUserId.ToString());
    }

    /// <inheritdoc/>
    public async Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto dto)
    {
        var contract = new UpdateUserContract(UserId.CreateFromString(dto.Id), _userMapper.MapToEntity(dto.User));
        var updatedUser = await _userService.Update(contract);

        return new(_userMapper.MapToDto(updatedUser));
    }
}