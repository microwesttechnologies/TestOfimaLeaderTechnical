// <copyright file="EmployeeController.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ofm.EmployeeManager.Entities.Business.Entities.Common;
    using Ofm.EmployeeManager.Entities.Business.Entities.Dtos;
    using Ofm.EmployeeManager.Module.Services.Facades.Implementation;
    using Ofm.EmployeeManager.Server.Validator;

    /// <summary>
    /// Controller that handles CRUD operations related to employees.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeFacade facade;
        private readonly GenericValidator<EmployeeDto> validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="facade">Facade that handles employee operations.</param>
        public EmployeeController(EmployeeFacade facade)
        {
            this.facade = facade;
            this.validator = new GenericValidator<EmployeeDto>();
        }

        /// <summary>
        /// Retrieves a list of employees.
        /// </summary>
        /// <returns>Generic response containing a list of employee DTOs.</returns>
        [HttpGet("GetEmployees")]
        public GenericResponse<List<EmployeeDto>> GetEmployees()
        {
            return this.facade.GetEntities();
        }

        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>Generic response containing the employee DTO.</returns>
        [HttpGet("GetGetEmployeeById/{id}")]
        public GenericResponse<EmployeeDto> GetGetEmployeeById(int id)
        {
            return this.facade.GetEntity(id);
        }

        /// <summary>
        /// Inserts a new employee.
        /// </summary>
        /// <param name="entity">The employee DTO to insert.</param>
        /// <returns>Generic response containing the inserted employee DTO.</returns>
        [HttpPost("InsertEmployee")]
        public GenericResponse<EmployeeDto> InsertEmployee([FromBody] EmployeeDto entity)
        {
            var response = this.validator.ValidateEntity(entity);

            if (response.Status)
            {
                return this.facade.InsertEntity(entity);
            }

            return response;
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="entity">The employee DTO with updated information.</param>
        /// <returns>Generic response containing the updated employee DTO.</returns>
        [HttpPut("UpdateEmployee")]
        public GenericResponse<EmployeeDto> UpdateEmployee([FromBody] EmployeeDto entity)
        {
            var response = this.validator.ValidateEntity(entity);

            if (response.Status)
            {
                return this.facade.UpdateEntity(entity);
            }

            return response;
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>Generic response indicating the deletion status.</returns>
        [HttpDelete("DeleteEmployee/{id}")]
        public GenericResponse<EmployeeDto> DeleteEmployee(int id)
        {
            return this.facade.DeleteEntity(id);
        }
    }
}
