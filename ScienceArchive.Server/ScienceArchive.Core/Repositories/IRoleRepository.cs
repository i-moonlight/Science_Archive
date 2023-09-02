using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// Role repository functionality
/// </summary>
public interface IRoleRepository : ICrudRepository<RoleId, Role> { }