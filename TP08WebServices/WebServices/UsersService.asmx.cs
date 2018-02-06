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
    /// Summary description for UsersService
    /// </summary>
    [WebService(Namespace = "http://Digicomp/2018/02/UsersService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UsersService : System.Web.Services.WebService
    {
        //Crée le DBContext permettant d'accéder à notre DB
        LocalDbEntities dbContext = new LocalDbEntities();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
       public List<User> GetPersons()
        {
            return dbContext.Users.ToList();                        
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPersonsJson()
        {
        
            return new JavaScriptSerializer().Serialize(dbContext.Users.ToList());
        }

    }


}
