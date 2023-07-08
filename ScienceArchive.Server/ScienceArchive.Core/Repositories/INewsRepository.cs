using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// News repository functionality
/// </summary>
public interface INewsRepository : ICrudRepository<News> { }