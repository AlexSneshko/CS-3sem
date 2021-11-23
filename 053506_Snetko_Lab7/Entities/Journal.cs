using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab7.Entities
{
    public delegate void Print();

    public class Journal
    {
        public string Name { get; }
        public event Print Changes;

        public Journal(string name) => Name = name;

        public void GetAllChanges()
        {
            var sticks = new string('-', 15);
            Console.WriteLine($"{sticks}{Name}{sticks}");
            Changes();
            Console.WriteLine($"{sticks}{sticks}");
        }
    }
}
