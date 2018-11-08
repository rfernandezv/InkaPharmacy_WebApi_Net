using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InkaPharmacy.Api.Common.Application.Dto;
using System;
using InkaPharmacy.Api.Common.Application;

namespace InkaPharmacy.Api.Controllers
{
    using InkaPharmacy.Api.Security.Application.Assembler;
    using InkaPharmacy.Api.Employee.Domain.Repository;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("v1/employee/loggin")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _empleadoRepository;
        private readonly EmployeeAssembler _empleadoLoginAssembler;

        public EmployeeController(
            IUnitOfWork unitOfWork,
            IEmployeeRepository EmployeeRepository,
            EmployeeAssembler EmployeeLoginAssembler)
        {
            _unitOfWork = unitOfWork;
            _empleadoRepository = EmployeeRepository;
            _empleadoLoginAssembler = EmployeeLoginAssembler;
        }


    }
}
