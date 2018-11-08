using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InkaPhatmacy.Api.Common.Application.Dto;
using System;
using InkaPhatmacy.Api.Common.Application;

namespace InkaPhatmacy.Api.Controllers
{

    using InkaPhatmacy.Api.Security.Application.Assembler;
    using InkaPhatmacy.Api.Security.Domain.Repository;
    using InkaPhatmacy.Api.Common.Domain.Specification;
 
    using System.Collections.Generic;
    using InkaPhatmacy.Api.Employee.Infrastructure.Persistence.NHibernate.Specification;
    using InkaPhatmacy.Api.Empleado.Domain.Entity;
    using InkaPhatmacy.Api.Empleado.Application.Dto;
    using InkaPhatmacy.Api.Employee.Domain.Repository;
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
