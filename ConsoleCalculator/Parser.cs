using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Parser
    {
        private static Queue<CalcObject> result = new Queue<CalcObject>();
        private static Stack<CalcObject> notForNumbers = new Stack<CalcObject>();
        public static Queue<CalcObject> Parse(string expression)
        {
            expression = CorrectedExpression(expression);
            Determine(expression);

            while (notForNumbers.Count != 0)
                result.Enqueue(notForNumbers.Pop());

            return result;
        }
        private static string CorrectedExpression(string expression)
        {
            expression = expression.Replace(" ", "")
                .Replace(",", Constants.decimalDelimiter)
                .Replace(".", Constants.decimalDelimiter);
            return expression;
        }
        private static void Determine(string expression)
        {
            char[] charArray = expression.ToCharArray();
            char previous = '\0';
            bool previousNumber = false;
            string temp = "";
            
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsDigit(previous, charArray[i], i))
                {
                    temp += charArray[i];
                    
                    if (previous == ')')
                        OperatorHandle("*");
 
                    previous = charArray[i];
                    previousNumber = true;
                }
                else
                {
                    AddNumberToQueue(temp);
                    temp = "";

                    if (charArray[i] == '(' && previousNumber)
                        OperatorHandle("*");
                    
                    OperatorHandle(charArray[i].ToString());
                    previous = charArray[i];
                    previousNumber = false;
                }
            }

            AddNumberToQueue(temp);
        }
        private static bool IsDigit(char previous, char current, int i)
        {
            if (Char.IsDigit(current) || current == ',' || (current == '-' && (i == 0 || (i > 0 && (previous == '(' || CheckForFails.isEmpty(previous.ToString()))))))
                return true;
            else
                return false;
        }
        private static void AddNumberToQueue(string number)
        {
            if (!CheckForFails.isEmpty(number))
            {
                result.Enqueue(CreateCalcObject("Number", number));
            }
        }        
        private static void OperatorHandle(string operator_)
        {
            if (notForNumbers.Count == 0)
                notForNumbers.Push(CreateCalcObject("Operator", operator_));
            else
                OperatorsOrdering(CreateCalcObject("Operator", operator_));
        }
        private static void OperatorsOrdering(CalcObject calcObject)
        {            
            if (calcObject.Value == ")")
            {
                while (notForNumbers.Peek().Value != "(")
                    result.Enqueue(notForNumbers.Pop());

                notForNumbers.Pop();
            }
            else
            {
                while (true)
                {
                    int orderForCalcObject = Operations.priority[calcObject.Value];
                    int orderForPeekValue = Operations.priority[notForNumbers.Peek().Value];

                    if (orderForCalcObject >= orderForPeekValue || notForNumbers.Peek().Value == "(")
                    {
                        notForNumbers.Push(calcObject);
                        break;
                    }
                    else
                    {
                        result.Enqueue(notForNumbers.Pop());
                        notForNumbers.Push(calcObject);
                        break;
                    }
                }
            }
        }
        public static CalcObject CreateCalcObject(string type, string value)
            {
                return new CalcObject(type, value);
            }

     }
}
