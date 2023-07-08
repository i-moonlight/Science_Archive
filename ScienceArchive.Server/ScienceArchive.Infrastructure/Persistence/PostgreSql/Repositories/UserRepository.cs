using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Exceptions;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

public class PostgresUserRepository : IUserRepository
{
    private readonly IDbConnection _connection;
    private readonly IPersistenceMapper<User, UserModel> _mapper;

    public PostgresUserRepository(
        PostgresContext dbContext,
        IPersistenceMapper<User, UserModel> mapper)
    {
        var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _connection = context.CreateConnection();
    }

    /// <inheritdoc/>
    public async Task<User> GetById(Guid userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", userId);

        var user = await _connection.QuerySingleOrDefaultAsync<UserModel>(
            "SELECT * FROM func_get_user_by_id(@Id)", 
            parameters, 
            commandType: CommandType.StoredProcedure);

        if (user is null)
        {
            throw new EntityNotFoundException<User>($"User with ID {userId.ToString()} was not found!");
        }

        return _mapper.MapToEntity(user);
    }

    /// <inheritdoc/>
    public async Task<List<User>> GetAll()
    {
        var users = await _connection.QueryAsync<UserModel>(
            "SELECT * FROM func_get_all_users()", 
            commandType: CommandType.Text);

        if (users is null)
        {
            throw new EntityNotFoundException<User[]>("Database returned NULL!");
        }

        return users.Select(user => _mapper.MapToEntity(user)).ToList();
    }

    public async Task<List<User>> GetAllUsersWithPasswords()
    {
        var users = await _connection.QueryAsync<UserModel>(
            "SELECT * FROM func_get_users_with_passwords()", 
            commandType: CommandType.Text);

        if (users is null)
        {
            throw new EntityNotFoundException<User[]>("Database returned NULL!");
        }

        return users.Select(user => _mapper.MapToEntity(user)).ToList();
    }

    /// <inheritdoc/>
    public async Task<User> Create(User newUser)
    {
        var userToCreate = _mapper.MapToModel(newUser);
        var parameters = new DynamicParameters(userToCreate);

        var createdUser = await _connection.QuerySingleOrDefaultAsync<UserModel>(
            "SELECT * FROM func_create_user(@Id, @Name, @Email, @Login, @Password, @PasswordSalt)",
            parameters,
            commandType: CommandType.Text);

        if (createdUser is null)
        {
            throw new PersistenceException("New user was not created!");
        }

        return _mapper.MapToEntity(createdUser);
    }

    /// <inheritdoc/>
    public async Task<User> Update(Guid userId, User newUser)
    {
        var userToUpdate = _mapper.MapToModel(newUser);
        var parameters = new DynamicParameters(userToUpdate);
        parameters.Add("Id", userId);

        var updatedUser = await _connection.QuerySingleOrDefaultAsync<UserModel>(
            "SELECT * FROM func_update_user(@Id, @Name, @Email, @Login, @Password, @PasswordSalt)",
            parameters,
            commandType: CommandType.Text
        );

        if (updatedUser is null)
        {
            throw new PersistenceException("New user was not updated!");
        }

        return _mapper.MapToEntity(updatedUser);
    }

    /// <inheritdoc/>
    public async Task<Guid> Delete(Guid userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", userId);

        var deletedUserId = await _connection.QuerySingleOrDefaultAsync<Guid>(
            "SELECT * FROM func_delete_user(@Id)",
            parameters,
            commandType: CommandType.Text
        );

        if (deletedUserId == default)
        {
            throw new PersistenceException("User was not deleted!");
        }

        return deletedUserId;
    }
}