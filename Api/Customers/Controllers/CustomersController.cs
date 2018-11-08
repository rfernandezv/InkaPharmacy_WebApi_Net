using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Customers;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Customers.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerAssembler _customerAssembler;
        ResponseHandler responseHandler;

        public CustomerController(
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository,
            CustomerAssembler customerAssembler
            )
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _customerAssembler = customerAssembler;
            responseHandler = new ResponseHandler();
        }

        [Route("/api/Customers/FindByDocumentNumber")]
        [HttpGet]
        public IActionResult FindByDocumentNumber([FromQuery] string DocumentNumber)
        {
            bool uowStatus = false;
            try
            {
                Specification< Customer> specification = GetFindByDocumentNumber(DocumentNumber);
                uowStatus = _unitOfWork.BeginTransaction();
                Customer customer  = _customerRepository.FindByDocumentNumber(specification);
                _unitOfWork.Commit(uowStatus);
                CustomerDto customersDto = _customerAssembler.FromCustomerToCustomerDto(customer);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, this.responseHandler.getAppExceptionResponse());
            }
        }

        private Specification<Customer> GetFindByDocumentNumber(string DocumentNumber)
        {
            Specification<Customer> specification = Specification<Customer>.All;
            specification = specification.And(new FindByDocumentNumberBySpecification( DocumentNumber));
            return specification;
        }

    }
}