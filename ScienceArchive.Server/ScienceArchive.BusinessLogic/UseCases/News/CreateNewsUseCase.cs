using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases
{
    public class CreateNewsUseCase : IUseCase<News, CreateNewsContract>
    {
        private readonly INewsRepository _newsRepository;

        public CreateNewsUseCase(INewsRepository newsRepository)
        {
            if (newsRepository is null)
            {
                throw new ArgumentNullException(nameof(newsRepository));
            }

            _newsRepository = newsRepository;
        }

        public async Task<News> Execute(CreateNewsContract contract)
        {
            return await _newsRepository.Create(contract.News);
        }
    }
}

