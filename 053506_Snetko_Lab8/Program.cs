using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _053506_Snetko_Lab8
{
    class Program
    {
        static void PrintList(IEnumerable<Employee> employees)
        {
            Console.WriteLine(new string('-', 20));
            foreach(var employee in employees)
                Console.WriteLine(employee);
            Console.WriteLine(new string('-', 20));
        }

        static void Main(string[] args)
        {
            var workers = new List<Employee>();
            workers.Add(new Employee("Dima", 20, false));
            workers.Add(new Employee("Vasya", 19, false));
            workers.Add(new Employee("Alex", 15, true));
            workers.Add(new Employee("Vitya", 23, true));
            workers.Add(new Employee("Katya", 24, true));
            workers.Add(new Employee("Masha", 27, true));

            var fileService = new FileService();
            var fileName = "test.txt";
            fileService.SaveData(workers, fileName);

            var newFileName = "newTest.txt";
            File.Delete(newFileName);
            File.Move(fileName, newFileName);

            var newWorkers = fileService.ReadFile(newFileName);
            newWorkers = newWorkers.OrderBy(_ => _.Name);

            PrintList(workers);
            PrintList(newWorkers);
        }
    }
}
