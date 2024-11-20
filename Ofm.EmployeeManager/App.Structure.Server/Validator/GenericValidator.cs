// <copyright file="GenericValidator.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Validator
{
    using Ofm.EmployeeManager.Entities.Business.Entities.Common;
    using Ofm.EmployeeManager.Entities.Business.Entities.Dtos;

    /// <summary>
    /// Validates generic classes.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class GenericValidator<T>
        where T : class
    {
        /// <summary>
        /// Validates the provided entity.
        /// </summary>
        /// <param name="entity">The entity to validate.</param>
        /// <returns>A response containing validation results and exceptions.</returns>
        public GenericResponse<T> ValidateEntity(T entity)
        {
            GenericResponse<T> response = new()
            {
                Object = entity,
                Exceptions = new List<GenericError>
                {
                    this.ValidateAllowedClasses(entity),
                    this.ValidateNotEmpty(entity),
                },
            };

            response.Exceptions = response.Exceptions.Where(e => !e.Result).ToList();

            return response;
        }

        /// <summary>
        /// Validates the allowed classes.
        /// </summary>
        /// <param name="entity">The entity to validate.</param>
        /// <returns>Generic error if validation fails.</returns>
        private GenericError ValidateAllowedClasses(T entity)
        {
            return entity.GetType() != typeof(EmployeeDto)
                ? new GenericError { Message = $"The entity must be of type {nameof(EmployeeDto)}." }
                : new GenericError();
        }

        /// <summary>
        /// Validate this class Not Empty.
        /// </summary>
        /// <param name="entity">The entity to validate.</param>
        /// <returns>Generic error if validation fails.</returns>
        private GenericError ValidateNotEmpty(T entity)
        {
            return entity == null
                ? new GenericError { Message = "The entity cannot be null." }
                : new GenericError();
        }
    }
}
