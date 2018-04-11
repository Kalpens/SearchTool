using System.Collections.Generic;
using EmployeeSorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmplyeeUnitTest
{
    [TestClass]
    public class EmployeeLogicTest
    {
        private readonly Employee _employee = new Employee()
        {
            Name = "Andre",
            SSN = 123456789,
            DepartmentId = 1
        };
        private readonly Employee _employee2 = new Employee()
        {
            Name = "Mark",
            SSN = 234567891,
            SuperSSN = 123456789,
            DepartmentId = 1
        };
        private readonly Employee _employee3 = new Employee()
        {
            Name = "Clain",
            SSN = 323456789
        };
        private readonly Employee _employee4 = new Employee()
        {
            Name = "Bill",
            DepartmentId = 2,
            SSN = 543284762,
            SuperSSN = 938472649
        };
        private readonly Employee _employee5 = new Employee()
        {
            Name = "Donald",
            SSN = 938472649,
            DepartmentId = 2
        };
        private readonly List<Employee> _listOfEmployees = new List<Employee>();

        [TestMethod]
        public void TestGetManagers()
        {
            //Tests if single manager is returned correctly
            _listOfEmployees.Add(_employee);
            _listOfEmployees.Add(_employee2);
            _listOfEmployees.Add(_employee3);
            var employeeLogic = new EmployeeLogic();
            employeeLogic.SetEmployees(_listOfEmployees);
            var managerList = employeeLogic.GetManagers();
            Assert.AreEqual(managerList[0].SSN,_employee.SSN);

            //Tests for two managers
            _listOfEmployees.Add(_employee4);
            _listOfEmployees.Add(_employee5);
            employeeLogic.SetEmployees(_listOfEmployees);
            managerList = employeeLogic.GetManagers();
            Assert.IsTrue(managerList.Count == 2);

            //Tests if there are no managers
            _listOfEmployees.RemoveAt(1);
            _listOfEmployees.RemoveAt(2);
            employeeLogic.SetEmployees(_listOfEmployees);
            managerList = employeeLogic.GetManagers();
            Assert.IsTrue(managerList.Count == 0);
        }

        [TestMethod]
        public void TestGetManagerByDepartment()
        {
            _listOfEmployees.Add(_employee);
            _listOfEmployees.Add(_employee2);
            _listOfEmployees.Add(_employee3);
            _listOfEmployees.Add(_employee4);
            _listOfEmployees.Add(_employee5);
            var employeeLogic = new EmployeeLogic();
            employeeLogic.SetEmployees(_listOfEmployees);
            var manager = employeeLogic.GetManagerByDepartment(1);
            //Tests if return correct manager of department 1 
            Assert.AreEqual(manager.SSN, _employee.SSN);
            manager = employeeLogic.GetManagerByDepartment(2);
            //Tests if retuns correct manager of department 2
            Assert.AreEqual(manager.SSN, _employee5.SSN);
            //Tests if returns empty manager if there is no manager
            employeeLogic = new EmployeeLogic();
            manager = employeeLogic.GetManagerByDepartment(1);
            Assert.IsTrue(manager.Name == null);

        }

        [TestMethod]
        public void TestGetManagerByEmployee()
        {
            _listOfEmployees.Add(_employee);
            _listOfEmployees.Add(_employee2);
            _listOfEmployees.Add(_employee3);
            _listOfEmployees.Add(_employee4);
            _listOfEmployees.Add(_employee5);
            var employeeLogic = new EmployeeLogic();
            employeeLogic.SetEmployees(_listOfEmployees);
            var manager = employeeLogic.GetManagerByEmployeeId(_employee2.SSN);
            //Tests if returns correct manager of employee 2
            Assert.AreEqual(manager.SSN, _employee.SSN);
            manager = employeeLogic.GetManagerByEmployeeId(_employee4.SSN);
            //Tests if returns correct manager of employee 4
            Assert.AreEqual(manager.SSN, _employee5.SSN);
            //Tests if returns empty manager if there is no manager for SSN
            employeeLogic = new EmployeeLogic();
            manager = employeeLogic.GetManagerByEmployeeId(1231231);
            Assert.IsTrue(manager.Name == null);
        }

        [TestMethod]
        public void TestGetManagerSortedBySSN()
        {
            _listOfEmployees.Add(_employee3);
            _listOfEmployees.Add(_employee2);
            _listOfEmployees.Add(_employee);
            var employeeLogic = new EmployeeLogic();
            employeeLogic.SetEmployees(_listOfEmployees);
            var listOfSortedEmployees = employeeLogic.GetSortedEmployeesBySSN();
            //Checks if returned list of employees is sorted by SSN
            Assert.AreEqual(listOfSortedEmployees[0].SSN, _employee.SSN);
            Assert.AreEqual(listOfSortedEmployees[1].SSN, _employee2.SSN);
            Assert.AreEqual(listOfSortedEmployees[2].SSN, _employee3.SSN);
            //Tests if returns empty list if there are no employees
            employeeLogic = new EmployeeLogic();
            listOfSortedEmployees = employeeLogic.GetSortedEmployeesBySSN();
            Assert.IsTrue(listOfSortedEmployees.Count == 0);

        }

        [TestMethod]
        public void TestGetManagerSortedByName()
        {
            _listOfEmployees.Add(_employee3);
            _listOfEmployees.Add(_employee2);
            _listOfEmployees.Add(_employee);
            var employeeLogic = new EmployeeLogic();
            employeeLogic.SetEmployees(_listOfEmployees);
            var listOfSortedEmployees = employeeLogic.GetSortedEmployeesByName();
            //Checks if returned list of employees is sorted by name
            Assert.AreEqual(listOfSortedEmployees[0].SSN, _employee.SSN);
            Assert.AreEqual(listOfSortedEmployees[1].SSN, _employee3.SSN);
            Assert.AreEqual(listOfSortedEmployees[2].SSN, _employee2.SSN);
            //Tests if returns empty list if there are no employees
            employeeLogic = new EmployeeLogic();
            listOfSortedEmployees = employeeLogic.GetSortedEmployeesByName();
            Assert.IsTrue(listOfSortedEmployees.Count == 0);
        }

        [TestMethod]
        public void TestGetEmployeesByDepartment()
        {
            _listOfEmployees.Add(_employee3);
            _listOfEmployees.Add(_employee2);
            _listOfEmployees.Add(_employee);
            var employeeLogic = new EmployeeLogic();
            employeeLogic.SetEmployees(_listOfEmployees);
            var listOfEmployeesInDepartment = employeeLogic.GetEmployeesByDepartment(1);
            //Test if returned count of employees is correct
            Assert.IsTrue(listOfEmployeesInDepartment.Count == 2);
            //Asserts if returned employees are of department 1
            Assert.AreEqual(listOfEmployeesInDepartment[0].DepartmentId, 1);
            Assert.AreEqual(listOfEmployeesInDepartment[1].DepartmentId, 1);
            _listOfEmployees.Add(_employee4);
            _listOfEmployees.Add(_employee5);
            listOfEmployeesInDepartment = employeeLogic.GetEmployeesByDepartment(2);
            //Test if returned count of employees is correct
            Assert.IsTrue(listOfEmployeesInDepartment.Count == 2);
            //Asserts if returned employees are of department 1
            Assert.AreEqual(listOfEmployeesInDepartment[0].DepartmentId, 2);
            Assert.AreEqual(listOfEmployeesInDepartment[1].DepartmentId, 2);
            //Tests if returns empty list if there are no employees in department
            employeeLogic = new EmployeeLogic();
            listOfEmployeesInDepartment = employeeLogic.GetEmployeesByDepartment(1);
            Assert.IsTrue(listOfEmployeesInDepartment.Count == 0);
        }

    }
}
