using System;
using System.Collections.Generic;
using ITIRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIRazor.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLexpress;Database=MVCCRUDITI;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.DeptId, "IX_Courses_DeptId");

            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses).HasForeignKey(d => d.DeptId);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.Property(e => e.DeptId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasMany(d => d.Users).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleUser",
                    r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                    l => l.HasOne<Role>().WithMany().HasForeignKey("RolesId"),
                    j =>
                    {
                        j.HasKey("RolesId", "UsersId");
                        j.ToTable("RoleUser");
                        j.HasIndex(new[] { "UsersId" }, "IX_RoleUser_UsersId");
                    });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId);

            entity.HasIndex(e => e.DeptId, "IX_Students_deptId");

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Students).HasForeignKey(d => d.DeptId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
