using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Products.Application.Assembler;
using EnterprisePatterns.Api.Product.Application.Dto;
using EnterprisePatterns.Api.Product.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnterprisePatterns.Api.Product;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using EnterprisePatterns.Api.Product.Infrastructure.Persistence.NHibernate.Specification;
using Microsoft.AspNetCore.Authorization;
using EnterprisePatterns.Api.Common.Application.Dto;

namespace Api.Products.Controllers
{
    [Authorize]
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _ProductRepository;
        private readonly ProductAssembler _ProductAssembler;
        ResponseHandler responseHandler;

        public ProductController(
            IUnitOfWork unitOfWork,
            IProductRepository ProductRepository,
            ProductAssembler ProductAssembler
            )
        {
            _unitOfWork = unitOfWork;
            _ProductRepository = ProductRepository;
            _ProductAssembler = ProductAssembler;
            responseHandler = new ResponseHandler();
        }


        [Route("/api/Products/FindByProductName")]
        [HttpGet]
        public IActionResult FindByProductName([FromQuery] string ProductName)
        {
            bool uowStatus = false;
            try
            {
                Product product = new Product();
                Notification notification = product.validateFindByProductName(ProductName);

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                Specification<Product> specification = GetFindByName(ProductName);

                uowStatus = _unitOfWork.BeginTransaction();
                Product Product = _ProductRepository.FindByProductName(specification);
                _unitOfWork.Commit(uowStatus);

                ProductDto ProductsDto = _ProductAssembler.FromProductToProductDto(Product);

                return StatusCode(StatusCodes.Status200OK, ProductsDto);
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

        private Specification<Product> GetById(long ProductId)
        {
            Specification<Product> specification = Specification<Product>.All;
            specification = specification.And(new GetByIdBySpecification(ProductId));
            return specification;
        }

        private Specification<Product> GetFindByName(string ProductName)
        {
            Specification<Product> specification = Specification<Product>.All;
            specification = specification.And(new FindByNameBySpecification(ProductName));
            return specification;
        }


        [HttpGet]
        public IActionResult Products([FromQuery] int page = 0, [FromQuery] int size = 5)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                List<Product> customers = _ProductRepository.GetList(page, size);
                _unitOfWork.Commit(uowStatus);
                List<ProductDto> customersDto = _ProductAssembler.FromListProductToListProductDto(customers);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));
            }

        }


        [Route("/api/Products/GetProductById")]
        [HttpGet]
        public IActionResult GetProductById([FromQuery] long ProductId)
        {
            bool uowStatus = false;
            try
            {
                Product product = new Product();
                Notification notification = product.validateGetProductById(ProductId);

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                Specification<Product> specification = GetById(ProductId);

                uowStatus = _unitOfWork.BeginTransaction();
                product = _ProductRepository.GetById(specification);
                _unitOfWork.Commit(uowStatus);

                ProductDto ProductsDto = _ProductAssembler.FromProductToProductDto(product);
                return StatusCode(StatusCodes.Status200OK, ProductsDto);
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
        public IActionResult Create([FromBody] ProductDto ProductDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Product product = _ProductAssembler.FromProductDtoToProduct(ProductDto);
                notification = product.validateForSave();

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                product.Status = 1;
                _ProductRepository.Create(product);
                _unitOfWork.Commit(uowStatus);

                var message = "Product created!";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status201Created, product);
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
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));

            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductDto ProductDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Product product = _ProductAssembler.FromProductDtoToProduct(ProductDto);
                notification = product.validateForSave("U");

                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }
                _ProductRepository.Update(product);
                _unitOfWork.Commit(uowStatus);

                var message = "Product Updated!";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status200OK, product);
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
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(ex.Message));

            }
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] ProductDto ProductDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                Product product = new Product();
                product = _ProductAssembler.FromProductDtoToProduct(ProductDto);

                notification = product.validateDeleteProduct(product);
                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }

                uowStatus = _unitOfWork.BeginTransaction();
            
                Specification<Product> specification = GetById(product.Id);
                product = _ProductRepository.GetById(specification);
                _unitOfWork.Commit(uowStatus);

                product.Status = 0;
                _ProductRepository.Update(product);
                _unitOfWork.Commit(uowStatus);

                var message = "Product Updated!";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status200OK, product);
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
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message /*, new ApiStringResponseDto(message)*/ );

            }
        }

    }
}