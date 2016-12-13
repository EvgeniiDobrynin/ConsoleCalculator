using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class CheckForFails
    {
        static string validator = Constants.validator;
        public static string GetResponse(string expression)
        {
            string response;            

            //isEmpty
            if (isEmpty(expression))
                return "0";

            //HasForbiddenSymbols
            if (HasForbiddenSymbols(expression))
                return "Введите значения: число, +, -, *, /, (, )";

            //2 operators in a row
            response = OperatorsInARow(expression);
            if (response != expression)
                return response;

            //Irregular brackets
            response = IrregularBrackets(expression);
            if (response != expression)
                return response;

            //Start with operator
            if (StartWithOperator(expression))
                return "Начните выражение с числа";

            return expression;
        }
        public static bool isEmpty(string expression)
        {
            return String.IsNullOrEmpty(expression);
        }
        private static bool HasForbiddenSymbols(string expression)
        {
            return !expression.All(c => validator.Contains(c));
        }
        private static string OperatorsInARow(string expression)
        {
            string[] operators = Operations.priority.Keys.ToArray();
            string operatorsInARow;

            for (int i = 0; i < operators.Length; i++)
            {
                for (int j = 0; j < operators.Length; j++)
                {
                    operatorsInARow = operators[i] + operators[j];

                    if (!Permitted(operatorsInARow) && expression.Contains(operatorsInARow))
                        return "У Вас есть повторяющиеся операторы " + operatorsInARow + "";
                }
            }

            return expression;
        }
        private static bool Permitted(string operatorsInARow)
        {
            if (operatorsInARow[0] == '(')
                switch (operatorsInARow[1])
                {
                    case '-':
                        return true;
                    case '(':
                        return true;
                    default:
                        return false;
                }
            else
                if (operatorsInARow[1] == '(')
                    switch (operatorsInARow[0])
                    {
                        case ')':
                            return false;
                        default:
                            return true;
                    }
                else
                    if (operatorsInARow[0] == ')')
                        switch (operatorsInARow[0])
                        {
                            case '(':
                                return false;
                            default:
                                return true;
                        }
                    else
                        if (operatorsInARow[1] == ')')
                            switch (operatorsInARow[0])
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

            switch (Operations.WhatIsLarger(openBrackets, closeBrackets))
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
    }
}
