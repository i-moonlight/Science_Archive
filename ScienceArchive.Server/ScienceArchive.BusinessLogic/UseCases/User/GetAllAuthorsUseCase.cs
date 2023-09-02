using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases;

public class GetAllAuthorsUseCase : IUseCase<List<Author>, GetAllAuthorsContract>
{
	private readonly IUserRepository _userRepository;

	public GetAllAuthorsUseCase(IUserRepository userRepository)
	{
		_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
	}
	
	public async Task<List<Author>> Execute(GetAllAuthorsContract contract)
	{
		return await _userRepository.GetAllAuthors();
	}
}