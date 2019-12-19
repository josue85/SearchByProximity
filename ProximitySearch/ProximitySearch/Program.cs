using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    class Program
    {
        //I don't like magic numbers in code, so I'm creating an enum that corresponds to where I expect the arguments to be passed in for readability.
        //I would also think about supporting named arguments so that order wasn't important
        enum ArgumentIndex
        {
            //The number corresponds to the expected order the arguments will be passed in
            Keyword1 = 0,  Keyword2 = 1, Range = 2, FileName = 3
        }

        enum ExitCodes
        {
            ExpectedExit = 0,
            InvalidArgument = 1,
            FileDoesNotExist = 2
        }

        static void Main(string[] args)
        {
            ProximitySearch proxSearch = null;
            string keyword1 = String.Empty;
            string keyword2 = String.Empty;
            int range = 0;
            string fileName = String.Empty;

            //Use the Console Interaction in this case. We can easily use a different writer as needs dictate
            ConsoleInteraction messageWriter = new ConsoleInteraction();

            //Get the number of expected arguments.
            int expectedArgsCount = Enum.GetValues(typeof(ArgumentIndex)).Length;

            //Read passed in command line parameters, expected format: <keyword1> <keyword2> <range> <input_filename>
            if (args.Length < expectedArgsCount || args.Length > expectedArgsCount)
            {
                messageWriter.Message("The passed in arguments are not in a recognized format. Expected format is <keyword1> <keyword2> <range> <input_filename>");
            }
            else
            {
                proxSearch = new ProximitySearch();
                keyword1 = args[(int)ArgumentIndex.Keyword1].Trim();
                keyword2 = args[(int) ArgumentIndex.Keyword2].Trim();

                //Verify we have an int passed in for range, and that it is greater than 2
                if (!IsValidIntArgument(args[(int) ArgumentIndex.Range], "range", messageWriter, out range) || range < 2)
                {
                    //Invalid argument, quit out
                    System.Environment.Exit((int)ExitCodes.InvalidArgument);
                }

                fileName = args[(int)ArgumentIndex.FileName].Trim();
            }

            try
            {
                messageWriter.Message(proxSearch.FindProximityCount(keyword1, keyword2, range, fileName).ToString());
            }
            catch (Exception e)
            {
                messageWriter.Message($"The application encounterd an error while processing. More Info: {e.Message}");
            }

            Console.ReadKey();
        }


        private static bool IsValidIntArgument(string paramValue, string paramName, UserInteraction messageHandler, out int number)
        {
            if (!Int32.TryParse(paramValue, out number))
            {
                messageHandler.Message($"Invalid parameter ({paramName}) supplied. Failed to parse an integer from the value: {paramValue}");
                return false;
            }

            return true;
        }
    }
}
