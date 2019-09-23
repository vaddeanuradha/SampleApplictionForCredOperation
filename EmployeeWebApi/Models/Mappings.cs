using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeEL;
using EmployeeApiBL;

namespace EmployeeWebApi.Models
{
    public static class Mappings
    {
        public static EmployeeModel ConvertFromEmployeeEntity(this EmployeeEntity employeeEntity)
        {
            EmployeeModel employee = new EmployeeModel();
            employee.Id = employeeEntity.Id;
            employee.Name = employeeEntity.Name;
            employee.Designation = employeeEntity.Designation;
            employee.Department = new DepartmentModel();
            employee.Department.Id = employeeEntity.Department.Id;
            employee.Department.DepartmentName = employeeEntity.Department.DepartmentName;
            return employee;
        }

        public static EmployeeEntity ConvertToEmployeeEntity(this EmployeeModel employee,EmployeeEntity employeeEntity=null)
        {
            if (employeeEntity == null)
            {
                employeeEntity = new EmployeeEntity();
            }
            employeeEntity.Id = employee.Id;
            employeeEntity.Name = employee.Name;
            employeeEntity.Designation = employee.Designation;
            employeeEntity.Department = new DepartmentEntity();
            employeeEntity.Department.Id = employee.Department.Id;
            employeeEntity.Department.DepartmentName = employee.Department.DepartmentName;
            return employeeEntity;
        }

        public static List<EmployeeModel> ConvertFromEmployeeEntityList(this List<EmployeeEntity> list)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach(var obj in list)
            {
                employees.Add(obj.ConvertFromEmployeeEntity());
            }
            
            return employees;
            
        }
       
        
    }
}