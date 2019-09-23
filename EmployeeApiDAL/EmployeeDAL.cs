using System;
using EmployeeEL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiDAL
{
    public class EmployeeDAL
    {
        private EmployeeDBEntities _database;
        public EmployeeDAL()
        {
            _database = new EmployeeDBEntities();
        }
        public List<EmployeeEntity> GetEmployees()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();
            var employeesData = _database.Employees.ToList();
            return employeesData.ConvertToEmployeeEntityList();
        }
        public EmployeeEntity GetEmployeeById(int id)
        {
            EmployeeEntity employee = new EmployeeEntity();
            var employeeData = _database.Employees.FirstOrDefault(e => e.Id == id);
            employee= employeeData.ConvertToEmployeeEntity();
            return employee;
        }
        public bool CreateEmployee(EmployeeEntity emp)
        {
           // Employee employee = new Employee();
           var employee = emp.ConvertToEmployeeDB();
            _database.Employees.Add(employee);
            int result = _database.SaveChanges();
            return result > 0 ? true : false;
        }
        public bool UpdateEmployee(EmployeeEntity emp)
        {
            Employee empData = _database.Employees.FirstOrDefault(e => e.Id == emp.Id);
            empData = emp.ConvertToEmployeeDB(empData);
            //empData.Name = emp.Name;
            //empData.Designation = emp.Designation;
            //empData.Department = emp.Department.Id;
            int result = _database.SaveChanges();
            return result > 0 ? true : false;
 

        }
        public bool DeleteEmployee(int id)
        {
            var emp = _database.Employees.FirstOrDefault(e => e.Id == id);
            _database.Employees.Remove(emp);
            int result = _database.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool LogRequest(RequestLogEntity logData)
        {
            RequestCallLog requestLog = new RequestCallLog()
            {
                ActionMethodName = logData.ActionMethodName,
                ControllerName = logData.ControllerName,
                DateTime = logData.DateTime,
                UserId = logData.UserId
            };

            _database.RequestCallLogs.Add(requestLog);
            int result = _database.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}
