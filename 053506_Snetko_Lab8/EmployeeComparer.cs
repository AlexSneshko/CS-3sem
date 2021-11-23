using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _053506_Snetko_Lab8
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Name.CompareTo(y.Name);
    }
}
