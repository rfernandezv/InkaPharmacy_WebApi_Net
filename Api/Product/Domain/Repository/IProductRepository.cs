using InkaPharmacy.Api.Common.Application.Dto;
using InkaPharmacy.Api.Common.Domain.Specification;
using System.Collections.Generic;

namespace InkaPharmacy.Api.Product.Domain.Repository
{
    public interface IProductRepository
    {
        Product FindByProductName( Specification<Product> specification);

        Product GetById(Specification<Product> specification);

        List<Product> GetList(
            int page = 0,
            int pageSize = 5);

        GridDto GetListWithPageCounters(int page = 0,int pageSize = 5);

        GridDto GetListLikeSearchWithPageCounters(Specification<Product> specification, int page = 0, int pageSize = 5);

        List<Product> GetListFindByCategory(
             Specification<Product> specification,
           int page = 0,
           int pageSize = 5
          );

        void Create(Product product);

        void Update(Product product);

    }
}
