using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP10MatLib
{
    public class Calculator
    {
        public double Abs(double x) => x<0?-x:x;
        public double Add(double x, double y) => x + y;
        public double Substract(double x, double y) => x - y;
        public double Divide(double x, double y) => x / y;
        public int DivideInt(int x, int y) => x / y;
        public double DivideWithContract(double x, double y)
        {
            Contract.Assert(y != 0.0, "For division, y must not be 0!");          
            return x / y;
        }
    }
}
