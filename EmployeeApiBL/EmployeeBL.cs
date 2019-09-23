using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApiDAL;
using EmployeeEL;

namespace EmployeeApiBL
{
    public class EmployeeBL
    {
        private EmployeeDAL _employeeDAL;
        public EmployeeBL()
        {
            _employeeDAL = new EmployeeDAL();
        }
        public List<EmployeeEntity> GetEmployees()
        {
            return _employeeDAL.GetEmployees();
        }
        public EmployeeEntity GetEmployeeById(int id)
        {
            return _employeeDAL.GetEmployeeById(id);
        }
        public bool CreateEmployee(EmployeeEntity emp)
        {
            return _employeeDAL.CreateEmployee(emp);
        }
        public bool DeleteEmployee(int id)
        {
            return _employeeDAL.DeleteEmployee(id);
        }
        public bool UpdateEmployee(EmployeeEntity emp)
        {
            return _employeeDAL.UpdateEmployee(emp);
        }
        public bool LogRequest(RequestLogEntity logEntity)
        {
            return _employeeDAL.LogRequest(logEntity);
        }
    }
}
