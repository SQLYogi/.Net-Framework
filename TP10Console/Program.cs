using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP10MatLib;

namespace TP10Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine(calc.DivideWithContract(10, 0.0));
            Console.ReadKey();
        }
    }
}
