using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static System.Console;

namespace TP12Regex
{
    class TP12Prog
    {
        static void Main(string[] args)
        {
            var password = "";
            var MoreThan8Caracters = new Regex(@"\w{8,}");
            var MoreThan2UpperCase = new Regex(@"[A-Z]");
            var MoreThan2ConsecutiveLowerCase = new Regex(@"[a-z]{2,}");
            var HasDigits = new Regex(@"\d");
            var HasSpecialCaracters = new Regex(@"\W");
            var NoSpace = new Regex(@"\s");
            do
            {
                WriteLine("Please enter a Strong password (or q to Exit)");
                password = ReadLine();
                //Vérifie qu'il y a plus de 8 caractères
                if (MoreThan8Caracters.IsMatch(password))
                    WriteLine("OK - More than 8 caracters");
                else WriteLine("NOT OK - Less than 8 caracters");

                //Vérifie qu'il y a plus de 2 Majsucules
                if (MoreThan2UpperCase.Matches(password).Count>1)
                    WriteLine("OK - More than 2 Majuscules");
                else WriteLine("NOT OK - Less than 2 Majuscules");

                //Vérifie qu'il y a plus de 2 Minuscules consécutives
                if (MoreThan2ConsecutiveLowerCase.IsMatch(password))
                    WriteLine("OK - More than 2 consecutive minuscules");
                else WriteLine("NOT OK - Less than 2 consecutive minuscules");

                //Vérifie qu'il y a plus de 2 Majsucules
                if (HasDigits.Matches(password).Count > 1)
                    WriteLine("OK - More than 2 Digits");
                else WriteLine("NOT OK - Less than 2 Digits");

                //Vérifie qu'il y a des caractères spéciaux
                if (HasSpecialCaracters.IsMatch(password))
                    WriteLine("OK - Has a special caracter");
                else WriteLine("NOT OK - Has no special caracter");

                //Vérifie qu'il n'y a pas d'espace
                if (!NoSpace.IsMatch(password))
                    WriteLine("OK - there's no space");
                else WriteLine("NOT OK - there's a space");
            }
            while (password.ToLower()!="q");

           
            
        }
    }
}
