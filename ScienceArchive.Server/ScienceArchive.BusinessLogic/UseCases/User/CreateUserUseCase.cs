using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.BusinessLogic.Utils;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases;

internal class CreateUserUseCase : IUseCase<User, CreateUserContract>
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<User> Execute(CreateUserContract contract)
    {
        var userToCreate = contract.User;

        userToCreate.Password.Salt = StringGenerator.CreateSalt();
        userToCreate.Password.Value = StringGenerator.HashPassword(userToCreate.Password.Value, userToCreate.Password.Salt);

        var users = await _userRepository.GetAll();

        _ = users.Any(user => user.Email == userToCreate.Email)
            ? throw new Exception("This email is already in use")
            : false;

        _ = users.Any(user => user.Login == userToCreate.Login)
            ? throw new Exception("This login is already in use")
            : false;

        return await _userRepository.Create(userToCreate);
    }
}