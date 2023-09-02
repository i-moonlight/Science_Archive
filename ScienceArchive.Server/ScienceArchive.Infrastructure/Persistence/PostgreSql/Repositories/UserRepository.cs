using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Exceptions;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

public class PostgresUserRepository : IUserRepository
{
    private readonly IDbConnection _connection;
    private readonly IPersistenceMapper<User, UserModel> _userMapper;
    private readonly IPersistenceMapper<Author, AuthorModel> _authorMapper;

    public PostgresUserRepository(
        PostgresContext dbContext,
        IPersistenceMapper<User, UserModel> userMapper,
        IPersistenceMapper<Author, AuthorModel> authorMapper)
    {
        var context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
        _authorMapper = authorMapper ?? throw new ArgumentNullException(nameof(authorMapper));
        _connection = context.CreateConnection();
    }

    /// <inheritdoc/>
    public async Task<User?> GetById(UserId id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id.Value);

        var user = await _connection.QuerySingleOrDefaultAsync<UserModel>(
            "SELECT * FROM func_get_user_by_id(@Id)", 
            parameters, 
            commandType: CommandType.Text);

        return _userMapper.MapToEntity(user);
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

        return users.Select(user => _userMapper.MapToEntity(user)).ToList();
    }

    /// <inheritdoc/>
    public async Task<List<User>> GetAllUsersWithPasswords()
    {
        var users = await _connection.QueryAsync<UserModel>(
            "SELECT * FROM func_get_users_with_passwords()", 
            commandType: CommandType.Text);

        if (users is null)
        {
            throw new EntityNotFoundException<User[]>("Database returned NULL!");
        }

        return users.Select(user => _userMapper.MapToEntity(user)).ToList();
    }

    /// <inheritdoc/>
    public async Task<List<Author>> GetAllAuthors()
    {
        var users = await _connection.QueryAsync<AuthorModel>(
            "SELECT * FROM func_get_all_authors()",
            commandType: CommandType.Text);

        if (users is null)
        {
            throw new EntityNotFoundException<User[]>("Database returned NULL!");
        }

        return users.Select(_authorMapper.MapToEntity).ToList();
    }

    /// <inheritdoc/>
    public async Task<User> Create(User newUser)
    {
        var userToCreate = _userMapper.MapToModel(newUser);
        var parameters = new DynamicParameters(userToCreate);

        var createdUser = await _connection.QuerySingleOrDefaultAsync<UserModel>(
            "SELECT * FROM func_create_user(@Id, @Name, @Email, @Login, @Password, @PasswordSalt, @RolesIds)",
            parameters,
            commandType: CommandType.Text);

        if (createdUser is null)
        {
            throw new PersistenceException("New user was not created!");
        }

        return _userMapper.MapToEntity(createdUser);
    }

    /// <inheritdoc/>
    public async Task<User> Update(UserId id, User newUser)
    {
        var userToUpdate = _userMapper.MapToModel(newUser);
        var parameters = new DynamicParameters(userToUpdate);
        parameters.Add("Id", id.Value);

        var updatedUser = await _connection.QuerySingleOrDefaultAsync<UserModel>(
            "SELECT * FROM func_update_user(@Id, @Name, @Email, @Login, @Password, @PasswordSalt, @RolesIds)",
            parameters,
            commandType: CommandType.Text
        );

        if (updatedUser is null)
        {
            throw new PersistenceException("New user was not updated!");
        }

        return _userMapper.MapToEntity(updatedUser);
    }

    /// <inheritdoc/>
    public async Task<UserId> Delete(UserId id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id.Value);

        var deletedUserId = await _connection.QuerySingleOrDefaultAsync<Guid>(
            "SELECT * FROM func_delete_user(@Id)",
            parameters,
            commandType: CommandType.Text
        );

        if (deletedUserId == default)
        {
            throw new PersistenceException("User was not deleted!");
        }

        return UserId.CreateFromGuid(deletedUserId);
    }
}