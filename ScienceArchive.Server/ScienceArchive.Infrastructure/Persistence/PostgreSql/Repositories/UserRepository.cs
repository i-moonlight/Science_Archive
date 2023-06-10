using System;
using System.Data;
using Dapper;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Exceptions;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.Mappers;
using ScienceArchive.Infrastructure.Persistence.Models;
using ScienceArchive.Infrastructure.Persistence.Options;
using ScienceArchive.Infrastructure.Persistence.PostgreSql;

namespace ScienceArchive.Infrastructure.Persistence.Repositories
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly PostgresContext _dbContext;
        private readonly IDbConnection _connection;
        private readonly IPersistenceMapper<User, UserModel> _mapper;

        public PostgresUserRepository(
            PostgresContext dbContext,
            IPersistenceMapper<User, UserModel> mapper)
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _dbContext = dbContext;
            _connection = dbContext.CreateConnection();
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<User> GetById(Guid userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("user_id", userId);

            var user = await _connection.QuerySingleOrDefaultAsync<UserModel>("SELECT * FROM get_user_by_id(@Id)", parameters, commandType: CommandType.StoredProcedure);

            if (user is null)
            {
                throw new EntityNotFoundException<User>($"User with ID {userId.ToString()} was not found!");
            }

            return _mapper.MapToEntity(user);
        }

        /// <inheritdoc/>
        public async Task<List<User>> GetAll()
        {
            var users = await _connection.QueryAsync<UserModel>("SELECT * FROM get_users()", commandType: CommandType.Text);

            if (users is null)
            {
                throw new EntityNotFoundException<User[]>("Database returned NULL!");
            }

            return users.Select(user => _mapper.MapToEntity(user)).ToList();
        }

        public async Task<List<User>> GetAllUsersWithPasswords()
        {
            var users = await _connection.QueryAsync<UserModel>("SELECT * FROM get_users_with_passwords()", commandType: CommandType.Text);

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
                    "SELECT * FROM create_user(@Id, @Name, @Email, @Login, @Password, @PasswordSalt)",
                    parameters,
                    commandType: CommandType.Text);

            if (createdUser == null)
            {
                throw new PersistenceException("New user was not created!");
            }

            return _mapper.MapToEntity(createdUser);
        }

        /// <inheritdoc/>
        public async Task<User> Update(Guid userId, User newUser)
        {
            throw new NotImplementedException("Update method is not implemented!");
        }

        /// <inheritdoc/>
        public async Task<Guid> Delete(Guid userId)
        {
            throw new NotImplementedException("Delete method is not implemented!");
        }
    }
}

