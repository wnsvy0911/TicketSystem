using System;
using NLog.Web;
using System.IO;


namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            var logger = NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            logger.Info("Program started");

            Console.WriteLine("Hello World!");
            string file = "Tickets.csv";
             // make sure movie file exists
            if (!File.Exists(file))
            {
                logger.Error("File does not exist: {File}", file);
            }
            else
            {
                string choice;
                do
                {
                    // display choices to user
                    Console.WriteLine("1) Read data from CSV file");
                    Console.WriteLine("2) Create file from data");
                    Console.WriteLine("Enter to quit");

                    // input selection
                    choice = Console.ReadLine();
                    logger.Info("User choice: {Choice}", choice);

                    if (choice == "1")
                    {
                        //  Read data from CSV file
                    }
                    else if (choice == "2")
                    {
                        // Create file from data
                    }
                } while (choice == "1" || choice == "2");            }


            logger.Info("Program ended");
        }
    }
}
