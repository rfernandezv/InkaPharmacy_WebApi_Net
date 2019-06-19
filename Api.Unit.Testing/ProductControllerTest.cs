using Xunit;
using InkaPharmacy.Api.Product;
using InkaPharmacy.Api.Product.Controllers;
using InkaPharmacy.Api.Product.Domain.Repository;
using InkaPharmacy.Api.Products.Application.Assembler;
using InkaPharmacy.Api.Common.Application;
using Microsoft.AspNetCore.Mvc;
using InkaPharmacy.Api;
using Microsoft.AspNetCore.Hosting;
using Moq;
using InkaPharmacy.Api.Common.Application.Dto;
using System.Collections.Generic;
using InkaPharmacy.Api.Common.Domain.ValueObject;
using InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate;

namespace Api.Unit.Testing
{
    public class ProductControllerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ProductAssembler _productAssembler;
        private readonly ProductController _productController;
        private readonly Mock<IProductRepository> mockRepository;
        private readonly Mock<SessionFactory> mockSessionFactory;

        public ProductControllerTest()
        {
            //_ = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
            mockRepository = new Mock<IProductRepository>();
            mockSessionFactory = new Mock<SessionFactory>();
            _unitOfWork = new UnitOfWorkNHibernate (mockSessionFactory.Object);
            _productRepository = mockRepository.Object;
            _productController = new ProductController(_unitOfWork, _productRepository, _productAssembler);
        }

        [Fact]
        public void ProductsPaginated_WhenCalled_ReturnsOkResult()
        {
            //Act
            var products = new List<Product>();
            var product1 = new Product {Id =1,Name="Penicilina",Stock = 12 , Category_id =14, Lot_number = "231243",
                Sanitary_registration_number ="SAN0012", Registration_date  = System.DateTime.Now,
                Expiration_date = System.DateTime.Now,
                Status = 1, Stock_status =1
                //Price = new Money { Currency = InkaPharmacy.Api.Common.Application.Enum.Currency.USD, Amount = 10 }
            };

            products.Add(product1);

            mockRepository.Setup(x => x.GetListWithPageCounters(0, 5)).Returns(new GridDto
            {
                Content = products,
                TotalRecords = 23,
                CurrentPage = 0,
                PageSize = 5
            });
            var okResult = _productController.ProductsPaginated();

            //Assert
            _ = Assert.IsAssignableFrom<IActionResult>(okResult.GetType());
        }
    }
}
