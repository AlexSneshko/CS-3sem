using System;
using System.Collections.Generic;
using System.Reflection;

namespace _053506_Snetko_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            var emploees = new List<Employee>();
            emploees.Add(new Employee("name1", 15, true));
            emploees.Add(new Employee("name2", 19, true));
            emploees.Add(new Employee("name3", 28, false));
            emploees.Add(new Employee("name4", 25, true));
            emploees.Add(new Employee("name5", 35, false));
            emploees.Add(new Employee("name6", 24, true));

            var asm = Assembly.LoadFrom("ClassLibrary10.dll");
            var type = asm.GetType("ClassLibrary10.FileService`1").MakeGenericType(typeof(Employee));
            var employee = Activator.CreateInstance(type);
            var Save = type.GetMethod("SaveData");
            var Load = type.GetMethod("ReadFile");
            string file = "Test.json";

            Save.Invoke(employee, new object[] { emploees, file });
            var res = (List<Employee>)Load.Invoke(employee, new object[] { file });

            foreach (var emp in res)
                Console.WriteLine(emp.Name);
        }
    }
}
