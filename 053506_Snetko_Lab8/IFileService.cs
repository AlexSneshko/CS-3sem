using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab8
{
    public interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}
