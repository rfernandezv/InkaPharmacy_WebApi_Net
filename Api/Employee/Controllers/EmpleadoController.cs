using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EnterprisePatterns.Api.Common.Application.Dto;
using System;
using EnterprisePatterns.Api.Common.Application;

namespace EnterprisePatterns.Api.Controllers
{

    using EnterprisePatterns.Api.Security.Application.Assembler;
    using EnterprisePatterns.Api.Security.Domain.Repository;
    using EnterprisePatterns.Api.Common.Domain.Specification;
 
    using System.Collections.Generic;
    using EnterprisePatterns.Api.Employee.Infrastructure.Persistence.NHibernate.Specification;
    using EnterprisePatterns.Api.Empleado.Domain.Entity;
    using EnterprisePatterns.Api.Empleado.Application.Dto;
    using EnterprisePatterns.Api.Employee.Domain.Repository;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("v1/empleado/loggin")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _empleadoRepository;
        private readonly EmployeeAssembler _empleadoLoginAssembler;

        public EmpleadoController(
            IUnitOfWork unitOfWork,
            IEmployeeRepository empleadoRepository,
            EmployeeAssembler empleadoLoginAssembler)
        {
            _unitOfWork = unitOfWork;
            _empleadoRepository = empleadoRepository;
            _empleadoLoginAssembler = empleadoLoginAssembler;
        }


    }
}
