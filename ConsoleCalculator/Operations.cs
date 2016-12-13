using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Operations
    {
        public static readonly Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
        {
            {"+", new Func<double,double,double>(Sum)},
            {"-", new Func<double,double,double>(Subtract)},
            {"*", new Func<double,double,double>(Multiply)},
            {"/", new Func<double,double,double>(Divide)}
        };

        public static readonly Dictionary<string, int> priority = new Dictionary<string, int>()
        {
            {"+", 1},
            {"-", 1},
            {"*", 2},
            {"/", 2},
            {"(", 3},
            {")", 3}
        };
        public static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
        public static int WhatIsLarger(int num1, int num2)
        {
            if (num1 > num2)
                return 1;
            if (num1 < num2)
                return 2;
            else
                return 0;
        }
    }
}
