using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TicketingSystem.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PointVal> PointVals { get; set; }
        public DbSet<SprintNum> SprintNums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StatusConfig()); // applying configuration class to import data from StatusConfig
        }
        
    }
}
