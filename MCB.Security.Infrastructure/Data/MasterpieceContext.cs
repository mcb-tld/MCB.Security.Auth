using MCB.Configuration;
using MCB.Security.Infrastructure.Data.Configuration;
using MCB.Security.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Data
{
    public class MasterpieceContext : DbContext
    {
        public MasterpieceContext() : base() { }
        public MasterpieceContext(DbContextOptions<MasterpieceContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfig.GetConnectionString(5));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AdminUserEntity>(new AdminUserConfiguration());
        }

        public DbSet<AdminUserEntity> SiteUsers { get; set; }
    }
}
