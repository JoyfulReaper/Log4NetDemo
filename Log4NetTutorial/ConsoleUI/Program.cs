using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)] //Use XmlConfigurator and update if it changes. Only needed once, put at start point ( Main() ). Outside of namespace

namespace ConsoleUI
{
    class Program
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program.cs"); // Logger for each class, give name based on class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); // Or use reflection

        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Console.WriteLine("Hello World!");

            log.Error("This is my error message!");

            Console.ReadLine();
        }
    }
}
