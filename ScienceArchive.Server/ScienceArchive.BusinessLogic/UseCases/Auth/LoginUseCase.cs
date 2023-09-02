using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.BusinessLogic.Utils;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.AuthContracts;

namespace ScienceArchive.BusinessLogic.UseCases.Auth;

internal class LoginUseCase : IUseCase<User, LoginContract>
{
    private readonly IUserRepository _userRepository;

    public LoginUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<User> Execute(LoginContract contract)
    {
        var login = contract.Login;
        var password = contract.Password;

        return await GetUserByCredentials(login, password);
    }

    private async Task<User> GetUserByCredentials(string login, string password)
    {
        User? foundUser = null;

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Login or password are empty!");
        }

        var users = await _userRepository.GetAllUsersWithPasswords();
        foundUser = users.Find(u => u.Login == login || u.Email == login);

        if (foundUser is null)
        {
            throw new Exception($"Wrong login or password!");
        }


        var passwordHash = StringGenerator.HashPassword(password, foundUser.Password.Salt);

        if (passwordHash != foundUser.Password.Value)
        {
            throw new Exception("Wrong login or password!");
        }

        return foundUser;
    }
}