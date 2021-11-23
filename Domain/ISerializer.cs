using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    interface ISerializer
    {
        IEnumerable<ССС> DeSerializeByLINQ(string fileName);
        IEnumerable<ССС> DeSerializeXML(string fileName);
        IEnumerable<ССС> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<ССС> xxx, string fileName);
        void SerializeXML(IEnumerable<ССС> xxx, string fileName);
        void SerializeJSON(IEnumerable<ССС> xxx, string fileName);
    }
}
