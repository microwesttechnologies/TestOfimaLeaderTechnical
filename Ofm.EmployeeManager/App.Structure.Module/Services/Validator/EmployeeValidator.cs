// <copyright file="EmployeeValidator.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Validator;

using System.Text.RegularExpressions;
using Ofm.EmployeeManager.Entities.Business.Entities.Common;
using Ofm.EmployeeManager.Entities.Business.Entities.Dtos;

/// <summary>
/// Provides validation logic for employee data transfer objects (DTOs).
/// </summary>
public class EmployeeValidator
{
    private static readonly Regex Base64Regex = new(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$", RegexOptions.Compiled);

    /// <summary>
    /// Validates the structure of the provided employee DTO.
    /// </summary>
    /// <param name="employeeDto">The employee DTO to validate.</param>
    /// <returns>A <see cref="GenericResponse{T}"/> indicating whether the structure is valid or not.</returns>
    public GenericResponse<EmployeeDto> ValidateStructure(EmployeeDto employeeDto)
    {
        GenericResponse<EmployeeDto> response = new()
        {
            Exceptions = this.ValidateBase64Format(employeeDto.PhotoInBase64),
        };

        response.Exceptions = response.Exceptions.Where(e => !e.Result).ToList();

        return response;
    }

    /// <summary>
    /// Validates the provided string as a Base64 format.
    /// </summary>
    /// <param name="base64">The string to validate.</param>
    /// <returns>An Exception if the string is not valid Base64; otherwise, null.</returns>
    public List<GenericError> ValidateBase64Format(string base64)
    {
        List<GenericError> errors = [];

        if (string.IsNullOrWhiteSpace(base64))
        {
            errors.Add(new GenericError { Message = "Input cannot be null or empty." });
            return errors;
        }

        if (!Base64Regex.IsMatch(base64) || !this.IsBase64String(base64))
        {
            errors.Add(new GenericError { Message = "Input is not in a valid Base64 format." });
        }

        return errors;
    }

    /// <summary>
    /// Validates whether the provided string is in a valid Base64 format.
    /// </summary>
    /// <param name="base64">The string to validate as Base64.</param>
    /// <returns>if the string is a valid Base64 encoded value.</returns>
    private bool IsBase64String(string base64)
    {
        try
        {
            Convert.FromBase64String(base64);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
