using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab7.Entities
{
    public class Utility
    {
        public Utilities Name { get; }
        private int _consumption;
        public int Consumption { get => _consumption; }

        public Utility(Utilities name) => (Name, _consumption) = (name, 0);

        public void Using(int amount) => _consumption += amount;
    }
}

