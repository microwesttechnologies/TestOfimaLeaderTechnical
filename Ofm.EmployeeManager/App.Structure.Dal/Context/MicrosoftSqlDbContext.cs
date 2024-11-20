// <copyright file="MicrosoftSqlDbContext.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Dal.Context
{
    using Microsoft.EntityFrameworkCore;
    using Ofm.EmployeeManager.Entities.Entities.Erp;

    /// <summary>
    /// The database context for managing employees, types, and logs.
    /// </summary>
    public class MicrosoftSqlDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftSqlDbContext"/> class.
        /// </summary>
        public MicrosoftSqlDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftSqlDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public MicrosoftSqlDbContext(DbContextOptions<MicrosoftSqlDbContext> options)
        : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Employees DbSet.
        /// </summary>
        public DbSet<Employee> Employee { get; set; }

        /// <summary>
        /// Gets or sets the TypesEmployee DbSet.
        /// </summary>
        public DbSet<TypesEmployee> TypesEmployee { get; set; }

        /// <summary>
        /// Gets or sets the LogsEmployee DbSet.
        /// </summary>
        public DbSet<LogsEmployee> LogsEmployee { get; set; }

        /// <summary>
        /// Configures the relationships between the entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder for configuring entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee -> TypesEmployee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.TypesEmployee)
                .WithMany(t => t.Employee)
                .HasForeignKey(e => e.TypeEmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete when a type is referenced

            // LogsEmployee -> Employee
            modelBuilder.Entity<LogsEmployee>()
                .HasOne(l => l.Employee)
                .WithMany() // No need to configure inverse navigation property for LogsEmployee
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Logs will be deleted when the employee is deleted

            // Configure the Log entry's timestamp default value
            modelBuilder.Entity<LogsEmployee>()
                .Property(l => l.Timestamp)
                .HasDefaultValueSql("GETDATE()"); // Default value for timestamp is current date and time

            // Other model configurations (if any)
            base.OnModelCreating(modelBuilder);
        }
    }
}
