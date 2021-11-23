using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _053506_Snetko_Lab8
{
    class FileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
                while (reader.PeekChar() > -1)
                    yield return new Employee(reader.ReadString(), reader.ReadInt32(), reader.ReadBoolean());
            }
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            using var writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate));

            foreach (var emploee in data)
            {
                writer.Write(emploee.Name);
                writer.Write(emploee.Age);
                writer.Write(emploee.WorkingStatus);
            }             
        }
    }
}
