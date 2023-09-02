using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.UserUseCases;

internal class UpdateUserUseCase : IUseCase<User, UpdateUserContract>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<User> Execute(UpdateUserContract contract)
    {
        return await _userRepository.Update(contract.Id, contract.User);
    }
}