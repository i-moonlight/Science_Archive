using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.CategoryUseCases;

public class UpdateCategoryUseCase : IUseCase<Category, UpdateCategoryContract>
{
	private readonly ICategoryRepository _categoryRepository;
	
	public UpdateCategoryUseCase(ICategoryRepository repository)
	{
		_categoryRepository = repository ?? throw new ArgumentNullException(nameof(repository));
	}
	
	public async Task<Category> Execute(UpdateCategoryContract contract)
	{
		return await _categoryRepository.Update(contract.Id, contract.Category);
	}
}