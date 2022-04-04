using Microsoft.EntityFrameworkCore;

namespace TicketingSystem.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SprintNum> SprintNums { get; set; }
        public DbSet<PointVal> PointVals { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SprintNum>().HasData(
                new SprintNum { Id = "1", Name = "1" },
                new SprintNum { Id = "2", Name = "2" },
                new SprintNum { Id = "3", Name = "3" },
                new SprintNum { Id = "4", Name = "4" },
                new SprintNum { Id = "5", Name = "5" },
                new SprintNum { Id = "6", Name = "6" },
                new SprintNum { Id = "7", Name = "7" },
                new SprintNum { Id = "8", Name = "8" },
                new SprintNum { Id = "9", Name = "9" },
                new SprintNum { Id = "10", Name = "10" }
                );

            modelBuilder.Entity<PointVal>().HasData(
                new PointVal { Id = "1", Name = "1" },
                new PointVal { Id = "2", Name = "2" },
                new PointVal { Id = "3", Name = "3" },
                new PointVal { Id = "5", Name = "5" },
                new PointVal { Id = "8", Name = "8" },
                new PointVal { Id = "13", Name = "13" },
                new PointVal { Id = "21", Name = "21" },
                new PointVal { Id = "34", Name = "34" },
                new PointVal { Id = "55", Name = "55" },
                new PointVal { Id = "89", Name = "89" }
                );

            modelBuilder.ApplyConfiguration(new StatusConfig()); // applying configuration class to import data from StatusConfig

            
        }
    }
}
