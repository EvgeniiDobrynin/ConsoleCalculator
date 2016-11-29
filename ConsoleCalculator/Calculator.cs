using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Calculator
    {
        Queue<CalcObject> queue = new Queue<CalcObject>();
        Stack<CalcObject> stack = new Stack<CalcObject>();
        CalcObject calcobject;
        public string Calculate(string expression)
        {
            string result;
            queue = Parser.Parse(expression);

            if (queue.Count == 1)
            {
                calcobject = queue.Dequeue();
            }
            else
            {
                Operate();
            }

            result = calcobject.Value;
            return result;
        }
        private void Operate()
        {
            double a;
            double b;
            double c;            

            while (queue.Count >= 1)
            {
                calcobject = queue.Dequeue();

                if (calcobject.Type == "Number")
                {
                    stack.Push(calcobject);
                }
                else
                {
                    b = Parser.StringToDouble(stack.Pop().Value);
                    a = Parser.StringToDouble(stack.Pop().Value);
                    c = Dictionaries.operations[calcobject.Value](a, b);
                    stack.Push(Parser.CreateCalcObject("Number", c.ToString()));
                }
            }

            calcobject = stack.Pop();
        }
    }
}
