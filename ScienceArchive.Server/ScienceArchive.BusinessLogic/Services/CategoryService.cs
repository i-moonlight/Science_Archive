using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class CategoryService : BaseService, ICategoryService
{
	public CategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}

	public async Task<List<Category>> GetAll(GetAllCategoriesContract contract)
	{
		return await ExecuteUseCase<List<Category>, GetAllCategoriesContract>(contract);
	}

	public async Task<Category> Create(CreateCategoryContract contract)
	{
		return await ExecuteUseCase<Category, CreateCategoryContract>(contract);
	}

	public async Task<Category> Update(UpdateCategoryContract contract)
	{
		return await ExecuteUseCase<Category, UpdateCategoryContract>(contract);
	}
}