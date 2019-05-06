using System;
using System.Collections.Generic;
using System.Linq;
using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate;
using InkaPharmacy.Api.Customers.Domain.Repository;

namespace InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Repository
{
    using InkaPharmacy.Api.Common.Application.Dto;
    using InkaPharmacy.Api.Product;
    using InkaPharmacy.Api.Product.Domain.Repository;

    class ProductNHibernateRepository : BaseNHibernateRepository<Product>, IProductRepository
    {
        public ProductNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public Product FindByProductName(Specification<Product> specification)
        {
            Product product = new Product();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                product = _unitOfWork.GetSession().Query<Product>()
                .Where(specification.ToExpression()).FirstOrDefault();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return product;
        }

        public Product GetById(Specification<Product> specification)
        {
            Product product = new Product();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                product = _unitOfWork.GetSession().Query<Product>()
                .Where(specification.ToExpression()).FirstOrDefault();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return product;
        }

        public List<Product> GetList(int page = 0, int pageSize = 5)
        {
            List<Product> products = new List<Product>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                products = _unitOfWork.GetSession().Query<Product>()
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return products;
        }

        public List<Product> GetListFindByCategory(Specification<Product> specification, int page = 0, int pageSize = 5)
        {
            List<Product> products = new List<Product>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                products = _unitOfWork.GetSession().Query<Product>()
                       .Where(specification.ToExpression())
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return products;
        }

        public GridDto GetListWithPageCounters(int page = 0, int pageSize = 5)
        {
            List<Product> products = new List<Product>();
            GridDto result = new GridDto();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                products = _unitOfWork.GetSession().Query<Product>()
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
                _unitOfWork.Commit(uowStatus);
                result = new GridDto
                {
                    Content = products,
                    TotalRecords = CountTotalRecords(),
                    CurrentPage = page,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return result;
        }


        public GridDto GetListLikeSearchWithPageCounters(Specification<Product> specification, int page = 0, int pageSize = 5)
        {
            List<Product> products = new List<Product>();
            GridDto result = new GridDto();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                products = _unitOfWork.GetSession().Query<Product>()
                        .Where(specification.ToExpression())
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
                _unitOfWork.Commit(uowStatus);
                result = new GridDto
                {
                    Content = products,
                    TotalRecords = CountTotalRecordsLikeSearchByName(specification),
                    CurrentPage = page,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return result;
        }

        public int CountTotalRecordsLikeSearchByName(Specification<Product> specification)
        {
            int totalRecords;
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                totalRecords = _unitOfWork.GetSession().Query<Product>().Where(specification.ToExpression()).ToList().Count();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return totalRecords;
        }
    }
}
