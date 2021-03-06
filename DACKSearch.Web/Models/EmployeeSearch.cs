﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DACKSearch.Web.Models
{
    public class EmployeeSearch
    {
        public int EmployeeId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImage { get; set; }
        public string FbprofileLink { get; set; }
        public string TwitterProfileLink { get; set; }
        public string SubDepartmentName { get; set; } 
        public string DepartmentName { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}
