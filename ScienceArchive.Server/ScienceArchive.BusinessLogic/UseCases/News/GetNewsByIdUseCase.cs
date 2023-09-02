using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases;

public class GetNewsByIdUseCase : IUseCase<News?, GetNewsByIdContract>
{
	private readonly INewsRepository _newsRepository;
	
	public GetNewsByIdUseCase(INewsRepository newsRepository)
	{
		_newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
	}
	
	public async Task<News?> Execute(GetNewsByIdContract contract)
	{
		return await _newsRepository.GetById(contract.Id);
	}
}