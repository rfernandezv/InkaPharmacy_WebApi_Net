using Xunit;
using InkaPharmacy.Api.Product.Controllers;
using InkaPharmacy.Api.Product.Domain.Repository;
using InkaPharmacy.Api.Products.Application.Assembler;
using InkaPharmacy.Api.Common.Application;
using Microsoft.AspNetCore.Mvc;
using InkaPharmacy.Api;
using Microsoft.AspNetCore.Hosting;

namespace Api.Unit.Testing
{
    public class ProductControllerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ProductAssembler _productAssembler;
        private readonly ProductController _productController;

        public ProductControllerTest(string[] args)
        {
            _ = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

            _productController = new ProductController(_unitOfWork, _productRepository, _productAssembler);
        }

        [Fact]
        public void ProductsPaginated_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _productController.ProductsPaginated();

            //Assert
            _ = Assert.IsAssignableFrom<IActionResult>(okResult.GetType());
        }
    }
}
