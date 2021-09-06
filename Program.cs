using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        //This progrma is used to track sleep data
        //TODO: add in loop to go through program repeatedly 
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
                // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());
                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataStartDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();
                // create file
                StreamWriter sw = new StreamWriter("data.txt");

                // loop for the desired # of weeks
                while (dataStartDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataStartDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataStartDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataStartDate = dataStartDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                /*
                FORMAT NOTES
                Day of week = spacing of 3, right align
                Tot and Avg = spacing of 4, right align
                Avg = float, .0 precision
                All others = whole integers
                1 break line between each week
                Week of... is unformatted
                Date is (MMM, dd, yyyy)
                */

                //Open file to read
                StreamReader sr = new StreamReader("data.txt");
                //Begin a print loop. 
                //For each line in the file..
                while(!sr.EndOfStream){
                    //The splitting characters
                    char[] separators = {',','|'};
                    //Create an array of the split string
                    string[] sleepLine = sr.ReadLine().Split(separators);
                    DateTime date = DateTime.Parse(sleepLine[0]);
                    //The sum and average of sleep hours
                    int sum = 0;
                    double avg;
                    //Calculate the sum
                    for (int i = 1; i < sleepLine.Length; i++){
                        sum += Int32.Parse(sleepLine[i]);
                    }
                    //Calculate the average
                    avg = sum / 7.0;
                    //Print the Week of ...
                    Console.WriteLine($"Week of {date:MMM, dd, yyyy}");
                    //Print the Mo, Tu, Wed, etc... to Tot, Avg
                    Console.WriteLine($"{"Mo",3}{"Tu",3}{"We",3}{"Th",3}{"Fr",3}{"Sa",3}{"Su",3}{"Tot",4}{"Avg", 4}");
                    Console.WriteLine($"{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"---",4}{"---",4}");
                    Console.WriteLine($"{sleepLine[1],3}{sleepLine[2],3}{sleepLine[3],3}{sleepLine[4],3}{sleepLine[5],3}{sleepLine[6],3}{sleepLine[7],3}{sum,4}{avg,4:n1}");
                    //Print the -- separators
                    //Print the sleep hours, the total hours, and the average hours (.1 decimal place)
                    //Print a break line         
                    Console.WriteLine();           
                }

                
            }
        }
    }
}
