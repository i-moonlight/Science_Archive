using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public RoleRepository()
        {
        }

        public Task<List<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Create(Role newValue)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Guid id, Role newValue)
        {
            throw new NotImplementedException();
        }
    }
}

