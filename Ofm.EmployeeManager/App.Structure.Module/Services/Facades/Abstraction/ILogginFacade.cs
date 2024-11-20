// <copyright file="ILogginFacade.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Facades.Abstraction
{
    using Ofm.EmployeeManager.Entities.Business.Entities.Request;

    /// <summary>
    /// 
    /// </summary>
    internal interface ILogginFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        bool ValidateEmployee(LoginRequest loginRequest);
    }
}
