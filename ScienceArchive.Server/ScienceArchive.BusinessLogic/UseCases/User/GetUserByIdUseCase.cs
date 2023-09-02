using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases;

public class GetUserByIdUseCase : IUseCase<User?, GetUserByIdContract>
{
	private readonly IUserRepository _userRepository;
	
	public GetUserByIdUseCase(IUserRepository userRepository)
	{
		_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
	}
	
	public async Task<User?> Execute(GetUserByIdContract contract)
	{
		return await _userRepository.GetById(contract.Id);
	}
}