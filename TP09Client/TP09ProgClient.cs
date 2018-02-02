using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TP09Client.BookService;
using System.ServiceModel;

namespace TP09Client
{
    class TP09ProgClient
    {
        static void Main(string[] args)
        {
            IbookServiceClient client = new IbookServiceClient();
            List<Book> books = client.GetBooks().ToList();
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Title}");

            }
            Console.ReadKey();
        }
    }
}
