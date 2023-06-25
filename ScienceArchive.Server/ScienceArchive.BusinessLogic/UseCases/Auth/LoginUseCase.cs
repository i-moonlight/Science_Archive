using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.BusinessLogic.Utils;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.AuthContracts;

namespace ScienceArchive.BusinessLogic.UseCases.Auth;

public class LoginUseCase : IUseCase<User, LoginContract>
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

        if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Login or password are empty!");
        }

        var users = await _userRepository.GetAllUsersWithPasswords();
        foundUser = users.Find(u => u.Login == login || u.Email == login);

        if (foundUser is null)
        {
            throw new Exception($"Wrong login or password!");
        }


        var passwordHash = StringGenerator.HashPassword(password, foundUser.PasswordSalt);

        if (passwordHash != foundUser.Password)
        {
            throw new Exception("Wrong login or password!");
        }

        return foundUser;
    }
}