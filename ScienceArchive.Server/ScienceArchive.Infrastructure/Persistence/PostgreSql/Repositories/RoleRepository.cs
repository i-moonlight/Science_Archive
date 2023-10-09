using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Exceptions;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

internal class PostgresRoleRepository : IRoleRepository
{
    private readonly IDbConnection _connection;
    private readonly IPersistenceMapper<Role, RoleModel> _roleMapper;
    private readonly IPersistenceMapper<RoleClaim, ClaimModel> _claimMapper;

    public PostgresRoleRepository(
        PostgresContext dbContext, 
        IPersistenceMapper<Role, RoleModel> roleMapper,
        IPersistenceMapper<RoleClaim, ClaimModel> claimMapper)
    {
        var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _claimMapper = claimMapper ?? throw new ArgumentNullException(nameof(claimMapper));
        _roleMapper = roleMapper ?? throw new ArgumentNullException(nameof(roleMapper));
        _connection = context.CreateConnection();
    }

    /// <inheritdoc/>
    public async Task<List<Role>> GetAll()
    {
        var roles = await _connection.QueryAsync<RoleModel>(
            "SELECT * FROM func_get_all_roles()",
            commandType: CommandType.Text);

        if (roles is null)
        {
            throw new EntityNotFoundException<Role[]>("Database returned NULL!");
        }

        return roles.Select(role => _roleMapper.MapToEntity(role)).ToList();
    }

    /// <inheritdoc/>
    public async Task<Role?> GetById(RoleId id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id.Value);

        var role = await _connection.QuerySingleOrDefaultAsync<RoleModel>(
            "SELECT * FROM func_get_role_by_id(@Id)",
            parameters,
            commandType: CommandType.Text);

        if (role is null)
        {
            throw new EntityNotFoundException<Role[]>("Database returned NULL!");
        }

        return _roleMapper.MapToEntity(role);
    }
    
    /// <inheritdoc/>
    public async Task<List<RoleClaim>> GetUserClaims(UserId userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId.Value);

        var claims = await _connection.QueryAsync<ClaimModel>(
            "SELECT * FROM func_get_claims_by_user_id(@UserId)",
            parameters,
            commandType: CommandType.Text);

        if (claims is null)
        {
            throw new EntityNotFoundException<Role[]>("Database returned NULL!");
        }

        return claims.Select(_claimMapper.MapToEntity).ToList();
    }

    /// <inheritdoc/>
    public async Task<Role> Create(Role newValue)
    {
        var roleToCreate = _roleMapper.MapToModel(newValue);
        var parameters = new DynamicParameters(roleToCreate);

        var createdRole = await _connection.QuerySingleOrDefaultAsync<RoleModel>(
            "SELECT * FROM func_create_role(@Id, @Name, @Description, @ClaimsIds)",
            parameters,
            commandType: CommandType.Text);

        if (createdRole is null)
        {
            throw new PersistenceException("Role was not created!");
        }

        return _roleMapper.MapToEntity(createdRole);
    }

    /// <inheritdoc/>
    public async Task<RoleId> Delete(RoleId id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id.Value);

        var deletedRoleId = await _connection.QuerySingleOrDefaultAsync<Guid>(
            "SELECT * FROM func_delete_role(@Id)",
            parameters,
            commandType: CommandType.Text);

        if (deletedRoleId == default)
        {
            throw new PersistenceException("Role was not deleted!");
        }

        return RoleId.CreateFromGuid(deletedRoleId);
    }

    /// <inheritdoc/>
    public async Task<Role> Update(RoleId id, Role newValue)
    {
        var roleToUpdate = _roleMapper.MapToModel(newValue);
        var parameters = new DynamicParameters(roleToUpdate);
        parameters.Add("Id", id.Value);

        var updatedRole = await _connection.QuerySingleOrDefaultAsync<RoleModel>(
            "SELECT * FROM func_update_role(@Id, @Name, @Description, @ClaimsIds)",
            parameters,
            commandType: CommandType.Text);

        if (updatedRole is null)
        {
            throw new PersistenceException("Role was not updated!");
        }

        return _roleMapper.MapToEntity(updatedRole);
    }
}