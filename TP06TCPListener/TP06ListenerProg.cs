using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TP06TCPListener
{
    class TP06ListenerProg
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting echo server...");

            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Loopback;
            TcpListener listener = new TcpListener(localAdd, 8888);
            Console.WriteLine("Listening...");
            listener.Start();

            while (true)
            {
                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();
               
                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //---write back the text to the client---
                Console.WriteLine("Sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
                client.Close();
                if (dataReceived == "q")
                    break;


            }
            listener.Stop();
        }
    }
}
