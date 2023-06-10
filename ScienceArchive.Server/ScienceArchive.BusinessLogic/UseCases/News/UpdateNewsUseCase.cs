using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases
{
    public class UpdateNewsUseCase : IUseCase<News, UpdateNewsContract>
    {
        private readonly INewsRepository _newsRepository;

        public UpdateNewsUseCase(INewsRepository newsRepository)
        {
            if (newsRepository is null)
            {
                throw new ArgumentNullException(nameof(newsRepository));
            }

            _newsRepository = newsRepository;
        }

        public async Task<News> Execute(UpdateNewsContract contract)
        {
            return await _newsRepository.Update(contract.Id, contract.News);
        }
    }
}

