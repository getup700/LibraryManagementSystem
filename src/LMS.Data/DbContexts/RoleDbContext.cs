using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.DbContexts
{
    public class RoleDbContext:DbContext
    {
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = Environment.GetEnvironmentVariable("LibraryManagementDB", EnvironmentVariableTarget.User);
            var ss = "Server=.;Database=LibraryManagement;User Id=sa;Password=123456;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(ss);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

