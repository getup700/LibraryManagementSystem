using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReverseEngineer;

public partial class UserIdentityContext : DbContext
{
    public UserIdentityContext()
    {
    }

    public UserIdentityContext(DbContextOptions<UserIdentityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TUserAccessFail> TUserAccessFails { get; set; }

    public virtual DbSet<TUserLoginHistory> TUserLoginHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=UserIdentity;User Id=sa;Password=123456;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TUser>(entity =>
        {
            entity.ToTable("T_Users");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasDefaultValue("");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("passwordHash");
            entity.Property(e => e.PhoneNumberNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PhoneNumber_Number");
            entity.Property(e => e.PhoneNumberRegionNumber).HasColumnName("PhoneNumber_RegionNumber");
        });

        modelBuilder.Entity<TUserAccessFail>(entity =>
        {
            entity.ToTable("T_UserAccessFails");

            entity.HasIndex(e => e.UserId, "IX_T_UserAccessFails_UserId").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsLockout).HasColumnName("isLockout");

            entity.HasOne(d => d.User).WithOne(p => p.TUserAccessFail).HasForeignKey<TUserAccessFail>(d => d.UserId);
        });

        modelBuilder.Entity<TUserLoginHistory>(entity =>
        {
            entity.ToTable("T_UserLoginHistories");

            entity.Property(e => e.PhoneNumberNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PhoneNumber_Number");
            entity.Property(e => e.PhoneNumberRegionNumber).HasColumnName("PhoneNumber_RegionNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
