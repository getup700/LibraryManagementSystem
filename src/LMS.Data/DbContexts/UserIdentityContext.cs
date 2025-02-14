using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models
{
    public partial class UserIdentityContext : DbContext
    {
        public UserIdentityContext()
        {
        }

        public UserIdentityContext(DbContextOptions<UserIdentityContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<UserLoginHistory> TUserLoginHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = Environment.GetEnvironmentVariable("UserIdentity", EnvironmentVariableTarget.User);
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 告诉 EF Core 使用现有表，而不是创建新的表
            modelBuilder.Entity<User>().ToTable("T_User");
        }

    }
}
