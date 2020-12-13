using System;
using System.Collections.Generic;
using System.Text;

namespace DACKSearch.Domain.Requests
{
    public class EmployeeSearchRequest
    {
        public string EmployeeText { get; set; }
        public string DepartmentText { get; set; }
        public string SubDepartmentText { get; set; }
    }
}
