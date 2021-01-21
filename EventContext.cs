using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Events
{
    public class EventContext : DbContext
    {
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }


        public void AddEvent(Event evt)
    {
        this.Events.Add(evt);
        this.SaveChanges();
    }

    public void AddLocation(Location location)
    {
        this.Locations.Add(location);
        this.SaveChanges();
    }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer(@config["BloggingContext:ConnectionString"]);
        }
    }
}
