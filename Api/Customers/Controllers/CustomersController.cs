using System;
using System.Collections.Generic;
using InkaPharmacy.Api.Common.Application;
using InkaPharmacy.Api.Common.Application.Dto;
using InkaPharmacy.Api.Common.Application.Email;
using InkaPharmacy.Api.Common.Application.Enum;
using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Customers;
using InkaPharmacy.Api.Customers.Application.Assembler;
using InkaPharmacy.Api.Customers.Application.Dto;
using InkaPharmacy.Api.Customers.Domain.Repository;
using InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Specification;
using InkaPharmacy.API.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Customers.Controllers
{
    [Authorize]
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerAssembler _customerAssembler;
        ResponseHandler responseHandler;
        static readonly string sender = "jhonatantiradotiradodeep@gmail.com";
        static readonly string receiver = "jhonatan.tirado@unmsm.edu.pe";

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

        [NonAction]
        [ProducesResponseType(typeof(List<CustomerDto>), 200)]
        [HttpGet]
        public IActionResult Customers([FromQuery] int page = 0, [FromQuery] int size = 5)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                List<Customer> customers = _customerRepository.GetList(page, size);
                _unitOfWork.Commit(uowStatus);
                List<CustomerDto> customersDto = _customerAssembler.FromListCustomerToListCustomerDto(customers);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));
            }

        }

        [ProducesResponseType(typeof(GridDto), 200)]
        [HttpGet]
        public IActionResult CustomersPaginated([FromQuery] int page = 0, [FromQuery] int size = 5)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                GridDto customers = _customerRepository.GetListWithPageCounters(page, size);
                _unitOfWork.Commit(uowStatus);
                List<CustomerDto> productsDTO = _customerAssembler.FromListCustomerToListCustomerDto((List<Customer>)customers.Content);
                customers.Content = productsDTO;
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));
            }

        }

        [ProducesResponseType(typeof(CustomerDto), 200)]
        [Route("/api/Customers/FindByDocumentNumber")]
        [HttpGet]
        public IActionResult FindByDocumentNumber([FromQuery] string DocumentNumber)
        {
            bool uowStatus = false;
            try
            {
                Customer customer = new Customer();
                Notification notification = customer.validateFindByDocumentNumber(DocumentNumber);

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                Specification<Customer> specification = GetFindByDocumentNumber(DocumentNumber);
                uowStatus = _unitOfWork.BeginTransaction();
                customer = _customerRepository.FindByDocumentNumber(specification);
                _unitOfWork.Commit(uowStatus);
                CustomerDto customerDto = _customerAssembler.FromCustomerToCustomerDto(customer);
                return StatusCode(StatusCodes.Status200OK, customerDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerDto customerDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Customer customer = _customerAssembler.FromCustomerDtoToCustomer(customerDto);
                notification = customer.ValidateForSave();

                if (notification.hasErrors())
                {
                    return BadRequest(notification.errorMessage());
                }

                customer.Status = 1;
                _customerRepository.Create(customer);
                _unitOfWork.Commit(uowStatus);

                var message = "Customer " + customer.Id + " created!";
                KipubitRabbitMQ.SendMessage(message);
                SendGridEmail.Submit(sender, receiver, message);
                return StatusCode(StatusCodes.Status201Created, message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));

            }
        }

        [HttpPut("{CustomerId}")]
        public IActionResult Update(int CustomerId, [FromBody] CustomerDto CustomerDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Customer customer = _customerAssembler.FromCustomerDtoToCustomer(CustomerDto);
                customer.Id = CustomerId;
                notification = customer.ValidateForSave("U");

                ThrowErrors(notification);

                if (notification.hasErrors())
                {
                    return BadRequest(notification.errorMessage());
                }

                Specification<Customer> specification = GetById(CustomerId);
                // Handled by ConsoleLogger since the console has a loglevel of all
                logger.Message("Verifying customer exists", LogLevel.Debug);
                customer = _customerRepository.GetById(specification);
                logger.Message("Customer retrieved.", LogLevel.Info);

                if (customer == null)
                {
                    // Handled by ConsoleLogger and FileLogger since filelogger implements Warning & Error
                    logger.Message("Customer doesn't exist", LogLevel.Warning);
                    logger.Message("Preventing NULL exception", LogLevel.Error);
                    // Handled by ConsoleLogger and EmailLogger as it implements functional error
                    logger.Message("Business exception", LogLevel.FunctionalError);
                    notification.addError("Customer not found");
                    return BadRequest(notification.errorMessage());

                }
                _customerRepository.Update(customer);
                _unitOfWork.Commit(uowStatus);

                var message = "Customer " + CustomerId + " updated!";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status200OK, message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));

            }
        }

        [HttpDelete("{CustomerId}")]
        public IActionResult Delete(int CustomerId)
        {
            Notification notification = new Notification();

            if (CustomerId == 0)
            {
                notification.addError("CustomerId is missing");
                return BadRequest(notification.errorMessage());
            }

            bool uowStatus = false;
            try
            {
                Customer customer = new Customer();
                uowStatus = _unitOfWork.BeginTransaction();
                Specification<Customer> specification = GetById(CustomerId);
                customer = _customerRepository.GetById(specification);

                if (customer == null)
                {
                    notification.addError("Customer not found");
                    return BadRequest(notification.errorMessage());

                }

                customer.Status = 0;
                _customerRepository.Update(customer);
                _unitOfWork.Commit(uowStatus);

                var message = "Customer " + CustomerId + " deleted!";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status200OK, message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [ProducesResponseType(typeof(CustomerDto), 200)]
        [HttpGet("{CustomerId}")]
        public IActionResult GetCustomerById(long CustomerId)
        {
            bool uowStatus = false;
            try
            {
                Customer customer = new Customer();
                Notification notification = new Notification();

                if (CustomerId == 0)
                {
                    notification.addError("CustomerId is missing");
                    return BadRequest(notification.errorMessage());
                }

                Specification<Customer> specification = GetById(CustomerId);

                uowStatus = _unitOfWork.BeginTransaction();
                customer = _customerRepository.GetById(specification);
                _unitOfWork.Commit(uowStatus);

                CustomerDto customerDto = _customerAssembler.FromCustomerToCustomerDto(customer);
                return StatusCode(StatusCodes.Status200OK, customerDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, this.responseHandler.getAppExceptionResponse());
            }
        }

        private Specification<Customer> GetById(long CustomerId)
        {
            Specification<Customer> specification = Specification<Customer>.All;
            specification = specification.And(new GetByIdBySpecification(CustomerId));
            return specification;
        }
        private Specification<Customer> GetFindByDocumentNumber(string DocumentNumber)
        {
            Specification<Customer> specification = Specification<Customer>.All;
            specification = specification.And(new FindByDocumentNumberBySpecification(DocumentNumber));
            return specification;
        }

    }
}