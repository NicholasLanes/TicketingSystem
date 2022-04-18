using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx; // dbcontext injection
        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.StatusFilters = Filters.StatusFilterValues;

            IQueryable<Ticket> query = context.Tickets.AsQueryable();
            if (filters.HasSprintNum)
            {
                query = query.Where(t => t.SprintNum == filters.SprintNum);
            }
            if (filters.HasPointVal)
            {
                query = query.Where(t => t.PointVal == filters.PointVal);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            var tickets = query.OrderBy(t => t.StatusId).ToList();
            return View(tickets);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = context.Statuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket newticket)
        {
            // If there are no validation errors
            if (ModelState.IsValid)
            {
                context.Tickets.Add(newticket); // Add ticket
                context.SaveChanges();
                return RedirectToAction("Index"); // Return to Home Page
            }
            // If there are validation errors
            else
            {
                return View(newticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { Id = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId.ToString();
                selected = context.Tickets.ToList().Find(x => x.Id == selected.Id);
                selected.StatusId = newStatusId;
            }
            return RedirectToAction("Index", new { Id = id });
        }
    }
}