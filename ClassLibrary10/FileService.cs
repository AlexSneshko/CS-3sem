using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClassLibrary10
{
    class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName) => JsonSerializer.Deserialize<IEnumerable<T>>(File.ReadAllText(fileName));
            
        public void SaveData(IEnumerable<T> data, string fileName) => File.WriteAllText(fileName, JsonSerializer.Serialize(data));
    }
}
