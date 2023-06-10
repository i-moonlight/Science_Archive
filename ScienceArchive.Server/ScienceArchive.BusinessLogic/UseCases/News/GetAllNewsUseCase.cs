using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases
{
    public class GetAllNewsUseCase : IUseCase<List<News>, GetAllNewsContract>
    {
        private readonly INewsRepository _newsRepository;

        public GetAllNewsUseCase(INewsRepository newsRepository)
        {
            if (newsRepository is null)
            {
                throw new ArgumentNullException(nameof(newsRepository));
            }

            _newsRepository = newsRepository;
        }

        public async Task<List<News>> Execute(GetAllNewsContract contract)
        {
            return await _newsRepository.GetAll();
        }
    }
}

