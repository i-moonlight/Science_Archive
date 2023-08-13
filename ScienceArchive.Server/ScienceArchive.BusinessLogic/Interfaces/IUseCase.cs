namespace ScienceArchive.BusinessLogic.Interfaces;

/// <summary>
/// Strategy of operation execution
/// </summary>
/// <typeparam name="TResult">Result type</typeparam>
/// <typeparam name="TContract">Operation contract type</typeparam>
internal interface IUseCase<TResult, in TContract>
{
    /// <summary>
    /// Execute operation
    /// </summary>
    /// <param name="contract">Contract to execute operation</param>
    /// <returns>Operation result</returns>
    Task<TResult> Execute(TContract contract);
}