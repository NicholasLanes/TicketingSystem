using System.Collections.Generic;

namespace TicketingSystem.Models
{
    public class Filters
    {
        public Filters(string filterString)
        {
            if (filterString is null)
            {
                filterString = "all-all-all";
            }
            FilterString = filterString ?? "all-all-all";
            string[] filters = filterString.Split('-');
            SprintNum = filters[0];
            PointVal = filters[1];
            StatusId = filters[2];
        }

        // Read-Only 
        public string FilterString { get; }
        public string SprintNum { get; }
        public string PointVal { get; }
        public string StatusId { get; }

        // These booleans return true when the filter returns anything but "all"
        public bool HasSprintNum => SprintNum.ToLower() != "all";
        public bool HasPointVal => PointVal.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";

        // A dictionary with keys and values that are strings. Holds the value that will appear in status dropdown
        public static Dictionary<string, string> StatusFilterValues =>
            new Dictionary<string, string>
            {
                { "t", "ToDo" },
                { "i", "InProgress" },
                { "q", "QualityAssurance" },
                { "d", "Done" }
            };

    }
}
