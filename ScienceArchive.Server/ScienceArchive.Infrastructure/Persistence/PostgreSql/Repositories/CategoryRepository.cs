using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Repositories;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

public class PostgresCategoryRepository : ICategoryRepository
{
	public Task<Category?> GetById(CategoryId id)
	{
		throw new NotImplementedException();
	}

	public Task<List<Category>> GetAll()
	{
		throw new NotImplementedException();
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
}