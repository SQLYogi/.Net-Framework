using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;


namespace TP01Configuration
{
    public class TP01Prog
    {

        
        static void Main(string[] args)
        {
            var settings = TP01Settings.Default;            
            WriteLine($"Your Favorite Color is {settings.FavoriteColor}\nEnter a new color:");           
            settings.FavoriteColor = ReadLine();
            settings.Save();
            WriteLine("press any key to quit");
            ReadKey();
            
        }

        public string GetUserFavoriteColor() => $"The favorite Color is: {TP01Settings.Default.FavoriteColor}";
    }
}
