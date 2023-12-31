﻿using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases;

internal class UpdateNewsUseCase : IUseCase<News, UpdateNewsContract>
{
    private readonly INewsRepository _newsRepository;

    public UpdateNewsUseCase(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
    }

    public async Task<News> Execute(UpdateNewsContract contract)
    {
        return await _newsRepository.Update(contract.Id, contract.News);
    }
}