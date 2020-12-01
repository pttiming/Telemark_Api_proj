using Microsoft.EntityFrameworkCore;
using WebAPISample.Models;

namespace WebAPISample.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<SmsMessage> Messages { get; set; }
        public DbSet<Race> Races { get; set; }
    }
}
