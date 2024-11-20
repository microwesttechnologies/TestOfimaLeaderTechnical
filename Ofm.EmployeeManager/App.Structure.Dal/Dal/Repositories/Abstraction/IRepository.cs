// <copyright file="IRepository.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Dal.Dal.Repositories.Abstraction
{
    using System.Linq.Expressions;

    /// <summary>
    /// Generic repository interface for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        T GetById(int id);

        /// <summary>
        /// Gets all entities from the repository.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        List<T> GetAll();

        /// <summary>
        /// Finds entities that match the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to match.</param>
        /// <returns>A list of entities that meet the condition.</returns>
        List<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">The collection of entities to add.</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Removes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Removes a range of entities from the repository.
        /// </summary>
        /// <param name="entities">The collection of entities to remove.</param>
        void RemoveRange(List<T> entities);
    }
}
