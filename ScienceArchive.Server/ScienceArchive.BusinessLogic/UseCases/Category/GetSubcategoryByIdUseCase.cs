using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.CategoryUseCases;

public class GetSubcategoryByIdUseCase : IUseCase<Category?, GetSubcategoryByIdContract>
{
	private readonly ICategoryRepository _categoryRepository;
	
	public GetSubcategoryByIdUseCase(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
	}


	public Task<Category?> Execute(GetSubcategoryByIdContract contract)
	{
		return _categoryRepository.GetSubcategoryById(contract.SubcategoryId);
	}
}