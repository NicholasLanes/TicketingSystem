using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TicketingSystem.Models;

namespace TicketingSystem.Views.Home.Components
{
    //Status Drop Down is a view component which inherits ViewComponent class
    public class StatusDropDown : ViewComponent
    {
        private TicketContext Context { get; set; }  // import DbContext through ticketcontext
        public StatusDropDown(TicketContext ctx) => Context = ctx; // status dropdown accepts context
        public IViewComponentResult Invoke(string selectedStatusValue) // invoke made to accept a string parameter for the selected status value
        {
            var statuses = Context.Statuses.ToList().OrderBy(x => x.Name); // statuses is a list of statuses from the dbcontext ordered by name
            var viewModel = new StatusDropDownViewModel
            {
                SelectedStatus = selectedStatusValue,
                DefaultStatus = "td",
                Statuses = statuses.ToDictionary(x => x.Id.ToString(), x => x.Name.ToString())
            };
            return View(viewModel);
        }
    }
}
