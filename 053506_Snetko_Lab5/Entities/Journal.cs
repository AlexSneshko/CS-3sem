using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab5.Entities
{
    public class Journal
    {
        private List<string> changes;

        public Journal() => changes = new List<string>();

        public void Add(string message) => changes.Add(message);

        public void GetAllChanges()
        {
            var sticks = new string('-', 15);
            Console.WriteLine($"{sticks}Journal{sticks}");
            foreach (var change in changes)
                Console.WriteLine(change);
            Console.WriteLine($"{sticks}{sticks}");
        }
    }
}
