using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using DACKSearch.Domain.Entities;
using DACKSearch.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DACKSearch.Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<EmployeeSearch>
    {
        private readonly DackDbContext _context; 

        public EmployeeRepository(DackDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
           
        public async Task<IEnumerable<EmployeeSearch>> EmployeeSearch(string employeeText, string departmentText, string subdepartmentText)
        {
            var departmentParam = new SqlParameter("@departmentText", (object) departmentText??(object)DBNull.Value);
            var subDepartmentParam = new SqlParameter("@subDepartmentText", subdepartmentText??(object)DBNull.Value);
            var employeeParam = new SqlParameter("@EmployeeText", employeeText??(object)DBNull.Value);
            var employeeList = await _context
                .EmployeeSearch
                .FromSqlRaw("exec sp_EmployeeSearch @EmployeeText, @departmentText, @subDepartmentText", employeeParam, departmentParam, subDepartmentParam)
                .ToListAsync();

            return employeeList;
        } 
    }
}
