using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketingSystem.Models
{
    internal class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasKey(k => k.Id); // specifies primary key as PointVal Id attribute
            entity.Property(p => p.Name).IsRequired(); // specifies property as PointVal Name attribute

            // seeding data for status options (key, value) pairs
            entity.HasData(
                new Status { Id = "t", Name = "To-Do" },
                new Status { Id = "i", Name = "In Progress" },
                new Status { Id = "q", Name = "Quality Assurance" },
                new Status { Id = "d", Name = "Done" }
                );
        }
    }
}
