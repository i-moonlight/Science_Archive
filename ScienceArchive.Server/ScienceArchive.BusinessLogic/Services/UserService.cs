using System;
using ScienceArchive.Core.Domain.Entities;
using System.Diagnostics.Contracts;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<List<User>> GetAll(GetAllUsersContract contract)
        {
            return await ExecuteUseCase<List<User>, GetAllUsersContract>(contract);
        }

        public async Task<User> Create(CreateUserContract contract)
        {
            return await ExecuteUseCase<User, CreateUserContract>(contract);
        }

        public async Task<User> Update(UpdateUserContract contract)
        {
            return await ExecuteUseCase<User, UpdateUserContract>(contract);
        }

        public async Task<Guid> Delete(DeleteUserContract contract)
        {
            return await ExecuteUseCase<Guid, DeleteUserContract>(contract);
        }
    }
}

