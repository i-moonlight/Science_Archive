using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Exceptions;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

internal class PostgresCategoryRepository : ICategoryRepository
{
	private readonly IDbConnection _connection;
	private readonly IPersistenceMapper<Category, CategoryModel> _mapper;
	
	public PostgresCategoryRepository(PostgresContext dbContext, IPersistenceMapper<Category, CategoryModel> mapper)
	{
		var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		_connection = context.CreateConnection();
	}
	
	public Task<Category?> GetById(CategoryId id)
	{
		throw new NotImplementedException();
	}

	public async Task<List<Category>> GetAll()
	{
		var categories = await _connection.QueryAsync<CategoryModel>(
			"SELECT * FROM func_get_all_categories()",
			commandType: CommandType.Text);

		if (categories is null)
		{
			throw new EntityNotFoundException<CategoryModel>("Cannot get any category");
		}

		return categories.Select(c => _mapper.MapToEntity(c)).ToList();
	}

	public Task<Category> Create(Category newValue)
	{
		throw new NotImplementedException();
	}

	public Task<Category> Update(CategoryId id, Category newValue)
	{
		throw new NotImplementedException();
	}

	public Task<CategoryId> Delete(CategoryId id)
	{
		throw new NotImplementedException();
	}

	public Task<Category> CreateSubcategory(CategoryId categoryId, Category subcategory)
	{
		throw new NotImplementedException();
	}

	public Task<Category> UpdateSubcategory(CategoryId subcategoryId, Category subcategory)
	{
		throw new NotImplementedException();
	}

	public Task<CategoryId> DeleteSubcategory(CategoryId subcategoryId)
	{
		throw new NotImplementedException();
	}
}