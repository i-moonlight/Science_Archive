using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public NewsRepository()
        {
        }

        public Task<List<News>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<News> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<News> Create(News newValue)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<News> Update(Guid id, News newValue)
        {
            throw new NotImplementedException();
        }
    }
}

