using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ServiceModel;
using TP09WCFService;

namespace TP09Host
{
    class TP09ProgHost
    {
        static void Main(string[] args)
        {

            using (ServiceHost svcHost = new ServiceHost(typeof(BookService)))
            {
                svcHost.Open();
                Console.WriteLine($"Book Service is listening on {svcHost.BaseAddresses[0]}");
                Console.ReadKey();
            }
            
           
        }
    }
}
