using System.Collections.Generic;
using System.Threading.Tasks;
using InkaPharmacy.Api.Employees.Application.Dto;

namespace InkaPharmacy.Api.Employees.Application.Contracts
{
    public interface IEmployeeQueries
    {
        Task<List<EmployeeQueryDto>> GetListPaginated(long storeId, int page = 0, int pageSize = 5);
    }
}
