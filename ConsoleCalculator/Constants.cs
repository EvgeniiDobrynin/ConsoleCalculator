using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public static class Constants
    {
        public static readonly string decimalDelimiter = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public static readonly string operations = Operations.operations.Select(k => k.Key).Aggregate((current, next) => current + next);
        public static readonly string validator = "0123456789.,()" + operations;
        
        public static readonly Dictionary<string, string> specialCommands = new Dictionary<string, string>()
        {
            {"exit", "exit"},
            {"help", "Введите выражение или exit для выхода"}
        };
    }
}
