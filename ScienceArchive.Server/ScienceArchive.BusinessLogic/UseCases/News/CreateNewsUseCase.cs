﻿using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases;

internal class CreateNewsUseCase : IUseCase<News, CreateNewsContract>
{
    private readonly INewsRepository _newsRepository;

    public CreateNewsUseCase(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
    }

    public async Task<News> Execute(CreateNewsContract contract)
    {
        return await _newsRepository.Create(contract.News);
    }
}