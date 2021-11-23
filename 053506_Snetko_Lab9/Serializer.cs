using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _053506_Snetko_Lab9
{
    class Serializer : ISerializer
    {
        public void SerializeByLINQ(IEnumerable<HospitalDomain> hospitals, string fileName)
        {
            XDocument document = new XDocument();
            var allHospitals = new XElement("Hospitals");
            foreach (var hospital in hospitals)
            {
                var xHospital = new XElement("Hospital");
                xHospital.Add(new XAttribute("Name", hospital.Name));
                var xDepartment = new XElement("Department");
                xDepartment.Add(new XElement("Name", hospital.Department.Name));
                xDepartment.Add(new XElement("AmountOfEmploee", hospital.Department.AmountOfEmploee));
                xHospital.Add(xDepartment);
                allHospitals.Add(xHospital);
            }
            document.Add(allHospitals);
            document.Save(fileName);
        }

        public IEnumerable<HospitalDomain> DeSerializeByLINQ(string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);
            var hospitals = new List<HospitalDomain>();
            var a = xdoc.Element("Hospitals").Elements("Hospital");

            foreach (var xHospital in xdoc.Element("Hospitals").Elements("Hospital"))
            {
                var xDepartment = xHospital.Element("Department");
                hospitals.Add(new HospitalDomain(xHospital.Attribute("Name").Value, new HRDepartment(xDepartment.Element("Name").Value, int.Parse(xDepartment.Element("AmountOfEmploee").Value))));
            }
            return hospitals;
        }

        public void SerializeXML(IEnumerable<HospitalDomain> hospitals, string fileName)
        {
            var formatter = new XmlSerializer(typeof(List<HospitalDomain>));
            using var file = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(file, hospitals);
        }

        public IEnumerable<HospitalDomain> DeSerializeXML(string fileName)
        {
            var formatter = new XmlSerializer(typeof(List<HospitalDomain>));
            using var file = new FileStream(fileName, FileMode.Open);
            return (List<HospitalDomain>)formatter.Deserialize(file);
        }

        public IEnumerable<HospitalDomain> DeSerializeJSON(string fileName) => JsonSerializer.Deserialize<IEnumerable<HospitalDomain>>(File.ReadAllText(fileName));

        public void SerializeJSON(IEnumerable<HospitalDomain> hospitals, string fileName) => File.WriteAllText(fileName, JsonSerializer.Serialize(hospitals));
    }
}
