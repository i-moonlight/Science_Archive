using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<List<Role>> GetAll(GetAllRolesContract contract)
        {
            return await ExecuteUseCase<List<Role>, GetAllRolesContract>(contract);
        }

        /// <inheritdoc/>
        public async Task<Role> Create(CreateRoleContract contract)
        {
            return await ExecuteUseCase<Role, CreateRoleContract>(contract);
        }

        /// <inheritdoc/>
        public async Task<Role> Update(UpdateRoleContract contract)
        {
            return await ExecuteUseCase<Role, UpdateRoleContract>(contract);
        }

        /// <inheritdoc/>
        public async Task<Guid> Delete(DeleteRoleContract contract)
        {
            return await ExecuteUseCase<Guid, DeleteRoleContract>(contract);
        }
    }
}

