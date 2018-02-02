using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace TP06TCPClient
{
    class TP06ClientProg
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting echo client...");

            int port = 8888;
            
                                  

            while (true)
            {

                //---create a TCPClient object at the IP and port no.---
                TcpClient client = new TcpClient("localhost", 8888);               

                Console.Write("Enter data to send (q to exit):");
                //---get data to send to the server---
                string textToSend = Console.ReadLine();

                //Use a stream to write on the network
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                //---send the text---                
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Echo is : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));                
                client.Close();
                //Exit if q
                if (textToSend == "q")
                    break;
            }
        }
    }
}
