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
                // TODO: create user menu
            }


            logger.Info("Program ended");
        }
    }
}
