using System.Collections.Generic;

namespace TicketingSystem.Models
{
    // View Model for configuring the status drop down for selecting a ticket's status
    public class StatusDropDownViewModel
    {
        //Dictionary for statuses will hold an id and value string for each status
        public Dictionary<string, string> Statuses { get; set; }
        public string SelectedStatus { get; set; }
        public string DefaultStatus { get; set; }
    }
}
