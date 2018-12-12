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
using System.Collections.Generic;
using InkaPharmacy.Api.Employees.Application.Contracts;
using InkaPharmacy.Api.Common.Application.Dto;
using System.Threading.Tasks;

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
        private readonly IEmployeeQueries _employeeQueries;

        public EmployeesController(
            IUnitOfWork unitOfWork,
            IEmployeeRepository EmployeeRepository,
            EmployeeAssembler EmployeeAssembler, IEmployeeQueries employeeQueries)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = EmployeeRepository;
            _employeeAssembler = EmployeeAssembler;
            _responseHandler = new ResponseHandler();
            _employeeQueries = employeeQueries;
        }

        [ProducesResponseType(typeof(EmployeeDto), 200)]
        [Route("/api/Employees/FindByUsername")]
        [HttpGet]
        public IActionResult FindByUsername([FromQuery] string Username)
        {
            bool uowStatus = false;
            try
            {
                Employee employee = new Employee();
                Notification notification = employee.ValidateFindByUsername(Username);

                if (notification.HasErrors())
                {
                    throw new ArgumentException(notification.ErrorMessage());
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

        [ProducesResponseType(typeof(List<EmployeeQueryDto>), 200)]
        [Route("/api/Employees")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeQueryDto>>> GetEmployeesByStore([FromQuery] long StoreId,[FromQuery] int page = 0, [FromQuery] int size = 5)
        {
            try
            {
                List<EmployeeQueryDto> employeesDto = await _employeeQueries.GetListPaginated(StoreId, page, size);
                return StatusCode(StatusCodes.Status200OK, employeesDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));
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
