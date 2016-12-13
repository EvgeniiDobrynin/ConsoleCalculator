using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class ConsoleInterfaceLayer : InterfaceLayer
    {
        override protected void CompareAndPrintResponse(string expression, string response)
        {
            if (expression != response)
                Console.WriteLine(response);
        }
        override protected void PrintHelpInformation()
        {
            Console.WriteLine("Для вызова справки введите help");
            Console.WriteLine("Для выхода из калькулятора введите exit");
        }
        override protected void ScanExpression()
        {
            Console.Write("Введите значение: ");
            expression = Console.ReadLine();
        }
        override protected void PrintResponse(string response)
        {
            Console.WriteLine(response);
        }
        override protected void PrintResult(string result)
        {
            Console.WriteLine("Результат: " + result);
        }
        override protected void ExitMessage()
        {
            Console.WriteLine("Спасибо, что использовали мой калькулятор");
        }
    }
}
