using System;
using Microsoft.EntityFrameworkCore;
using ScienceArchive.Core.Entities;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Infrastructure.Persistence.Mappers;
using ScienceArchive.Infrastructure.Persistence.Models;

namespace ScienceArchive.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ScienceArchiveDbContext _dbContext;

        public UserRepository(ScienceArchiveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<User> GetById(Guid userId)
        {
            throw new NotImplementedException("GetById method is not implemented!");
        }

        /// <inheritdoc/>
        public async Task<List<User>> GetAll()
        {
            List<UserModel> users;

            try
            {
                users = await _dbContext.Users.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Cannot get users");
            }

            return users.Select(user => UserMapper.MapToDomain(user)).ToList();
        }

        /// <inheritdoc/>
        public async Task<User> Create(User newUser)
        {
            var userToCreate = UserMapper.MapToPersistence(newUser);

            try
            {
                await _dbContext.Users.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // TODO: Create other exception types
                throw new Exception($"Error while inserting new value: {e.ToString()}");
            }

            var createdUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == newUser.Id);

            if (createdUser == null)
            {
                throw new Exception("New user was not inserted!");
            }

            return UserMapper.MapToDomain(createdUser);
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

