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

            Console.WriteLine("TicketSystem");
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
                        // first look for quote(") in string
                        // this indicates a comma(,) in movie title
                        int idx = line.IndexOf('"');
                        if (idx == -1)
                        {
                            // no quote = no comma in movie title
                            // movie details are separated with comma(,)
                            string[] ticketDetails = line.Split(',');
                            // 1st array element contains movie id
                            TicketIds.Add(UInt64.Parse(ticketDetails[0]));
                            // 2nd array element contains movie title
                            Summary.Add(ticketDetails[1]);
                            // 3rd array element contains movie genre(s)
                            // replace "|" with ", "
                            Status.Add(ticketDetails[2].Replace("|", ", "));
                            Priority.Add(ticketDetails[3].Replace("|", ", "));
                            Submitter.Add(ticketDetails[4].Replace("|", ", "));
                            Assigned.Add(ticketDetails[5].Replace("|", ", "));
                            Watching.Add(ticketDetails[6].Replace("|", ", "));
                        }
                        else
                        {
                            // quote = comma in movie title
                            // extract the movieId
                            TicketIds.Add(UInt64.Parse(line.Substring(0, idx - 1)));
                            // remove movieId and first quote from string
                            line = line.Substring(idx + 1);
                            // find the next quote
                            idx = line.IndexOf('"');
                            // extract the movieTitle
                            Summary.Add(line.Substring(0, idx));
                            // remove title and last comma from the string
                            line = line.Substring(idx + 2);
                            // replace the "|" with ", "
                            Status.Add(line.Replace("|", ", "));
                            Priority.Add(line.Replace("|", ", "));
                            Submitter.Add(line.Replace("|", ", "));
                            Assigned.Add(line.Replace("|", ", "));
                            Watching.Add(line.Replace("|", ", "));
                        }

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
                        // loop thru Movie Lists
                        for (int i = 0; i < TicketIds.Count; i++)
                        {
                            // display movie details
                            Console.WriteLine($"Id: {TicketIds[i]}");
                            Console.WriteLine($"Summary: {Summary[i]}");
                            Console.WriteLine($"Status: {Status[i]}");
                            Console.WriteLine($"Priority: {Priority[i]}");
                            Console.WriteLine($"Submitter: {Submitter[i]}");
                            Console.WriteLine($"Assigned: {Assigned[i]}");
                            Console.WriteLine($"Watching: {Watching[i]}");
                            Console.WriteLine();
                        }
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
