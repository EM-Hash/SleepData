using System;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                // TODO: create data file
                //Message to show it's working (TO DELETE)
                Console.WriteLine("You entered 1");
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                //Message to show it's working (TO DELETE)
                Console.WriteLine("You entered 2");

            }
            //Message to show it's working (TO DELETE)
            Console.WriteLine("Good bye!");
        }
    }
}
