using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEL
{
    public class EmployeeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public DepartmentEntity Department { get; set; }
    }
}
