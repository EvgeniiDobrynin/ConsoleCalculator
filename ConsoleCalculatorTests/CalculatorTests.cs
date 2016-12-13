using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {        
        Calculator calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            calculator = new Calculator();
        }        

        [TestMethod]
        public void Number1()
        {
            Assert.AreEqual(calculator.Calculate("1"), "1");
        }

        [TestMethod]
        public void Number2()
        {
            Assert.AreEqual(calculator.Calculate("22"), "22");
        }

        [TestMethod]
        public void SumWithCommaDelimiter()
        {
            Assert.AreEqual(calculator.Calculate("2,2+3"), "5,2");
        }

        [TestMethod]
        public void SumWithPointDelimiter()
        {
            Assert.AreEqual(calculator.Calculate("2.2+3"), "5,2");
        }

        [TestMethod]
        public void SumWithSpaces()
        {
            Assert.AreEqual(calculator.Calculate("2,2+ 3"), "5,2");
        }
 
        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(calculator.Calculate("2,2-3"), "-0,8");
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(calculator.Calculate("2,2*4"), "8,8");
        }
        
        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(calculator.Calculate("2,2/2"), "1,1");
        }

        [TestMethod]
        public void StartWithNegativeNumber()
        {
            Assert.AreEqual(calculator.Calculate("-2+3"), "1");
        }

        [TestMethod]
        public void ExpressionWith2Operations()
        {
            Assert.AreEqual(calculator.Calculate("2+3*4"), "14");
        }        
        
        [TestMethod]
        public void NumberInBrackets()
        {
            Assert.AreEqual(calculator.Calculate("(5)"), "5");
        }

        [TestMethod]
        public void NegativeNumberInBrackets()
        {
            Assert.AreEqual(calculator.Calculate("(-5)"), "-5");
        }
 
        [TestMethod]
        public void SuperExpression()
        {
            Assert.AreEqual(calculator.Calculate("-5*2+((3+2)+(7-2)*8)/(7-(-2))"), "-5");
        }

        [TestMethod]
        public void MultipleBrackets()
        {
            Assert.AreEqual(calculator.Calculate("2(2)3"), "12");
        }
    }
}
