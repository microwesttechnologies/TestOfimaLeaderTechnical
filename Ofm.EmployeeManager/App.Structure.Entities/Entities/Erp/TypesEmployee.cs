// <copyright file="TypesEmployee.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Entities.Erp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents an TypesEmployee entity in the system.
    /// </summary>
    public class TypesEmployee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Type Employee.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeEmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the type employee.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string TypeEmployeeName { get; set; }

        /// <summary>
        /// Gets or sets navigation property for employees associated with this position.
        /// </summary>
        public ICollection<Employee> Employee { get; set; } = [];
    }
}
