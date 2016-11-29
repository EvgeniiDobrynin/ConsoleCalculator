using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public static class Dictionaries
    {
        public static readonly Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
        {
            {"+", new Func<double,double,double>(Functions.Sum)},
            {"-", new Func<double,double,double>(Functions.Subtract)},
            {"*", new Func<double,double,double>(Functions.Multiply)},
            {"/", new Func<double,double,double>(Functions.Divide)}
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
    }
}
