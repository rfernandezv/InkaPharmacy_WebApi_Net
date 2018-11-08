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

namespace Api.Products.Controllers
{
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
                Specification<Product> specification = GetFindByName(ProductName);
                uowStatus = _unitOfWork.BeginTransaction();
                Product Product = _ProductRepository.FindByProductName(specification);
                _unitOfWork.Commit(uowStatus);
                ProductDto ProductsDto = _ProductAssembler.FromProductToProductDto(Product);
                return StatusCode(StatusCodes.Status200OK, ProductsDto);
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
                return Ok();
                //return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }

        }


        [Route("/api/Products/GetProductById")]
        [HttpGet]
        public IActionResult GetProductById([FromQuery] long ProductId)
        {
            bool uowStatus = false;
            try
            {
                Specification<Product> specification = GetById(ProductId);
                uowStatus = _unitOfWork.BeginTransaction();
                Product Product = _ProductRepository.GetById(specification);
                _unitOfWork.Commit(uowStatus);
                ProductDto ProductsDto = _ProductAssembler.FromProductToProductDto(Product);
                return StatusCode(StatusCodes.Status200OK, ProductsDto);
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
                //notification = customer.validateForSave();

                if (notification.hasErrors())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, notification.ToString());
                }
                _ProductRepository.Create(product);
                _unitOfWork.Commit(uowStatus);

                var message = "Product created!";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError /*, new ApiStringResponseDto(message)*/ );

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
                //notification = customer.validateForSave();

                if (notification.hasErrors())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, notification.ToString());
                }
                _ProductRepository.Update(product);
                _unitOfWork.Commit(uowStatus);

                var message = "Product Updated!";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status200OK, product);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                //KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError /*, new ApiStringResponseDto(message)*/ );

            }
        }

    }
}