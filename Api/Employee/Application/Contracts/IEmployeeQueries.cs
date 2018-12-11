using System.Collections.Generic;
using InkaPharmacy.Api.Employees.Application.Dto;

namespace InkaPharmacy.Api.Employees.Application.Contracts
{
    public interface IEmployeeQueries
    {
        List<EmployeeQueryDto> GetListPaginated(long storeId, int page = 0, int pageSize = 5);
    }
}
