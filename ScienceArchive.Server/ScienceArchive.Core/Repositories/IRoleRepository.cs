using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// Role repository functionality
/// </summary>
public interface IRoleRepository : ICrudRepository<RoleId, Role>
{
	/// <summary>
	/// Get user claims
	/// </summary>
	/// <param name="userId">User ID</param>
	/// <returns>List of user claims</returns>
	Task<List<RoleClaim>> GetUserClaims(UserId userId);
}