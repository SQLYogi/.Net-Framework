using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
namespace TP05Linq2XML
{
    class TP05Prog
    {
        static void Main(string[] args)
        {
            //Charge un fichier Xml
            XElement root = XElement.Load("data.xml");

            var students = from s in root.Descendants()
                          // where s.Attribute("firstname").Value.Contains("Nico")
                          // orderby s.Attribute("lastname").Value descending
                           select new Student() { FirstName = s.Attribute("firstname").Value,LastName= s.Attribute("lastname").Value}; //.Attribute("firstname").Value;
                           
            foreach (var s in students)
                Console.WriteLine($"{s}");
            Console.ReadKey();
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
