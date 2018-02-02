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
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            // ipLabel.Text = addr[addr.Length - 2].ToString();
            foreach (var a in addr)
            {
                WriteLine(a);
            }
           // WebClientSample();
            AsynchroniousWebClientSample();
            WriteLine("Async method launched....");

            ReadKey();
        }

        private static void WebClientSample()
        {
            using (WebClient wb = new WebClient())
            {
                WriteLine("downloading google...");
                //wb.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";                              
            
                string html = wb.DownloadString(URL);
                File.WriteAllText("WebClientSample.txt", html);
                WriteLine("Result written in WebClientSample.txt");
                              
            }

        }

        private static void AsynchroniousWebClientSample()
        {
            using (WebClient wb = new WebClient())
            {
                WriteLine("downloading yahoo Async...");
                wb.DownloadStringCompleted += Wb_DownloadStringCompleted;
                wb.DownloadStringAsync(new Uri(URL));
                /*Task<string> task = new Task<string>(()=>wb.DownloadString(URL));
                task.Start();
                task.Wait();
                WriteLine(task.Result);
                */

            }

        }
      
        private static void Wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            File.WriteAllText("AsynchroniousWebClientSample.txt", e.Result);
            WriteLine("Result written in AsynchroniousWebClientSample.txt");
           
        }


    }
}
