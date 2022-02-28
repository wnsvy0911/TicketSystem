using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystem
{
    public class TicketFile

    {
        // public property
        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        // constructor is a special method that is invoked
        // when an instance of a class is created
        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();

            // to populate the list with data, read from the data file
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
                    Tickets.Add(ticket);

                    }
                    sr.Close();
                }

                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
        }
    }
}