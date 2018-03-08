using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Department
    {
        public string DName;
        public int DNumber;
        public int employeeCount;
        public int MgrSSN;
        //public DateTime MgrStartDate;

        public Department(string dname, int dnumber, int employeecount)//int mgrssn, DateTime mgrstartdate)
        {
            DName = dname;
            DNumber = dnumber;
            employeeCount = employeecount;
            MgrSSN = -1;
            //MgrStartDate = mgrstartdate;
        }
        public override string ToString()
        {
            return "Department: " + DName + "   Department number: " + DNumber + "   Emplyee count: " + employeeCount + "   Manager SSN: " + MgrSSN;
        }
    }
}
