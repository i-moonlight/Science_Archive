using System;
using Microsoft.EntityFrameworkCore;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Exceptions;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Infrastructure.Persistence.Mappers;
using ScienceArchive.Infrastructure.Persistence.Models;

namespace ScienceArchive.Infrastructure.Persistence.Repositories
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly ScienceArchiveDbContext _dbContext;
        private readonly IMapper<User, UserModel> _mapper;

        public PostgresUserRepository(ScienceArchiveDbContext dbContext, IMapper<User, UserModel> mapper)
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
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<User> GetById(Guid userId)
        {
            var user = await _dbContext.Users.Where(user => user.Id.Equals(userId)).FirstOrDefaultAsync();

            if (user is null)
            {
                throw new EntityNotFoundException<User>($"User with ID {userId.ToString()} was not found!");
            }

            return _mapper.MapToEntity(user);
        }

        /// <inheritdoc/>
        public async Task<List<User>> GetAll()
        {
            var users = await _dbContext.Users.ToListAsync();

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

            await _dbContext.Users.AddAsync(userToCreate);
            await _dbContext.SaveChangesAsync();

            var createdUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == newUser.Id);

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

