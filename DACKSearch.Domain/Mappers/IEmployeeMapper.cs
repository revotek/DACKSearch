using DACKSearch.Domain.Entities;
using DACKSearch.Domain.Requests;
using DACKSearch.Domain.Responses;

namespace DACKSearch.Domain.Mappers
{
    public interface IEmployeeMapper
    { 
        EmployeeSearchResponse Map(EmployeeSearch employee);
    }
}
