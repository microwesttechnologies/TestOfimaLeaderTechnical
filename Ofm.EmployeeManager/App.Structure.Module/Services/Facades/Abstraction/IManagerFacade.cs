// <copyright file="IManagerFacade.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Facades.Abstraction
{
    using Ofm.EmployeeManager.Entities.Business.Entities.Common;

    /// <summary>
    /// Defines a generic interface for handling CRUD operations in a facade pattern.
    /// </summary>
    /// <typeparam name="T">The type of entity the facade will manage.</typeparam>
    public interface IManagerFacade<T>
        where T : class
    {
        /// <summary>
        /// Retrieves a list of all entities.
        /// </summary>
        /// <returns>A <see cref="GenericResponse{T}"/> containing a list of entities.</returns>
        GenericResponse<List<T>> GetEntities();

        /// <summary>
        /// Retrieves a single entity by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing the entity.</returns>
        GenericResponse<T> GetEntity(int id);

        /// <summary>
        /// Retrieves a filtered list of user entities based on the specified search text.
        /// </summary>
        /// <param name="filter">The search text used to filter the user entities.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing a list of entities.</returns>
        GenericResponse<List<T>> GetEntitiesWithFilter(string filter);

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing the inserted entity.</returns>
        GenericResponse<T> InsertEntity(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing the updated entity.</returns>
        GenericResponse<T> UpdateEntity(T entity);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> indicating the result of the deletion.</returns>
        GenericResponse<T> DeleteEntity(int id);
    }
}
