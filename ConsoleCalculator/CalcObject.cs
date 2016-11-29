using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class CalcObject
    {
        string type;
        string val;
        public string Type
        {
            get { return type; }
            set { value = type; }
        }
        public string Value
        {
            get { return val; }
            set { value = val; }
        }
        public CalcObject(string type, string value)
        {
            this.type = type;
            this.val = value;
        }
    }
}
