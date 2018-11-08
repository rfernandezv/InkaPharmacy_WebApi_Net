using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EnterprisePatterns.Api.BankAccounts.Application.Assembler;
using EnterprisePatterns.Api.BankAccounts.Domain.Entity;
using EnterprisePatterns.Api.BankAccounts.Domain.Repository;
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


        [HttpGet]
        public IActionResult Loggin( [FromQuery]string usu, [FromQuery] string clave)
        {
            bool uowStatus = false;
            //float minimumRating = 4;
            try
            {
                Specification<Employee> specification = GetLoggingSpecification(usu, clave);
                uowStatus = _unitOfWork.BeginTransaction();
                List<Employee> empleados = _empleadoRepository.GetList(specification /*, minimumRating*/);
                _unitOfWork.Commit(uowStatus);
                List< EmployeeDto> empleadosDto = _empleadoLoginAssembler.toDtoList(empleados);
                return StatusCode(StatusCodes.Status200OK , empleadosDto);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }
        }

        private Specification<Employee> GetLoggingSpecification( string usu, string clave /*bool forKidsOnly, bool onCD*/)
        {
            Specification<Employee> specification = Specification<Employee>.All;

            //if (forKidsOnly)
            //    specification = specification.And(new MovieForKidsSpecification());
            //if (onCD)
            //    specification = specification.And(new AvailableOnCDSpecification());

            specification = specification.And(new LoggingBySpecification(usu, clave));

            //spec = new MovieDirectedBySpecification("Marc Webb");
            return specification;
        }

        //[HttpPost]
        //public IActionResult Create(int ci, [FromBody] EmployeeDto empleadoLoginDto)
        //{
        //    bool uowStatus = false;
        //    try
        //    {
        //        uowStatus = _unitOfWork.BeginTransaction();
        //        empleadoLoginDto.ci = ci;
        //        //TODO: Validations with Notification Pattern
        //        Employee empleado = _empleadoLoginAssembler.toEntity(empleadoLoginDto);
        //        _securityRepository.Create(empleado);
        //        _unitOfWork.Commit(uowStatus);
        //        return StatusCode(StatusCodes.Status201Created, new ApiStringResponseDto("Employee Created!"));
        //    }
        //    catch (Exception ex)
        //    {
        //        _unitOfWork.Rollback(uowStatus);
        //        Console.WriteLine(ex.StackTrace);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));

        //    }
        //}
    }
}
