namespace ScienceArchive.BusinessLogic.Interfaces;

/// <summary>
/// Strategy of operation execution
/// </summary>
/// <typeparam name="TResult">Result type</typeparam>
/// <typeparam name="TContract">DTO contract type</typeparam>
public interface IUseCase<TResult, TContract>
{
    /// <summary>
    /// Execute operation
    /// </summary>
    /// <param name="dto">DTO contract</param>
    /// <returns>Operation result</returns>
    Task<TResult> Execute(TContract dto);
}