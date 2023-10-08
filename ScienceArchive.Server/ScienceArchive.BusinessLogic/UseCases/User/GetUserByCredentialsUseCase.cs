using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.BusinessLogic.Utils;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases;

public class GetUserByCredentialsUseCase : IUseCase<User?, GetUserByCredentialsContract>
{
	private readonly IUserRepository _userRepository;
	
	public GetUserByCredentialsUseCase(IUserRepository userRepository)
	{
		_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
	}
	
	public async Task<User?> Execute(GetUserByCredentialsContract contract)
	{
		var user = await _userRepository.GetAuthUserByLogin(contract.Login);

		if (user is null)
		{
			throw new Exception("User with specified credentials was not found!");
		}

		var password = StringGenerator.HashPassword(contract.Password, user.Password.Salt);

		if (user.Password.Value != password)
		{
			throw new Exception("User with specified credentials was not found!");
		}

		return user;
	}
}