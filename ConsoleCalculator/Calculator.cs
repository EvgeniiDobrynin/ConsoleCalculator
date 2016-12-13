using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                calcobject = queue.Dequeue();
            else
                Operate();
            
            result = calcobject.Value;
            return result;
        }
        private void Operate()
        {
            double num1;
            double num2;
            double result;            

            while (queue.Count >= 1)
            {
                calcobject = queue.Dequeue();

                switch (calcobject.Type)
                {
                    case "Number":
                        stack.Push(calcobject);
                        break;
                    case "Operator":
                        num2 = StringToDouble(stack.Pop().Value);
                        num1 = StringToDouble(stack.Pop().Value);
                        result = Operations.operations[calcobject.Value](num1, num2);
                        stack.Push(Parser.CreateCalcObject("Number", result.ToString()));
                        break;
                    default:
                        break;
                } 
            }

            calcobject = stack.Pop();
        }
        public static double StringToDouble(string str)
        {
            return Convert.ToDouble(str);
        }
    }
}
