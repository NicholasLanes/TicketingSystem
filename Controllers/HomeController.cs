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
        public HomeController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.SprintNums = context.SprintNums.OrderByDescending(t => t.Id).ToList();
            ViewBag.PointVals = context.PointVals.OrderByDescending(t => t.Id).ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.StatusFilters = Filters.StatusFilterValues;

            IQueryable<Ticket> query = context.Tickets;
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
            ViewBag.SprintNums = context.SprintNums.ToList();
            ViewBag.PointVals = context.PointVals.ToList();
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
                context.SaveChanges(); // Save
                return RedirectToAction("Index"); // Return to Home Page
            }
            // If there are validation errors
            else
            {
                ViewBag.SprintNums = context.SprintNums.ToList();
                ViewBag.PointVals = context.PointVals.ToList();
                ViewBag.Statuses = context.Statuses.ToList();
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
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId.ToString();
                selected = context.Tickets.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();
            return RedirectToAction("Index", new { Id = id });
        }
    }
}