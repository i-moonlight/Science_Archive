using ScienceArchive.Core.Repositories;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Services.UserContracts;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.BusinessLogic.UserUseCases;

public class GetAllUsersUseCase : IUseCase<List<User>, GetAllUsersContract>
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