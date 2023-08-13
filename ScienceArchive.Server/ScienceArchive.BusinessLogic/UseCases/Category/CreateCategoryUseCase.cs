using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.CategoryUseCases;

public class CreateCategoryUseCase : IUseCase<Category, CreateCategoryContract>
{
	private readonly ICategoryRepository _categoryRepository;
	
	public CreateCategoryUseCase(ICategoryRepository repository)
	{
		_categoryRepository = repository ?? throw new ArgumentNullException(nameof(repository));
	}
	
	public async Task<Category> Execute(CreateCategoryContract contract)
	{
		return await _categoryRepository.Create(contract.Category);
	}
}