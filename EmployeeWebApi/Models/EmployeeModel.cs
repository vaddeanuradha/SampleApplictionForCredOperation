using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeApiBL;
using EmployeeEL;

namespace EmployeeWebApi.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }
        public DepartmentModel Department { get; set; }
        private EmployeeBL _employeeBL;
        public EmployeeModel()
        {
            _employeeBL = new EmployeeBL();
        }
        public List<EmployeeModel> GetEmployees()
        {
            return _employeeBL.GetEmployees().ConvertFromEmployeeEntityList();
        }
        public EmployeeModel GetEmployeeById(int id)
        {
            return _employeeBL.GetEmployeeById(id).ConvertFromEmployeeEntity();
        }
        public bool CreateEmployee(EmployeeModel employee)
        {
            return _employeeBL.CreateEmployee(employee.ConvertToEmployeeEntity());
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            return _employeeBL.UpdateEmployee(employee.ConvertToEmployeeEntity());
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeBL.DeleteEmployee(id);
        }

        public bool LogRequest(string actionMethod, string controller, int userId)
        {
            RequestLogEntity log = new RequestLogEntity()
            {
                ActionMethodName = actionMethod,
                ControllerName = controller,
                UserId = userId,
                DateTime = DateTime.Now
            };
            return _employeeBL.LogRequest(log);
        }

    }

}