using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab10
{
    public class Employee
    {
        public bool WorkingStatus { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Employee() { }

        public Employee(string name, int age, bool workingStatus)
        {
            WorkingStatus = workingStatus;
            Age = age;
            Name = name;
        }

        public override string ToString() => $"Name: {Name}, Age: {Age}, WorkingStatus: {WorkingStatus}";
    }
}
