using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab9
{
    [Serializable]
    public class HRDepartment
    {
        public string Name { get; set; }
        public int AmountOfEmploee { get; set; }    

        public HRDepartment() { }
        public HRDepartment(string name, int amountOfEmploee) => (Name, AmountOfEmploee) = (name, amountOfEmploee);

        public override string ToString() => $"Department: {Name}, amaount of emploee: {AmountOfEmploee}";
    }
}
