// <copyright file="EmployeeService.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Services
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using AutoMapper;
    using Ofm.EmployeeManager.Dal.Dal.UnitWorks.Abstraction;
    using Ofm.EmployeeManager.Entities.Business.Entities.Common;
    using Ofm.EmployeeManager.Entities.Business.Entities.Dtos;
    using Ofm.EmployeeManager.Entities.Entities.Erp;
    using Ofm.EmployeeManager.Module.Services.Validator;

    /// <summary>
    /// Provides services for employee-related operations, including CRUD operations and notifications.
    /// </summary>
    public class EmployeeService
    {
        private readonly IUnitWork unitWork;
        private readonly IMapper mapper;
        private readonly PasswordService passwordService;
        private readonly EmployeeValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="unitWork">The unit of work for data access.</param>
        /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
        public EmployeeService(IUnitWork unitWork, IMapper mapper)
        {
            this.unitWork = unitWork;
            this.mapper = mapper;
            this.passwordService = new PasswordService();
            this.validator = new EmployeeValidator();
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>A generic response with list of employee DTOs.</returns>
        public GenericResponse<List<EmployeeDto>> GetAllEmployees()
        {
            List<Employee> employees = this.unitWork.Employee.GetAll();
            List<EmployeeDto> employeeDtos = this.mapper.Map<List<EmployeeDto>>(employees);
            GenericResponse<List<EmployeeDto>> response = new() { Object = employeeDtos, };

            return response;
        }

        /// <summary>
        /// Retrieves a specific employee by ID.
        /// </summary>
        /// <param name="employeesId">The ID of the employee.</param>
        /// <returns>An employee DTO corresponding to the employee.</returns>
        public GenericResponse<EmployeeDto> GetEmployeeById(int employeesId)
        {
            Employee employee = this.unitWork.Employee.GetById(employeesId);
            EmployeeDto employeeDto = this.mapper.Map<EmployeeDto>(employee);
            GenericResponse<EmployeeDto> response = new() { Object = employeeDto, };

            return response;
        }

        /// <summary>
        /// Get list of employees using filter parameter.
        /// </summary>
        /// <param name="text">Filter.</param>
        /// <returns>List EmployeeDtos.</returns>
        public List<EmployeeDto> GetEmployeesWithFilter(string text)
        {
            return [];
        }

        /// <summary>
        /// Adds a new employee and creates a notification for the employee.
        /// </summary>
        /// <param name="employeeDto">The employee data transfer object.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> indicating success or failure.</returns>
        public GenericResponse<EmployeeDto> AddEmployee(EmployeeDto employeeDto)
        {
            GenericResponse<EmployeeDto> response = this.validator.ValidateStructure(employeeDto);

            if (response.Status)
            {
                Employee employee = this.mapper.Map<Employee>(employeeDto);
                var (passwordHash, passwordSalt) = this.passwordService.HashPassword(employeeDto.EmployeePassword);

                employee.CreationDate = DateTime.Now;
                employee.LastModifiedDate = DateTime.Now;
                employee.PasswordHash = passwordHash;
                employee.PasswordSalt = passwordSalt;

                this.unitWork.Employee.Add(employee);
                this.unitWork.Complete();
            }

            response.Object = employeeDto;
            return response;
        }

        /// <summary>
        /// Updates an existing employee's information and creates a new notification.
        /// </summary>
        /// <param name="employeeDto">The employee DTO with updated information.</param>
        /// <returns>A <see cref="GenericResponse{T}"/> indicating success or failure.</returns>
        public GenericResponse<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {
            GenericResponse<EmployeeDto> response = this.validator.ValidateStructure(employeeDto);

            if (response.Status)
            {
                Employee employee = this.unitWork.Employee.GetById(employeeDto.EmployeeId);

                this.mapper.Map(employeeDto, employee);
                employee.LastModifiedDate = DateTime.Now;

                this.unitWork.Employee.Update(employee);
                this.unitWork.Complete();
            }

            response.Object = employeeDto;

            return response;
        }

        /// <summary>
        /// Removes an employee by ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to be removed.</param>
        /// <returns>An employee DTO corresponding to the removed employee.</returns>
        public GenericResponse<EmployeeDto> RemoveEmployee(int employeeId)
        {
            Employee employee = this.unitWork.Employee.GetById(employeeId) ?? new();

            if (employee != null)
            {
                Expression<Func<LogsEmployee, bool>> predicate = log => log.EmployeeId == employeeId;

                List<LogsEmployee> logs = this.unitWork.LogsEmployee.Find(predicate);

                this.unitWork.LogsEmployee.RemoveRange(logs);
                this.unitWork.Employee.Remove(employee);
                this.unitWork.Complete();
            }

            return new GenericResponse<EmployeeDto>() { Object = this.mapper.Map<EmployeeDto>(employee) };
        }
    }
}
