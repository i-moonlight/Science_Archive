using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.BusinessLogic.CategoryUseCases;

public class GetAllCategoriesUseCase : IUseCase<List<Category>, GetAllCategoriesContract>
{
	private readonly ICategoryRepository _categoryRepository;
	
	public GetAllCategoriesUseCase(ICategoryRepository repository)
	{
		_categoryRepository = repository ?? throw new ArgumentNullException(nameof(repository));
	}
	
	public async Task<List<Category>> Execute(GetAllCategoriesContract contract)
	{
		return await _categoryRepository.GetAll();
	}
}