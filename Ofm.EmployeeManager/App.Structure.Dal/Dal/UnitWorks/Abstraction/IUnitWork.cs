// <copyright file="IUnitWork.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Dal.Dal.UnitWorks.Abstraction
{
    using Ofm.EmployeeManager.Dal.Dal.Repositories.Abstraction;
    using Ofm.EmployeeManager.Entities.Entities.Erp;

    /// <summary>
    /// Interface for managing unit of work pattern, coordinating repositories and ensuring data is saved.
    /// </summary>
    public interface IUnitWork : IDisposable
    {
        /// <summary>
        /// Gets the repository for managing employee entities.
        /// </summary>
        IRepository<Employee> Employee { get; }

        /// <summary>
        /// Gets the repository for managing TypeUser entities.
        /// </summary>
        IRepository<TypesEmployee> TypesEmployee { get; }

        /// <summary>
        /// Gets the repository for managing LogsEmployee entities.
        /// </summary>
        IRepository<LogsEmployee> LogsEmployee { get; }

        /// <summary>
        /// Saves all changes made in the unit of work to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        int Complete();
    }
}
