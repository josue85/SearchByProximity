using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    //
    class ConsoleInteraction : UserInteraction
    {
        public void Message(string message, ConsoleColor consoleForegroundColor = ConsoleColor.Green, ConsoleColor consoleBackgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = consoleForegroundColor;
            Console.BackgroundColor = consoleBackgroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
