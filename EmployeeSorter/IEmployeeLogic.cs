using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace EmployeeSorter
{
    public interface IEmployeeLogic
    {
        /// <summary>
        /// Sets the employee list of the class for
        /// other methods
        /// </summary>
        /// <param name="employees"></param>
        void SetEmployees(List<Employee> employees);
        /// <summary>
        /// Returns Managers of employee list
        /// </summary>
        /// <returns></returns>
        List<Employee> GetManagers();
        /// <summary>
        /// Returns manager of provided department id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Employee GetManagerByDepartment(int departmentId);
        /// <summary>
        /// Returns manager of provided employee SSN
        /// </summary>
        /// <param name="employeeSSN"></param>
        /// <returns></returns>
        Employee GetManagerByEmployeeId(int employeeSSN);
        /// <summary>
        /// Returns a list of employees sorted by SSN
        /// in ascending order
        /// </summary>
        /// <returns></returns>
        List<Employee> GetSortedEmployeesBySSN();
        /// <summary>
        /// Returns a list of employees sorted by Name
        /// in ascending order 
        /// </summary>
        /// <returns></returns>
        List<Employee> GetSortedEmployeesByName();
        /// <summary>
        /// Returns Employees that are part of department
        /// whose id is provided in parameters
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        List<Employee> GetEmployeesByDepartment(int departmentId);

    }
}
