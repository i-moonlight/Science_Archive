using ScienceArchive.Core.Repositories;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases;

internal class GetAllUsersUseCase : IUseCase<List<User>, GetAllUsersContract>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<List<User>> Execute(GetAllUsersContract contract)
    {
        return await _userRepository.GetAll();
    }
}