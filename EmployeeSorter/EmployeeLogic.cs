using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeSorter
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private List<Employee> employees = new List<Employee>();
        public void SetEmployees(List<Employee> employees)
        {
            this.employees = employees;
        }

        public List<Employee> GetManagers()
        {
            List<Employee> managers = new List<Employee>();

            foreach (var employee in employees)
            {
                if (employee.SuperSSN == 0)
                {
                    List<Employee> slaves = employees.FindAll(x => x.SuperSSN == employee.SSN);
                    if (slaves != null && slaves.Count > 0)
                        managers.Add(employee);
                }
            }
            return managers;
        }

        public Employee GetManagerByDepartment(int departmentId)
        {
            Employee mgr = employees.Find(x => x.DepartmentId == departmentId && x.SuperSSN == 0);
            if (mgr == null)
                mgr = new Employee();
            return mgr;
            //Suggestion: Maybe use nullable ints when working with SSN?
        }

        public Employee GetManagerByEmployeeId(int employeeSSN)
        {
            Employee emp = employees.Find(y => y.SSN == employeeSSN);
            Employee mgr = employees.Find(x => x.SSN == emp.SuperSSN);
            if (mgr == null)
                mgr = new Employee();
            return mgr;
        }

        public List<Employee> GetSortedEmployeesBySSN()
        {
                return employees.OrderBy(x => x.SSN).ToList();
        }

        public List<Employee> GetSortedEmployeesByName()
        {
            return employees.OrderBy(x => x.Name).ToList();
        }

        public List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            return employees.FindAll(x => x.DepartmentId == departmentId);
        }
    }
}
