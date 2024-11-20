// <copyright file="EmployeeFacade.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Facades.Implementation
{
    using Ofm.EmployeeManager.Entities.Business.Entities.Common;
    using Ofm.EmployeeManager.Entities.Business.Entities.Dtos;
    using Ofm.EmployeeManager.Module.Services.Facades.Abstraction;
    using Ofm.EmployeeManager.Module.Services.Services;

    /// <summary>
    /// Provides a facade layer for handling user-related operations through the <see cref="EmployeeService"/>.
    /// Implements the <see cref="IManagerFacade{T}"/> interface for user DTOs.
    /// </summary>
    public class EmployeeFacade : IManagerFacade<EmployeeDto>
    {
        private readonly EmployeeService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeFacade"/> class.
        /// </summary>
        /// <param name="service">The service layer responsible for user operations.</param>
        public EmployeeFacade(EmployeeService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieves all user records.
        /// </summary>
        /// <returns>A <see cref="GenericResponse{T}"/> containing a list of user DTOs.</returns>
        public GenericResponse<List<EmployeeDto>> GetEntities()
        {
            return this.service.GetAllEmployees();
        }

        /// <summary>
        /// Retrieves a specific user by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing the user DTO.</returns>
        public GenericResponse<EmployeeDto> GetEntity(int id)
        {
            return this.service.GetEmployeeById(id);
        }

        /// <summary>
        /// Retrieves a filtered list of user entities based on the specified search text.
        /// </summary>
        /// <param name="filter">The search text used to filter the user entities.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing a collection of filtered <see cref="EmployeeDto"/> objects.</returns>
        public GenericResponse<List<EmployeeDto>> GetEntitiesWithFilter(string filter)
        {
            GenericResponse<List<EmployeeDto>> response = new() { Exceptions = [new() { Message = "This method is not implemented.", },], };

            return response;
        }

        /// <summary>
        /// Inserts a new user record.
        /// </summary>
        /// <param name="entity">The user DTO to be inserted.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing the inserted user DTO.</returns>
        public GenericResponse<EmployeeDto> InsertEntity(EmployeeDto entity)
        {
            return this.service.AddEmployee(entity);
        }

        /// <summary>
        /// Updates an existing user record.
        /// </summary>
        /// <param name="entity">The user DTO with updated values.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> containing the updated user DTO.</returns>
        public GenericResponse<EmployeeDto> UpdateEntity(EmployeeDto entity)
        {
            return this.service.UpdateEmployee(entity);
        }

        /// <summary>
        /// Deletes an user by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user to be deleted.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> indicating the result of the deletion.</returns>
        public GenericResponse<EmployeeDto> DeleteEntity(int id)
        {
            return this.service.RemoveEmployee(id);
        }
    }
}
