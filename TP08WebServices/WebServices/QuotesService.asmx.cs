using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace TP08WebServices.WebServices
{
    /// <summary>
    /// Summary description for QuotesService
    /// </summary>
    [WebService(Namespace = "http://Digicomp/2016/06/QuoteService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class QuotesService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
                public List<Person> GetPersons()
        {
            return new List<Person>() { new Person { Id = 1, FirstName="Nicolas",LastName="bonin" },new Person { Id = 2, FirstName = "Nicolasas", LastName = "boninni" } };
            
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPersonsJson()
        {
            var persons = new List<Person>() { new Person { Id = 1, FirstName = "Nicolas", LastName = "bonin" }, new Person { Id = 2, FirstName = "Nicolasas", LastName = "boninni" } };
            return new JavaScriptSerializer().Serialize(persons);
        }

    }

    public class Person
    { public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    

}
