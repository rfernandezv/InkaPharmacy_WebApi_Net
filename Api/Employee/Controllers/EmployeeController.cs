using Microsoft.AspNetCore.Mvc;
using InkaPharmacy.Api.Common.Application;
using InkaPharmacy.Api.Employees.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using InkaPharmacy.Api.Employees.Domain.Entity;
using System;
using InkaPharmacy.Api.Common.Domain.Specification;
using Microsoft.AspNetCore.Http;
using InkaPharmacy.Api.Employees.Application.Dto;
using InkaPharmacy.Api.Employees.Infrastructure.Persistence.NHibernate.Specification;
using InkaPharmacy.Api.Employees.Application.Assembler;

namespace InkaPharmacy.Api.Controllers
{
    [Authorize]
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeAssembler _employeeAssembler;
        public ResponseHandler _responseHandler;

        public EmployeesController(
            IUnitOfWork unitOfWork,
            IEmployeeRepository EmployeeRepository,
            EmployeeAssembler EmployeeAssembler)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = EmployeeRepository;
            _employeeAssembler = EmployeeAssembler;
            _responseHandler = new ResponseHandler();
        }

        [Route("/api/Employees/FindByUsername")]
        [HttpGet]
        public IActionResult FindByUsername([FromQuery] string Username)
        {
            bool uowStatus = false;
            try
            {
                Employee employee = new Employee();
                Notification notification = employee.ValidateFindByUsername(Username);

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                Specification<Employee> specification = GetFindByUsername(Username);
                uowStatus = _unitOfWork.BeginTransaction();
                employee = _employeeRepository.FindByAnySpecificField(specification);
                _unitOfWork.Commit(uowStatus);
                EmployeeDto employeeDto = _employeeAssembler.toDto(employee);
                return StatusCode(StatusCodes.Status200OK, employeeDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(_responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, this._responseHandler.getAppExceptionResponse());
            }
        }

        private Specification<Employee> GetFindByUsername(string Username)
        {
            Specification<Employee> specification = Specification<Employee>.All;
            specification = specification.And(new FindByUsernameBySpecification(Username));
            return specification;
        }


    }
}
