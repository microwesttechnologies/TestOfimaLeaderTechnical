// <copyright file="GenericError.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Business.Entities.Common
{
    /// <summary>
    /// Represents a generic error structure that encapsulates an error code and message.
    /// </summary>
    public class GenericError
    {
        /// <summary>
        /// Gets a value indicating whether result.
        /// </summary>
        public bool Result => this.Message == string.Empty;

        /// <summary>
        /// Gets or sets the error message providing details about the error.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
