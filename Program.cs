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

            logger.Info("Program ended");
        }
    }
}
