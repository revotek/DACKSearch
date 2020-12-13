using System.Collections.Generic; 
using System.Threading.Tasks;
using DACKSearch.Domain.Requests;
using DACKSearch.Domain.Responses;

namespace DACKSearch.Domain.Services
{
    public interface IEmployeeSearchService
    {
        Task<IEnumerable<EmployeeSearchResponse>> EmployeeSearch(EmployeeSearchRequest request);
    }
}
