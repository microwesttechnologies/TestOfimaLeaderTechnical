// <copyright file="EmployeeDto.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Business.Entities.Dtos
{
    using System;

    /// <summary>
    /// DTO for creating or updating an employee.
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// Gets or sets the ID of the employee.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string EmployeeFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string EmployeeLastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string EmployeeEmail { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee for company use.
        /// </summary>
        public string EmployeeEmailCompany { get; set; }

        /// <summary>
        /// Gets or sets the password to hash for the employee.
        /// </summary>
        public string EmployeePassword { get; set; }

        /// <summary>
        /// Gets or sets salary.
        /// </summary>
        public decimal EmployeeSalary { get; set; }

        /// <summary>
        /// Gets or sets the type of employee (e.g., manager, developer, etc.).
        /// </summary>
        public int TypeEmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the base64 encoded photo of the employee.
        /// </summary>
        public string PhotoInBase64 { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee record was last modified.
        /// </summary>
        public DateTime LastModifiedDate => default;
    }
}
