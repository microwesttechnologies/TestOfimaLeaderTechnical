// <copyright file="GenericResponse.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Business.Entities.Common
{
    /// <summary>
    /// Represents a generic response structure that encapsulates a result object and any errors that may have occurred.
    /// </summary>
    /// <typeparam name="T">The type of the response object.</typeparam>
    public class GenericResponse<T>
    {
        /// <summary>
        /// Gets or sets the result object of the response.
        /// </summary>
        public T Object { get; set; }

        /// <summary>
        /// Gets a value indicating whether indicates whether the response has any exceptions.
        /// </summary>
        public bool Status => Exceptions == null || !Exceptions.Any();

        /// <summary>
        /// Gets or sets a list of errors that occurred during the operation, if any.
        /// </summary>
        public List<GenericError> Exceptions { get; set; } = [];
    }
}
