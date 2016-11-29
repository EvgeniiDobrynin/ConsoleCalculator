using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression;
            Calculator calculator = new Calculator();
            Console.WriteLine("Для выхода из калькулятора введите exit");

            while (true)
            {
                Console.Write("Введите значение: ");
                expression = Console.ReadLine();
                if (expression != "exit")
                {
                    Console.WriteLine(calculator.Calculate(expression));
                }
                else break;
            }

            Console.WriteLine("Спасибо, что использовали мой калькулятор");
        }
    }
}
