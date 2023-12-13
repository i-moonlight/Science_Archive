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
	private readonly IPersistenceMapper<Category, SubcategoryModel> _subcategoryMapper;
	
	public PostgresCategoryRepository(
		PostgresContext dbContext, 
		IPersistenceMapper<Category, CategoryModel> mapper,
		IPersistenceMapper<Category, SubcategoryModel> subcategoryMapper)
	{
		var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		_subcategoryMapper = subcategoryMapper ?? throw new ArgumentNullException(nameof(subcategoryMapper));
		_connection = context.CreateConnection();
	}
	
	public async Task<Category?> GetById(CategoryId id)
	{
		var parameters = new DynamicParameters();
		parameters.Add("Id", id.Value);

		var category = await _connection.QueryFirstOrDefaultAsync<CategoryModel?>(
			"SELECT * FROM func_get_category_by_id(:Id)",
			parameters,
			commandType: CommandType.Text);

		return category is null 
			? null 
			: _mapper.MapToEntity(category);
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

	public async Task<Category?> GetSubcategoryById(CategoryId subcategoryId)
	{
		var parameters = new DynamicParameters();
		parameters.Add("Id", subcategoryId.Value);

		var subcategory = await _connection.QueryFirstOrDefaultAsync<SubcategoryModel?>(
			"SELECT * FROM func_get_subcategory_by_id(:Id)",
			parameters,
			commandType: CommandType.Text);

		return subcategory is null 
			? null 
			: _subcategoryMapper.MapToEntity(subcategory);
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