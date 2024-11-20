// <copyright file="LogginService.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Module.Services.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Ofm.EmployeeManager.Dal.Dal.UnitWorks.Abstraction;
    using Ofm.EmployeeManager.Entities.Business.Entities.Request;
    using Ofm.EmployeeManager.Entities.Entities.Erp;

    /// <summary>
    /// Provides services to loggin.
    /// </summary>
    public class LogginService
    {
        private readonly IUnitWork unitWork;
        private readonly PasswordService passwordService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogginService"/> class.
        /// </summary>
        /// <param name="unitWork">The unit of work for data access.</param>
        public LogginService(IUnitWork unitWork)
        {
            this.unitWork = unitWork;
            this.passwordService = new PasswordService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public bool ValidateEmployee(LoginRequest loginRequest)
        {
            Expression<Func<Employee, bool>> predicate = e => e.EmployeeEmail == loginRequest.Email;

            Employee employee = this.unitWork.Employee.Find(predicate).FirstOrDefault() ?? new();

            if (employee == null)
            {
                return false;
            }

            return this.passwordService.VerifyPassword(loginRequest.Password, employee.PasswordHash, employee.PasswordSalt);
        }
    }
}
