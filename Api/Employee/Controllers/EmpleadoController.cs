using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InkaPharmacy.Api.Common.Application.Dto;
using System;
using InkaPharmacy.Api.Common.Application;

namespace InkaPharmacy.Api.Controllers
{

    using InkaPharmacy.Api.Security.Application.Assembler;
    using InkaPharmacy.Api.Security.Domain.Repository;
    using InkaPharmacy.Api.Common.Domain.Specification;
 
    using System.Collections.Generic;
    using InkaPharmacy.Api.Employee.Infrastructure.Persistence.NHibernate.Specification;
    using InkaPharmacy.Api.Employee.Domain.Entity;
    using InkaPharmacy.Api.Employee.Application.Dto;
    using InkaPharmacy.Api.Employee.Domain.Repository;
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
