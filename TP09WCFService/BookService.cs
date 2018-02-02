using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TP09WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BookService : IbookService
    {
        List<Book> IbookService.GetBooks()
        {
            var books = new List<Book>() { new Book {InStock=true,Title="La fin des haricots",Authors="somebody",Description="y'en a pas!"  }
                ,new Book {InStock=true,Title="Le début des haricots",Authors="someone else",Description="y'en a pas non plus!"  }};
            return books;
        }

        
    }
}

