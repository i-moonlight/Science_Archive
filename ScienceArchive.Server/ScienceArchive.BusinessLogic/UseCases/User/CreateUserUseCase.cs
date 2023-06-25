using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.BusinessLogic.Utils;
using ScienceArchive.Core.Services.UserContracts;
using ScienceArchive.Core.Repositories;

namespace ScienceArchive.BusinessLogic.UserUseCases;

public class CreateUserUseCase : IUseCase<User, CreateUserContract>
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<User> Execute(CreateUserContract contract)
    {
        var userToCreate = contract.User;

        userToCreate.PasswordSalt = StringGenerator.CreateSalt();
        userToCreate.Password = StringGenerator.HashPassword(userToCreate.Password, userToCreate.PasswordSalt);

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