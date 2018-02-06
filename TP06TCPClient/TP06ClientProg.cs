using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net;
using TP06TCPClient.Properties;

namespace TP06TCPClient
{
    class TP06ClientProg
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting echo client...");

            //Boucle infinie, jusqu'à ce que l'utilisateur entre "q"
            while (true)
            {
                //Crée un TCPCLient sur un port disponible (0 pour le port automatique)    
                TcpClient client = new TcpClient(new IPEndPoint(IPAddress.Loopback, 0));

                Console.Write("Enter data to send (q to exit):");
                //Les données à envoyer au server
                string textToSend = Console.ReadLine();
                //Se connecte au server
                client.Connect(new IPEndPoint(IPAddress.Loopback, Settings.Default.ServerPort));
                //Crée un stream de données
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                //Envoie les données au server           
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //Lit sur le stream réseau le retour du serveur
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Echo is : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));        
                
                //Cleaning
                client.Close();
                nwStream.Close();
                //Exit if q
                if (textToSend == "q")
                    break;
            }
        }
    }
}
