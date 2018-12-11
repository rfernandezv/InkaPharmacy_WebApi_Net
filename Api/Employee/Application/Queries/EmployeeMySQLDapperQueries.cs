using Dapper;
using InkaPharmacy.Api.Employees.Application.Contracts;
using InkaPharmacy.Api.Employees.Application.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Employees.Application.Queries
{
    public class EmployeeMySQLDapperQueries : IEmployeeQueries
    {
        public async Task<List<EmployeeQueryDto>> GetListPaginated(long storeId, int page = 0, int pageSize = 5)
        {
            string sql = @"
                    SELECT e.employee_id,e.name, e.last_name1,e.last_name2,e.address,e.telephone,e.username,e.email,
                    e.status,s.name as store_name,r.name as role_name
                    FROM employee e
                    join store s on s.store_id=e.store_id
                    join role r on r.role_id=e.role_id
                    where s.store_id = @StoreId
                    order by e.name ASC, e.last_name1 ASC
                    LIMIT @Page, @PageSize;";
            string connectionString = Environment.GetEnvironmentVariable("InkaPharmacyBD");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var result = await connection
                    .QueryAsync<EmployeeQueryDto>(sql, new
                    {
                        Page = page,
                        PageSize = pageSize,
                        StoreId = storeId
                    });
                    return result.ToList<EmployeeQueryDto>();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return new List<EmployeeQueryDto>();
                }
                finally
                {
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
