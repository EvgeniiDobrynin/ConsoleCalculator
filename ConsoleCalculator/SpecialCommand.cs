using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class SpecialCommand
    {
        string response;
        public string GetResponse(string request)
        {
            try
            {
                response = Constants.specialCommands[request];
            }
            catch
            {
                return request;
            }
            return response;
        }
    }
}
