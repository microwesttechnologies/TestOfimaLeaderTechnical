// <copyright file="Employee.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Entities.Erp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents an employee entity in the system.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string EmployeeFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string EmployeeLastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string EmployeeEmail { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string EmployeeEmailCompany { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal EmployeeSalary { get; set; }

        /// <summary>
        /// Gets or sets the hash of the employee's password.
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the salt used to hash the employee's password.
        /// Optional but recommended for additional security.
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the type of the employee within the organization.
        /// </summary>
        public int TypeEmployeeId { get; set; }

        /// <summary>
        /// Gets or sets navigation property for the types Employee's type.
        /// </summary>
        [ForeignKey("TypeEmployeeId")]
        public TypesEmployee TypesEmployee { get; set; }

        /// <summary>
        /// Gets or sets the employee's photo in Base64 format.
        /// </summary>
        public string PhotoInBase64 { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee record was last modified.
        /// </summary>
        [Required]
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee record was created.
        /// </summary>
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
