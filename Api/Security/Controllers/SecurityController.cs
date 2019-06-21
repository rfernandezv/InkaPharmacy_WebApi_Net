using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using InkaPharmacy.Api.Common.Application;
using System.Linq;
using InkaPharmacy.Api.Security.Domain.Repository;
using InkaPharmacy.Api.Common.Domain.Specification;
using System.Collections.Generic;
using InkaPharmacy.Api.Security.Infrastructure.Persistence.NHibernate.Specification;
using InkaPharmacy.Api.Common.Constants;
using InkaPharmacy.Api.Employees.Domain.Entity;
using InkaPharmacy.Api.Employees.Application.Dto;
using InkaPharmacy.Api.Employees.Application.Assembler;
using InkaPharmacy.Api.Security.Application.Dto;
using InkaPharmacy.Api.Common.Application.Security;

namespace InkaPharmacy.Api.Controllers
{
    [Route("api/Security/Login")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityRepository _securityRepository;
        private readonly EmployeeAssembler _empleadoLoginAssembler;
        ResponseHandler responseHandler;

        public SecurityController(
            IUnitOfWork unitOfWork,
            ISecurityRepository securityRepository,
            EmployeeAssembler EmployeeLoginAssembler)
        {
            _unitOfWork = unitOfWork;
            _securityRepository = securityRepository;
            _empleadoLoginAssembler = EmployeeLoginAssembler;
            responseHandler = new ResponseHandler();
        }

        [HttpPost]
        public IActionResult Login(UserCredentialsDTO userCredentialsDTO)
        {
            if (userCredentialsDTO == null)
            {
                throw new ArgumentException("Credentials are missing");
            }

            bool uowStatus = false;
            try
            {
                Specification<Employee> specification = GetLogingSpecification(userCredentialsDTO.Username, userCredentialsDTO.Password);
                uowStatus = _unitOfWork.BeginTransaction();
                List<Employee> employees = _securityRepository.GetList(specification);
                _unitOfWork.Commit(uowStatus);

                if (employees.FirstOrDefault() == null)
                {
                    throw new ArgumentException("Employee is not logged in");
                }

                EmployeeDto employeeDto = _empleadoLoginAssembler.toDto(employees.FirstOrDefault());
                var token = Token.GenerateToken(employeeDto.Username);
                return Ok(responseHandler.getOkCommandResponse("bearer " + token, Constants.HttpStatus.Success, employeeDto));

            }
            catch (ArgumentException ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, responseHandler.getAppExceptionResponse());

            }
        }
        private Specification<Employee> GetLogingSpecification(string usu, string clave)
        {
            Specification<Employee> specification = Specification<Employee>.All;
            specification = specification.And(new LoginBySpecification(usu, clave));
            return specification;
        }

    }
}
