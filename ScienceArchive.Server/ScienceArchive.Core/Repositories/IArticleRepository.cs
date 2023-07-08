using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// Article repository functionality
/// </summary>
public interface IArticleRepository : ICrudRepository<Article> { }