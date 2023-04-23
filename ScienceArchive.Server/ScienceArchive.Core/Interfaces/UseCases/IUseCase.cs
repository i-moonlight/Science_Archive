using System;
namespace ScienceArchive.Core.Interfaces.UseCases
{
    /// <summary>
    /// Represent a unit of business logic.
    /// It includes method to execute one operation
    /// </summary>
    /// <typeparam name="T">Return type of Execute method</typeparam>
    /// <typeparam name="R">Type of the DTO contract to execute operation</typeparam>
    public interface IUseCase<T, R>
        where T : class
        where R : class
    {
        /// <summary>
        /// Execute needed operation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<T> Execute(R dto);
    }
}

