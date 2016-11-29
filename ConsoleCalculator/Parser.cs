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
        private static Stack<CalcObject> forOperators = new Stack<CalcObject>();
        private static string smth = "";
        private static string validator = "0123456789,+-*/()";        
        public static Queue<CalcObject> Parse(string expression)
        {
            string aftercheck;

            expression = ModifyExpression(expression);
            aftercheck = CheckForFails(expression);

            if (aftercheck != expression)
            {
                result.Enqueue(CreateCalcObject("Error", aftercheck));
            }
            else
            {
                Determine(expression);
            }

            return result;
        }
        public static double StringToDouble(string str)
        {
            return Convert.ToDouble(str);
        }
        
        #region Check for Fails
        private static string CheckForFails(string expression)
        {
            //isEmpty
            if (isEmpty(expression))
                return "0";

            //HasForbiddenSymbols
            if (HasForbiddenSymbols(expression))
                return "Введите значения: число, +, -, *, /, (, )";
            
            //2 operators in a row
            smth = OperatorsInARow(expression);
            if (smth != expression)
                return smth;
            
            //Irregular brackets
            smth = IrregularBrackets(expression);
            if (smth != expression)
                return smth;

            //Start with operator
            if (StartWithOperator(expression))
                return "Начните выражение с числа";

            return expression;
        }
        private static bool isEmpty(string expression)
        {
            return String.IsNullOrEmpty(expression);
        }
        private static bool HasForbiddenSymbols(string expression)
        {
            smth = validator;
            return !expression.All(c => smth.Contains(c));
        }
        private static string OperatorsInARow(string expression)
        {
            string[] operators = Dictionaries.priority.Keys.ToArray();

            for (int i = 0; i < operators.Length; i++)
            {
                for (int j = 0; j < operators.Length; j++)
                {
                    smth = operators[i] + operators[j];

                    if (!Permitted(smth) && expression.Contains(smth))
                        return "У Вас есть повторяющиеся операторы " + smth + "";
                }
            }

            return expression;
        }
        private static bool Permitted(string smth)
        {
            if (smth[0] == '(')
                switch (smth[1])
                {
                    case '-':
                        return true;
                    case '(':
                        return true;
                    default:
                        return false;
                }
            else
                if (smth[1] == '(')
                    switch (smth[0])
                    {
                        case ')':
                            return false;
                        default:
                            return true;
                    }
                else
                    if (smth[0] == ')')
                        switch (smth[0])
                        {
                            case '(':
                                return false;
                            default:
                                return true;
                        }
                    else
                        if (smth[1] == ')')
                            switch (smth[0])
                            {
                                case ')':
                                    return true;
                                default:
                                    return false;
                            }            
            return false;
        }
        private static string IrregularBrackets(string expression)
        {
            int openBrackets = 0;
            int closeBrackets = 0;

            openBrackets = expression.Count(c => c == '(');
            closeBrackets = expression.Count(c => c == ')');

            switch (WhatIsLarger(openBrackets, closeBrackets))
            {
                case 1:
                    return "У Вас больше открывающихся скобок";
                case 2:
                    return "У Вас больше закрывающихся скобок";
                default:
                    break;
            }

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                    openBrackets++;
                if (expression[i] == ')')
                    closeBrackets++;
                if (openBrackets < closeBrackets)
                    return "У Вас нарушен порядок скобок";
            }

            return expression;
        }
        private static bool StartWithOperator(string expression)
        {
            string smth = "+*/";

            for (int i = 0; i < smth.Length; i++)
            {
                if (expression[0] == smth[i])
                    return true;
            }

            return false;
        }

        #endregion
        private static int WhatIsLarger(int a, int b)
        {
            if (a > b)
                return 1;
            if (a < b)
                return 2;
            else
                return 0;
        }
        private static string ModifyExpression(string expression)
        {
            expression = expression.Replace(".", ",");
            expression = expression.Replace(" ", "");
            return expression;
        }
        
        #region Determine
        private static void Determine(string expression)
        {
            char[] charArray = expression.ToCharArray();
            char previous = '\0';
            bool previousNumber = false;
            smth = "";
            
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsDigit(previous, charArray[i], i))
                {
                    smth += charArray[i];
                    
                    if (previous == ')')
                        OperatorHandle("*");
 
                    previous = charArray[i];
                    previousNumber = true;
                }
                else
                {
                    AddSmthToQueue();

                    if (charArray[i] == '(' && previousNumber)
                    {
                        OperatorHandle("*");
                    }

                    OperatorHandle(charArray[i].ToString());
                    previous = charArray[i];
                    previousNumber = false;
                }
            }

            AddSmthToQueue();
            Array.Clear(charArray, 0, expression.Length);
            while (forOperators.Count != 0)
            result.Enqueue(forOperators.Pop());
        }
        private static bool IsDigit(char previous, char current, int i)
        {
            if (Char.IsDigit(current) || current == ',' || (current == '-' && (i == 0 || (i > 0 && (previous == '(' || isEmpty(previous.ToString()))))))
                return true;
            else
                return false;
        }
        private static void AddSmthToQueue()
        {
            if (!isEmpty(smth))
            {
                result.Enqueue(CreateCalcObject("Number", smth));
                smth = "";
            }
        }        
        private static void OperatorHandle(string str)
        {
            if (forOperators.Count == 0)
                forOperators.Push(CreateCalcObject("Operator", str));
            else
                OperatorsOrdering(CreateCalcObject("Operator", str));
        }
        private static void OperatorsOrdering(CalcObject calcObject)
        {            
            if (calcObject.Value == ")")
            {
                while (forOperators.Peek().Value != "(")
                {
                    result.Enqueue(forOperators.Pop());
                }

                forOperators.Pop();
            }
            else
            {
                while (true)
                {
                    int a = Dictionaries.priority[calcObject.Value];
                    int b = Dictionaries.priority[forOperators.Peek().Value];

                    if (a >= b || forOperators.Peek().Value == "(")
                    {
                        forOperators.Push(calcObject);
                        break;
                    }
                    else
                    {
                        result.Enqueue(forOperators.Pop());
                        forOperators.Push(calcObject);
                        break;
                    }
                }
            }
        }
        
        #endregion
        public static CalcObject CreateCalcObject(string type, string value)
            {
                return new CalcObject(type, value);
            }

     }
}
