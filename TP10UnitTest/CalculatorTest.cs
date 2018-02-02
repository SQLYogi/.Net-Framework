using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP10MatLib;


namespace TP10UnitTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestCalculatorAbs()
        {
            //Arrange
            var calc = new Calculator();
            var x = -10;

            //Act
            var y = calc.Abs(x);

            //Assert
            Assert.AreEqual(10, y);
                
                }

        [TestMethod]
        public void TestCalculatorAdd()
        {
            //Arrange 
            var calc = new Calculator();
            //Act
            var result = calc.Add(12, -5);
            //Assert
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void TestDividebyZeroException()
        {
            //Arrange 
            var calc = new Calculator();
            //Act            
            var result = calc.Divide(12, 0); //this fail cause double division doesn't throw divided by zero!!! but + Infini
            //assert
            Assert.AreEqual(result, double.PositiveInfinity);
        }


    }
}
