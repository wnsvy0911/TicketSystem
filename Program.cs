using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

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
                // create parallel lists of movie details
                // lists are used since we do not know number of lines of data
                List<UInt64> TicketIds = new List<UInt64>();
                List<string> Summary = new List<string>();
                List<string> Status = new List<string>();
                List<string> Priority = new List<string>();
                List<string> Submitter = new List<string>();
                List<string> Assigned = new List<string>();
                List<string> Watching = new List<string>();
                 // to populate the lists with data, read from the data file
                try
                {
                    StreamReader sr = new StreamReader(file);
                    // first line contains column headers
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }


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
