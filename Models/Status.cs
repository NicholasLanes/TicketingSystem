using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Status
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
