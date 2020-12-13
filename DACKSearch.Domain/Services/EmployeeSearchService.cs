using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DACKSearch.Domain.Entities;
using DACKSearch.Domain.Mappers;
using DACKSearch.Domain.Repositories;
using DACKSearch.Domain.Requests;
using DACKSearch.Domain.Responses;

namespace DACKSearch.Domain.Services
{
    public class EmployeeSearchService : IEmployeeSearchService
    {
        private readonly IRepository<EmployeeSearch> _employeeRepository;
        private readonly IEmployeeMapper _employeeMapper;

        public EmployeeSearchService(IRepository<EmployeeSearch> employeeRepository, IEmployeeMapper employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
        }

        public async Task<IEnumerable<EmployeeSearchResponse>> EmployeeSearch(EmployeeSearchRequest request)
        {
            var result = await _employeeRepository.EmployeeSearch(request.EmployeeText, request.DepartmentText, request.SubDepartmentText);
            
            return result.Select(x => _employeeMapper.Map(x));
        } 
         
    }
}
