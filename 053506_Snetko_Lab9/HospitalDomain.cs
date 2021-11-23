using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab9
{
    [Serializable]
    public class HospitalDomain
    {
        public string Name { get; set; }
        public HRDepartment Department { get; set; }

        public HospitalDomain() { }
        public HospitalDomain(string name, HRDepartment department) => (Name, Department) = (name, department);

        public override string ToString() => $"Hospital: {Name}\n\t{Department}";
    }
}
