using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TP06TCPListener.Properties;

namespace TP06TCPListener
{
    class TP06ListenerProg
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting echo server...");
      
            //Créé un TCP Listener sur l'adress locale et port 8888
            TcpListener listener = new TcpListener(IPAddress.Loopback,Settings.Default.Port);
            Console.WriteLine("Listening...");
            //Démarre le listener
            listener.Start();

            //Boucle infinie, jusqu'à ce que l'on recoive entre "q"
            while (true)
            {
                //Attend une connection client
                TcpClient client = listener.AcceptTcpClient();
               
                //Recupère le stream de données
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //Lit les données et les mets dans un buffer
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---converti les données en String
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //Ecrit les données sur le stream pour les renvoyer au Client
                Console.WriteLine("Sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
                //Ferme la connection et le stream
                client.Close();
                nwStream.Close();

                if (dataReceived == "q")
                    break;


            }
            listener.Stop();            
        }
    }
}
