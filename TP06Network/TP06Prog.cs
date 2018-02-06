using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace TP06Network
{
    class TP06Prog
    {
        const string URL = "http://stackoverflow.com";

        static void Main(string[] args)
        {
            string strHostName = "";
            strHostName = Dns.GetHostName(); //Retrouve le nom de la machine
            WriteLine($"Host Name:{strHostName}");
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
          
            foreach (var a in addr)
            {
                WriteLine(a);
            }
            //Télécharge la page
            DownloadWebPage(URL);
            //Télécharge la page de manière asynchrone
            DownloadWebPageAsync(URL);
            WriteLine("Async method launched....");

            WriteLine("Press any key to quit...");
            ReadKey();
        }

        private static void DownloadWebPage(string url)
        {
            using (WebClient wb = new WebClient())
            {
                wb.DownloadFile(url, $"{url.Remove(0,7)}.html");
            }
        }

        private static void DownloadWebPageAsync(string url)
        {
            using (WebClient wb = new WebClient())
            {
                WriteLine($"downloading {url}");
                wb.DownloadFileCompleted += Wb_DownloadFileCompleted;
                wb.DownloadFileAsync(new Uri(url), $"{url.Remove(0, 7)}Async.html");                    
            }

        }

        private static void Wb_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {            
            WriteLine($"Async download completed... {sender.GetType()}");
        }

  


    }
}
