using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Repositories;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public ArticleRepository()
        {
        }

        public Task<List<Article>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> Create(Article newValue)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> Update(Guid id, Article newValue)
        {
            throw new NotImplementedException();
        }
    }
}

