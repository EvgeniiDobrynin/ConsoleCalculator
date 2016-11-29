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
        public void Empty()
        {
            Assert.AreEqual(calculator.Calculate(""), "0");
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
        public void Letter()
        {
            Assert.AreEqual(calculator.Calculate("a2"), "Введите значения: число, +, -, *, /, (, )");
        }

        [TestMethod]
        public void NumberWithOpenBracket()
        {
            Assert.AreEqual(calculator.Calculate("(22"), "У Вас больше открывающихся скобок");
        }

        [TestMethod]
        public void NumberWithCloseBracket()
        {
            Assert.AreEqual(calculator.Calculate("22)"), "У Вас больше закрывающихся скобок");
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
            Assert.AreEqual(calculator.Calculate("2.2+ 3"), "5,2");
        }

        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(calculator.Calculate("2.2-3"), "-0,8");
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(calculator.Calculate("2.2*4"), "8,8");
        }
        
        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(calculator.Calculate("2.2/2"), "1,1");
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

        [TestMethod]
        public void OperatorsInARow1()
        {
            Assert.AreEqual(calculator.Calculate("+*"), "У Вас есть повторяющиеся операторы +*");
        }

        [TestMethod]
        public void OperatorsInARow2()
        {
            Assert.AreEqual(calculator.Calculate(")5("), "У Вас нарушен порядок скобок");
        }

        [TestMethod]
        public void StartWithOperator()
        {
            Assert.AreEqual(calculator.Calculate("+4"), "Начните выражение с числа");
            Assert.AreEqual(calculator.Calculate("*4"), "Начните выражение с числа");
            Assert.AreEqual(calculator.Calculate("/4"), "Начните выражение с числа");
        }
    }
}
