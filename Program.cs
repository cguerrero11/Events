using System;
using NLog.Web;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Events
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");

            try
            {
                List<Location> locations = new List<Location>{};
                
                var db = new EventContext();
                
                var location = new Location {Name = "Front Door"};
                locations.Add(location);
                location = new Location {Name = "Family Room"};
                locations.Add(location);
                location = new Location {Name = "Rear Door"};
                locations.Add(location);

                
                
                
                var query = db.Events.OrderBy(b => b.TimeStamp);

                Console.WriteLine("All events in past 6 months:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.TimeStamp +" - "+ item.Location.Name);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            logger.Info("Program ended");
        }
    }
}
