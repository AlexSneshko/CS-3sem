using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab9
{
    interface ISerializer
    {
        IEnumerable<HospitalDomain> DeSerializeByLINQ(string fileName);
        IEnumerable<HospitalDomain> DeSerializeXML(string fileName);
        IEnumerable<HospitalDomain> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<HospitalDomain> cuisine, string fileName);
        void SerializeXML(IEnumerable<HospitalDomain> cuisine, string fileName);
        void SerializeJSON(IEnumerable<HospitalDomain> cuisine, string fileName);
    }
}
