using ScienceArchive.BusinessLogic.Interfaces;

namespace ScienceArchive.BusinessLogic.Services;

/// <summary>
/// Base service functionality
/// </summary>
internal abstract class BaseService
{
    private readonly IServiceProvider _serviceProvider;

    protected BaseService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    /// <summary>
    /// Execute operation (Use Case)
    /// with specified contract
    /// </summary>
    /// <typeparam name="TResult">Response type</typeparam>
    /// <typeparam name="TContract">Request type</typeparam>
    /// <param name="contract">Contract to perform operation</param>
    /// <returns>Use Case execution result</returns>
    /// <exception cref="NullReferenceException">
    /// Thrown if cannot get necessary
    /// use case to process operation
    /// </exception>
    protected async Task<TResult> ExecuteUseCase<TResult, TContract>(TContract contract)
    {
        var useCaseType = typeof(IUseCase<TResult, TContract>);

        if (_serviceProvider.GetService(useCaseType) is not IUseCase<TResult, TContract> useCase)
        {
            throw new NullReferenceException("Cannot get use case for processing the operation!");
        }

        return await useCase.Execute(contract);
    }
}