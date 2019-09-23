using System;
using EmployeeEL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiDAL
{
    public static class EmployeeMapping
    {
        public static EmployeeEntity ConvertToEmployeeEntity(this Employee employee)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            employeeEntity.Id = employee.Id;
            employeeEntity.Name = employee.Name;
            employeeEntity.Designation = employee.Designation;
            employeeEntity.Department = new DepartmentEntity();
            employeeEntity.Department.Id = employee.Department1.Id;
            employeeEntity.Department.DepartmentName = employee.Department1.Department1;

            return employeeEntity;
        }
        public static List<EmployeeEntity> ConvertToEmployeeEntityList(this List<Employee> employees)
        {
            List<EmployeeEntity> employeeEntityList = new List<EmployeeEntity>();
            foreach(var employee in employees)
            {
                employeeEntityList.Add(employee.ConvertToEmployeeEntity());

            }
            return employeeEntityList;
        }
        public static Employee ConvertToEmployeeDB(this EmployeeEntity empEntity,Employee emp=null)
        {

           // emp = emp==null?new Employee():emp;
            if(emp==null)
            {
                emp = new Employee();
            }
            emp.Name = empEntity.Name;
            emp.Designation = empEntity.Designation;
            emp.Department = empEntity.Department.Id;
            return emp;
        }
    }
}
