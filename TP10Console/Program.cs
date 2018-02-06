using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TP10MatLib;
using static System.Console;

namespace TP10Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            WriteLine(calc.DivideWithContract(10, 0.0));
            WriteLine("Press any key to quit...");
            ReadKey();
        }
    }
}
