using EnterprisePatterns.Api.Common.Domain.Specification;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Product.Domain.Repository
{
    public interface IProductRepository
    {
        Product FindByProductName( Specification<Product> specification);

        Product GetById(Specification<Product> specification);

        List<Product> GetList(
            int page = 0,
            int pageSize = 5);

        List<Product> GetListFindByCategory(
             Specification<Product> specification,
           int page = 0,
           int pageSize = 5
          );

        void Create(Product product);

        void Update(Product product);

    }
}
