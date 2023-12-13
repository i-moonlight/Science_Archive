using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class CategoryService : BaseService, ICategoryService
{
	public CategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}

	/// <inheritdoc />
	public Task<List<Category>> GetAll(GetAllCategoriesContract contract)
	{
		return ExecuteUseCase<List<Category>, GetAllCategoriesContract>(contract);
	}

	/// <inheritdoc />
	public Task<Category?> GetById(GetCategoryByIdContract contract)
	{
		return ExecuteUseCase<Category?, GetCategoryByIdContract>(contract);
	}

	/// <inheritdoc />
	public Task<Category?> GetSubcategoryById(GetSubcategoryByIdContract contract)
	{
		return ExecuteUseCase<Category?, GetSubcategoryByIdContract>(contract);
	}

	/// <inheritdoc />
	public Task<Category> Create(CreateCategoryContract contract)
	{
		return ExecuteUseCase<Category, CreateCategoryContract>(contract);
	}

	/// <inheritdoc />
	public Task<Category> Update(UpdateCategoryContract contract)
	{
		return ExecuteUseCase<Category, UpdateCategoryContract>(contract);
	}
}