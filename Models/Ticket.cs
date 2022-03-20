using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        // Id is the primary key for the Ticket
        public int Id { get; set; }

        [Required(ErrorMessage = "Please decide a name for the ticket.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please decide a sprint number for the ticket.")]
        public int SprintNum { get; set; }

        [Required(ErrorMessage = "Please decide a point value for the ticket.")]
        public int PointVal { get; set; }

        [Required(ErrorMessage = "Please select a status for the ticket.")]
        public string StatusId { get; set; }
    }
}
