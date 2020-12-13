using System;
using System.Collections.Generic;

namespace DACKSearch.Domain.Entities
{
    public class Department
    {
        public Department()
        {
            SubDepartment = new HashSet<SubDepartment>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<SubDepartment> SubDepartment { get; set; }
    }
}
