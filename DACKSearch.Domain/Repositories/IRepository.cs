using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DACKSearch.Domain.Repositories
{
    public interface IRepository<T> where T : class
    { 
        Task<IEnumerable<T>> EmployeeSearch(string employeeText, string departmentText, string subDepartmentText);
    }
}
