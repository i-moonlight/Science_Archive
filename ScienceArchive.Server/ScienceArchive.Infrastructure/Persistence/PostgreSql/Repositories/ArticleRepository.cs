using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Exceptions;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories
{
    public class PostgresArticleRepository : IArticleRepository
    {
        private readonly IDbConnection _connection;
        private readonly IPersistenceMapper<Article, ArticleModel> _mapper;
        
        public PostgresArticleRepository(PostgresContext dbContext, IPersistenceMapper<Article, ArticleModel> mapper)
        {
            var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _connection = context.CreateConnection();
        }

        public async Task<List<Article>> GetAll()
        {
            var articles = await _connection.QueryAsync<ArticleModel>(
                "SELECT * FROM func_get_all_articles()",
                commandType: CommandType.Text);

            if (articles is null)
            {
                throw new EntityNotFoundException<NewsModel>("Cannot get any article");
            }

            return articles.Select(article => _mapper.MapToEntity(article)).ToList();
        }

        public async Task<Article> GetById(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var article = await _connection.QueryFirstOrDefaultAsync<ArticleModel>(
                "SELECT * FROM func_get_article_by_id(@Id)",
                parameters,
                commandType: CommandType.Text);

            if (article is null)
            {
                throw new EntityNotFoundException<ArticleModel>("Cannot find article");
            }

            return _mapper.MapToEntity(article);
        }

        public async Task<Article> Create(Article newValue)
        {
            var articleToCreate = _mapper.MapToModel(newValue);
            var parameters = new DynamicParameters(articleToCreate);

            var createdArticle = await _connection.QueryFirstOrDefaultAsync<ArticleModel>(
                "SELECT * FROM func_create_article(@Id, @Title, @UserId, @CreationDate, @Description, @DocumentPath)",
                parameters,
                commandType: CommandType.Text);

            if (createdArticle is null)
            {
                throw new PersistenceException("New article was not created!");
            }

            return _mapper.MapToEntity(createdArticle);
        }

        public async Task<Guid> Delete(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var deletedArticleId = await _connection.QueryFirstOrDefaultAsync<Guid>(
                "SELECT * FROM func_delete_article(@Id)",
                parameters,
                commandType: CommandType.Text);

            if (deletedArticleId == default)
            {
                throw new PersistenceException("Article was not deleted");
            }
            
            return deletedArticleId;
        }

        public async Task<Article> Update(Guid id, Article newValue)
        {
            var articleToUpdate = _mapper.MapToModel(newValue);
            var parameters = new DynamicParameters(articleToUpdate);
            parameters.Add("Id", id);

            var updatedArticle = await _connection.QueryFirstOrDefaultAsync<ArticleModel>(
                "SELECT * FROM func_update_article(@Id, @Title, @Description, @DocumentPath)",
                parameters,
                commandType: CommandType.Text);

            if (updatedArticle is null)
            {
                throw new PersistenceException("Article was not updated!");
            }

            return _mapper.MapToEntity(updatedArticle);
        }
    }
}

