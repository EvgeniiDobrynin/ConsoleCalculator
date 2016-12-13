using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class InterfaceLayer
    {
        public string expression;
        public void Calculate()
        {
            string response;
            Calculator calculator = new Calculator();
            SpecialCommand specialCommand = new SpecialCommand();

            PrintHelpInformation();

            while (true)
            {
                ScanExpression();
                response = specialCommand.GetResponse(expression);

                if (response == "exit")
                    break;
                else
                    if (expression != response)
                        PrintResponse(response);
                    else
                    {
                        response = CheckForFails.GetResponse(expression);

                        if (expression != response)
                            PrintResponse(response);
                        else
                            PrintResult(calculator.Calculate(expression));
                    }
            }

            ExitMessage();
        }

        virtual protected void CompareAndPrintResponse(string expression, string response)
        {

        }
        virtual protected void PrintHelpInformation()
        {

        }
        virtual protected void ScanExpression()
        {

        }
        virtual protected void PrintResponse(string response)
        {

        }
        virtual protected void PrintResult(string result)
        {

        }
        virtual protected void ExitMessage()
        {

        }
    }
}
