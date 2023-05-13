using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScienceArchive.Infrastructure.Persistence.Models;

namespace ScienceArchive.Infrastructure.Persistence
{
    /// <summary>
    /// Database context
    /// </summary>
    public class ScienceArchiveDbContext : DbContext
    {
        /// <summary>
        /// Users, stored in database
        /// </summary>
        public DbSet<UserModel> Users { get; set; }

        public ScienceArchiveDbContext(DbContextOptions options) : base(options) { }
    }
}

