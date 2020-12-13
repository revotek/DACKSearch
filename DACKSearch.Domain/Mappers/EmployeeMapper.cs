using DACKSearch.Domain.Entities;
using DACKSearch.Domain.Requests;
using DACKSearch.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DACKSearch.Domain.Mappers
{
    public class EmployeeMapper : IEmployeeMapper
    {
        public EmployeeSearchResponse Map(EmployeeSearch employee)
        {
            if (employee == null) return null;
            var response = new EmployeeSearchResponse()
            {
                EmployeeId = employee.EmployeeId, 
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Bio = employee.Bio,
                SubDepartmentName = employee.SubDepartmentName,
                DepartmentName = employee.DepartmentName,
                ProfileImage = employee.ProfileImage,
                FbprofileLink = employee.FbprofileLink,
                TwitterProfileLink = employee.TwitterProfileLink
            };

            return response;
        }
    }
}
