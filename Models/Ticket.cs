using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required(ErrorMessage = "The Name field for the ticket cannot be blank.")]
        [StringLength(50, ErrorMessage = "The Name field must be 50 characters or less.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please assign a sprint number to the ticket.")]
        [Range(1, 10, ErrorMessage = "Sprint number must be a value between 1 and 10.")]
        public string SprintNum { get; set; }

        [Required(ErrorMessage = "Please assign a point value to the ticket.")]
        [Range(1, 89, ErrorMessage = "Sprint number must be a value between 1 and 89.")]
        public string PointVal { get; set; }
        [Required(ErrorMessage = "The Description field for the ticket cannot be blank.")]
        [StringLength(200, ErrorMessage = "The Description field must be 200 characters or less.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select a status for the ticket.")]
        public string StatusId { get; set; }
        public Status Status { get; set; } // The Status Object named Status allows the view to grab the name of the status from the status id
    }
}
