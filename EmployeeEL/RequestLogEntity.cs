using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEL
{
   public class RequestLogEntity
    {
        public int Id { get; set; }
        public string ActionMethodName { get; set; }
        public string ControllerName { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}
