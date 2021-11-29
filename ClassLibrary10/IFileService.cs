using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary10
{
    interface IFileService<T> where T : class
    {
        IEnumerable<T> ReadFile(string fileName);
        void SaveData(IEnumerable<T> data, string fileName);
    }
}
