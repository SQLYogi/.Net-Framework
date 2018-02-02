using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;



namespace TP11SysManagement
{
    class TP11Prog
    {
        static void Main(string[] args)
        {
            //Méthode 1
            // SelectQuery selectQuery = new  SelectQuery("Win32_LogicalDisk");
            // ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            //Méthode 2
            //WqlObjectQuery wqlQuery = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk");

            //Sample queries
            //SELECT * FROM Win32_LogicalDisk
            //Select* From Win32_Process
            //Select * From Win32_Service 
            WqlObjectQuery wqlQuery = new WqlObjectQuery("SELECT  * FROM Win32_Process");
            ManagementObjectSearcher searcher =new ManagementObjectSearcher(wqlQuery);

            //itération sur les objet trouvés
            foreach (ManagementObject item in searcher.Get())
            {
                Console.WriteLine(item.ToString());
                
                //itération sur les propriétés
                foreach (var property in item.Properties)
                {
                    Console.WriteLine($"\t\t{property.Name}:{property.Value}");
                }
            }



           


            Console.ReadKey();
            

        }
    }
}
