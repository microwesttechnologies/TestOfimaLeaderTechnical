// <copyright file="EmployeeUnitWork.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Dal.Dal.UnitWorks.Implementation
{
    using Ofm.EmployeeManager.Dal.Context;
    using Ofm.EmployeeManager.Dal.Dal.Repositories.Abstraction;
    using Ofm.EmployeeManager.Dal.Dal.Repositories.Implementation;
    using Ofm.EmployeeManager.Dal.Dal.UnitWorks.Abstraction;
    using Ofm.EmployeeManager.Entities.Entities.Erp;

    /// <summary>
    /// Implementation of the unit of work pattern for managing employees and notifications in the database.
    /// </summary>
    public class EmployeeUnitWork : IUnitWork
    {
        private readonly MicrosoftSqlDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeUnitWork"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context to be used for repository operations.</param>
        public EmployeeUnitWork(MicrosoftSqlDbContext context)
        {
            this.context = context;
            this.Employee = new EmployeeRepository<Employee>(this.context);
            this.TypesEmployee = new EmployeeRepository<TypesEmployee>(this.context);
            this.LogsEmployee = new EmployeeRepository<LogsEmployee>(this.context);
        }

        /// <summary>
        /// Gets the repository for managing employee entities.
        /// </summary>
        public IRepository<Employee> Employee { get; private set; }

        /// <summary>
        /// Gets the repository for managing notification entities.
        /// </summary>
        public IRepository<TypesEmployee> TypesEmployee { get; private set; }

        /// <summary>
        /// Gets the repository for managing notification entities.
        /// </summary>
        public IRepository<LogsEmployee> LogsEmployee { get; private set; }

        /// <summary>
        /// Saves all changes made in this unit of work to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public int Complete()
        {
            return this.context.SaveChanges();
        }

        /// <summary>
        /// Disposes of the database context.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}