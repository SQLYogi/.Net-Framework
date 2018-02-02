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
            
            var text = File.ReadAllText("SomeText.txt");

            //\b pour word boundary,commence par w, groupe sur les caractères suivants 1 ou plusieurs            
            var pattern = @"\bw(\w+)";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            
            //Pour chaque matching occurrences            
            foreach (Match m in reg.Matches(text))
            {
                WriteLine($"Found {m.Value} at {m.Index}");                
            }
            //on remplace toutes les occurences par X+groupe 1
            var newtext = reg.Replace(text, "X$1");
            File.WriteAllText("Newtext.txt",newtext);
            WriteLine(newtext);

           
            ReadKey();
        }
    }
}
