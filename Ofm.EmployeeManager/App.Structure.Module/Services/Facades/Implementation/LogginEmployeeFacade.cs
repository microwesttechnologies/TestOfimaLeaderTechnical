// <copyright file="LogginEmployeeFacade.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Facades.Implementation
{
    using Ofm.EmployeeManager.Entities.Business.Entities.Request;
    using Ofm.EmployeeManager.Module.Services.Facades.Abstraction;
    using Ofm.EmployeeManager.Module.Services.Services;

    /// <summary>
    /// 
    /// </summary>
    public class LogginEmployeeFacade : ILogginFacade
    {
        private readonly LogginService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogginEmployeeFacade"/> class.
        /// </summary>
        /// <param name="service">The service layer responsible for loggin operations.</param>
        public LogginEmployeeFacade(LogginService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public bool ValidateEmployee(LoginRequest loginRequest)
        {
            return this.service.ValidateEmployee(loginRequest);
        }
    }
}
