using System;
using System.Collections.Generic;

namespace _053506_Snetko_Lab9
{
    class Program
    {
        static void PrintList(IEnumerable<HospitalDomain> hospitals, string name)
        {
            var sticks = new string('-', 20);
            Console.WriteLine(sticks + name + sticks);
            foreach (var hospital in hospitals)
                Console.WriteLine(hospital);
            Console.WriteLine(sticks + sticks);
        }

        static void Main(string[] args)
        {
            var serializer = new Serializer();
            var fileLINQ = "XMLByLINQ.xml";
            var fileXML = "XML.xml";
            var fileJSON = "JSON.json";

            var hospitals = new List<HospitalDomain>();
            hospitals.Add(new HospitalDomain("hospital1", new HRDepartment("department1", 10)));
            hospitals.Add(new HospitalDomain("hospital2", new HRDepartment("department2", 4)));
            hospitals.Add(new HospitalDomain("hospital3", new HRDepartment("department3", 6)));
            hospitals.Add(new HospitalDomain("hospital4", new HRDepartment("department4", 2)));
            hospitals.Add(new HospitalDomain("hospital5", new HRDepartment("department5", 3)));
            hospitals.Add(new HospitalDomain("hospital6", new HRDepartment("department6", 8)));

            serializer.SerializeByLINQ(hospitals, fileLINQ);
            PrintList(serializer.DeSerializeByLINQ(fileLINQ), "XMLByLINQ");

            serializer.SerializeXML(hospitals, fileXML);
            PrintList(serializer.DeSerializeXML(fileXML), "XML");

            serializer.SerializeJSON(hospitals, fileJSON);
            PrintList(serializer.DeSerializeJSON(fileJSON), "JSON");
        }
    }
}
