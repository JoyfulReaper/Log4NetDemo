// log4Net SDK docs: http://logging.apache.org/log4net/release/sdk/index.html
// All Appenders see above

/*
   Log levels:
  	1. DEBUG
	2. INFO
	3. WARN
	4. ERROR
    5. FATAL
*/

using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)] //Use XmlConfigurator and update if it changes. Only needed once, put at start point ( Main() ). Outside of namespace (Does not seem to work in .net 5)

namespace ConsoleUI
{
    class Program
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program.cs"); // Logger for each class, give name based on class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); // Or use reflection (before .NET framework 4.6)
        //private static readonly log4net.ILog log = LogHelper.GetLogger(); // .NET 4.6 framework and beyond - full file path

        static void Main(string[] args)
        {
            //log4net.Util.LogLog.InternalDebugging = true; Enable logging for log4net itself

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Console.WriteLine("Hello World!");
            log.Error("This is my error message!");

            Console.WriteLine();

            log.Debug("Devloper: Tutorial was run");
            log.Info("Maintenance: water pump turned on");
            log.Warn("Maintenance: the water pump is getting hot");

            var i = 0;
            try
            {
                var x = 10 / i;
            }
            catch(DivideByZeroException ex)
            {
                log.Error("Devloper: we tried to divide by zero again", ex);
            }

            Counter j = new Counter();

            log4net.GlobalContext.Properties["counter"] = j;

            for (j.LoopCounter = 0; j.LoopCounter < 5; j.LoopCounter++)
            {
                //log4net.GlobalContext.Properties["counter"] = i;
                log.Fatal("This is a fatal error in the proccess!");
            }

            log.Fatal("Maintenance: The water pump exploded!");

            Console.ReadLine();
        }
    }
}
