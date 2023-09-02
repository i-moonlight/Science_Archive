using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class UserService : BaseService, IUserService
{
    public UserService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc/>
    public async Task<User?> GetById(GetUserByIdContract contract)
    {
        return await ExecuteUseCase<User?, GetUserByIdContract>(contract);
    }
    
    /// <inheritdoc/>
    public async Task<List<User>> GetAll(GetAllUsersContract contract)
    {
        return await ExecuteUseCase<List<User>, GetAllUsersContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<Author>> GetAllAuthors(GetAllAuthorsContract contract)
    {
        return await ExecuteUseCase<List<Author>, GetAllAuthorsContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<User> Create(CreateUserContract contract)
    {
        return await ExecuteUseCase<User, CreateUserContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<User> Update(UpdateUserContract contract)
    {
        return await ExecuteUseCase<User, UpdateUserContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<UserId> Delete(DeleteUserContract contract)
    {
        return await ExecuteUseCase<UserId, DeleteUserContract>(contract);
    }
}