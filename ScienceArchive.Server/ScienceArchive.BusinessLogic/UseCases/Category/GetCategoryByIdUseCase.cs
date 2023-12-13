using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.CategoryUseCases;

public class GetCategoryByIdUseCase : IUseCase<Category?, GetCategoryByIdContract>
{
	private readonly ICategoryRepository _categoryRepository;
	
	public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
	}
	
	public Task<Category?> Execute(GetCategoryByIdContract contract)
	{
		return _categoryRepository.GetById(contract.Id);
	}
}