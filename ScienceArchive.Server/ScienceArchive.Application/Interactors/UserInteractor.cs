using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Dtos.User.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Application.Interactors
{
    public class UserInteractor : IUserInteractor
    {
        private readonly IApplicationMapper<User, UserDto> _userMapper;
        private readonly IUserService _userService;

        public UserInteractor(
            IApplicationMapper<User, UserDto> userMapper,
            IUserService userService)
        {
            _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
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

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto dto)
        {
            var userToCreate = _userMapper.MapToEntity(dto.User);
            var createUserContract = new CreateUserContract(userToCreate);

            var createdUser = await _userService.Create(createUserContract);
            var createdUserDto = _userMapper.MapToDto(createdUser);

            return new(createdUserDto);
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
}

