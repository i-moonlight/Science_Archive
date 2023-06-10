using System;
using ScienceArchive.BusinessLogic.Interfaces;

namespace ScienceArchive.BusinessLogic.Services
{
    /// <summary>
    /// Base service functionality
    /// </summary>
    public class BaseService
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseService(IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Execute operation (Use Case)
        /// with specified contract DTO
        /// </summary>
        /// <typeparam name="TResult">Response type</typeparam>
        /// <typeparam name="TDto">Request type</typeparam>
        /// <param name="contract">Contract to perform operation</param>
        /// <returns>Use Case execution result</returns>
        /// <exception cref="NullReferenceException">
        /// Thrown if cannot get neccessary
        /// use case to process operation
        /// </exception>
        protected async Task<TResult> ExecuteUseCase<TResult, TDto>(TDto contract)
        {
            var useCaseType = typeof(IUseCase<TResult, TDto>);

            var useCase = _serviceProvider.GetService(useCaseType) as IUseCase<TResult, TDto>;

            if (useCase is null)
            {
                throw new NullReferenceException("Cannot get use case for processing the operation!");
            }

            return await useCase.Execute(contract);
        }
    }
}

