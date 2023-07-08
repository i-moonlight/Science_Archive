using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Exceptions;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

public class PostgresRoleRepository : IRoleRepository
{
    private readonly IDbConnection _connection;
    private readonly IPersistenceMapper<Role, RoleModel> _mapper;

    public PostgresRoleRepository(PostgresContext dbContext, IPersistenceMapper<Role, RoleModel> mapper)
    {
        var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        return roles.Select(role => _mapper.MapToEntity(role)).ToList();
    }

    /// <inheritdoc/>
    public async Task<Role> GetById(Guid id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);

        var role = await _connection.QuerySingleOrDefaultAsync<RoleModel>(
            "SELECT * FROM func_get_role_by_id(@Id)",
            parameters,
            commandType: CommandType.Text);

        if (role is null)
        {
            throw new EntityNotFoundException<Role[]>("Database returned NULL!");
        }

        return _mapper.MapToEntity(role);
    }

    /// <inheritdoc/>
    public async Task<Role> Create(Role newValue)
    {
        var roleToCreate = _mapper.MapToModel(newValue);
        var parameters = new DynamicParameters(roleToCreate);

        var createdRole = await _connection.QuerySingleOrDefaultAsync<RoleModel>(
            "SELECT * FROM func_create_role(@Id, @Name, @Description, @Claims)",
            parameters,
            commandType: CommandType.Text);

        if (createdRole is null)
        {
            throw new PersistenceException("Role was not created!");
        }

        return _mapper.MapToEntity(createdRole);
    }

    /// <inheritdoc/>
    public async Task<Guid> Delete(Guid id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);

        var deletedRoleId = await _connection.QuerySingleOrDefaultAsync<Guid>(
            "SELECT * FROM func_delete_role(@Id)",
            parameters,
            commandType: CommandType.Text);

        if (deletedRoleId == default)
        {
            throw new PersistenceException("Role was not deleted!");
        }

        return deletedRoleId;
    }
        
    /// <inheritdoc/>
    public async Task<Role> Update(Guid id, Role newValue)
    {
        var roleToUpdate = _mapper.MapToModel(newValue);
        var parameters = new DynamicParameters(roleToUpdate);
        parameters.Add("Id", id);

        var updatedRole = await _connection.QuerySingleOrDefaultAsync<RoleModel>(
            "SELECT * FROM func_update_role(@Id, @Name, @Description, @Claims)",
            parameters,
            commandType: CommandType.Text);

        if (updatedRole is null)
        {
            throw new PersistenceException("Role was not updated!");
        }

        return _mapper.MapToEntity(updatedRole);
    }
}