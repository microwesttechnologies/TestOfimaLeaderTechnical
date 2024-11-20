// <copyright file="EmployeeRepository.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Dal.Dal.Repositories.Implementation
{
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Ofm.EmployeeManager.Dal.Dal.Repositories.Abstraction;

    /// <summary>
    /// Generic repository implementation for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class EmployeeRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The database context used to access the data.
        /// </summary>
        protected readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public EmployeeRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all entities from the repository.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        public List<T> GetAll()
        {
            return this.context.Set<T>().ToList();
        }

        /// <summary>
        /// Gets an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        public T GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        /// <summary>
        /// Finds entities that match the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to match.</param>
        /// <returns>A list of entities that meet the condition.</returns>
        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Add(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">The collection of entities to add.</param>
        public void AddRange(IEnumerable<T> entities)
        {
            this.context.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        /// <summary>
        /// Removes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        public void Remove(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Removes a range of entities from the repository.
        /// </summary>
        /// <param name="entities">The collection of entities to remove.</param>
        public void RemoveRange(List<T> entities)
        {
            this.context.Set<T>().RemoveRange(entities);
        }
    }
}
