using CrudAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CrudAPI.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany<Employee>(t => t.Employees) // Team has many Employees
                .WithOne(e => e.Team) // Each Employee belongs to one Team
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.EmployeeId, pe.ProjectId });

            // Configure one-to-many relationship between Employee and ProjectEmployee
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects) // Employee has many ProjectEmployees
                .WithOne(pe => pe.EmployeeData) // ProjectEmployee belongs to one Employee
                .HasForeignKey(pe => pe.EmployeeId) // Foreign key property in ProjectEmployee
                .OnDelete(DeleteBehavior.Cascade); // Cascading delete

            // Configure one-to-many relationship between Project and ProjectEmployee
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees) // Project has many ProjectEmployees
                .WithOne(pe => pe.ProjectData) // ProjectEmployee belongs to one Project
                .HasForeignKey(pe => pe.ProjectId) // Foreign key property in ProjectEmployee
                .OnDelete(DeleteBehavior.Cascade); // Cascading delete

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.PersonalNumber)
                .IsUnique();

            modelBuilder
            .Entity<Employee>()
            .ToTable(b => b.HasCheckConstraint("Birthday Constraint", "BirthDate >= '1900-01-01' AND BirthDate < CAST(GETDATE() AS DATE)"));

            modelBuilder.Entity<Employee>()
            .ToTable(b => b.HasCheckConstraint("CK_SupervisorNotSelf", "SuperviserEmployeeId <> EmployeeId"));
           
        }


    }
}
