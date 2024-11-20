// <copyright file="LogsEmployee.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Entities.Erp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a log entry for an employee's activity or access record.
    /// </summary>
    public class LogsEmployee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the log entry.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated employee.
        /// </summary>
        [Required]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the log entry was recorded.
        /// </summary>
        [Required]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the description of the log entry.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the associated employee.
        /// </summary>
        public Employee Employee { get; set; }
    }
}
