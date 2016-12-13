using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestClass]
    public class CheckForFailsTests
    {
        [TestMethod]
        public void Empty()
        {
            Assert.AreEqual(CheckForFails.GetResponse(""), "0");
        }

        [TestMethod]
        public void Letter()
        {
            Assert.AreEqual(CheckForFails.GetResponse("a2"), "Введите значения: число, +, -, *, /, (, )");
        }

        [TestMethod]
        public void NumberWithOpenBracket()
        {
            Assert.AreEqual(CheckForFails.GetResponse("(22"), "У Вас больше открывающихся скобок");
        }

        [TestMethod]
        public void NumberWithCloseBracket()
        {
            Assert.AreEqual(CheckForFails.GetResponse("22)"), "У Вас больше закрывающихся скобок");
        }

        [TestMethod]
        public void OperatorsInARow1()
        {
            Assert.AreEqual(CheckForFails.GetResponse("+*"), "У Вас есть повторяющиеся операторы +*");
        }

        [TestMethod]
        public void OperatorsInARow2()
        {
            Assert.AreEqual(CheckForFails.GetResponse(")5("), "У Вас нарушен порядок скобок");
        }

        [TestMethod]
        public void StartWithOperator()
        {
            Assert.AreEqual(CheckForFails.GetResponse("+4"), "Начните выражение с числа");
            Assert.AreEqual(CheckForFails.GetResponse("*4"), "Начните выражение с числа");
            Assert.AreEqual(CheckForFails.GetResponse("/4"), "Начните выражение с числа");
        }
    }
}
