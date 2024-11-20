// <copyright file="LogginEmployeeController.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ofm.EmployeeManager.Entities.Business.Entities.Request;
    using Ofm.EmployeeManager.Module.Services.Facades.Implementation;

    /// <summary>
    /// Loggin Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogginEmployeeController : ControllerBase
    {
        private readonly LogginEmployeeFacade facade;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogginEmployeeController"/> class.
        /// </summary>
        /// <param name="facade">Facade that handles employee operations.</param>
        public LogginEmployeeController(LogginEmployeeFacade facade)
        {
            this.facade = facade;
        }

        /// <summary>
        /// Valida un usuario utilizando correo electrónico y contraseña.
        /// </summary>
        /// <param name="loginRequest">Objeto que contiene el email y la contraseña del usuario.</param>
        /// <returns>Resultado de la validación.</returns>
        [HttpPost("ValidateEmployee")]
        public bool ValidateEmployee([FromBody] LoginRequest loginRequest)
        {
            return this.facade.ValidateEmployee(loginRequest);
        }
    }
}
