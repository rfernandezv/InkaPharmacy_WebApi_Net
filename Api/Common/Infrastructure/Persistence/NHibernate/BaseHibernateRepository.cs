using System;
using System.Linq;

namespace InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate
{
    public class BaseNHibernateRepository<T>
    {
        protected readonly UnitOfWorkNHibernate _unitOfWork;

        protected BaseNHibernateRepository(UnitOfWorkNHibernate unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(T entity)
        {
            SaveOrUpdate(entity);
        }

        public T Read(int id)
        {
            T entity;
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                entity = _unitOfWork.GetSession().Get<T>(id);
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return entity;
	    }

        public void Update(T entity)
        {
            SaveOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                _unitOfWork.GetSession().Delete(entity);
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
        }

        private void SaveOrUpdate(T entity)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                _unitOfWork.GetSession().SaveOrUpdate(entity);
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
        }

        public int CountTotalRecords()
        {
            int totalRecords;
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                totalRecords = _unitOfWork.GetSession().Query<T>().ToList().Count();
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
