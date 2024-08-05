using System.Globalization;
using Microsoft.AspNetCore.Mvc;

using EventMiWorkshopMvc.Web.ViewModels.Event;
using EventMiWorkshopMVC.Services.Data.Contracts;

namespace EventMiWorkshop.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isStartDateValid = DateTime.TryParse(model.StartDate, CultureInfo
                .InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            if (!isStartDateValid)
            {
                ModelState.AddModelError(nameof(model.StartDate), "Invalid start date format.");

                return View(model);
            }

            bool isEndDateValid = DateTime.TryParse(model.EndDate, CultureInfo
                .InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isEndDateValid)
            {
                ModelState.AddModelError(nameof(model.EndDate), "Invalid end date format.");

                return View(model);
            }

            await this.eventService.AddEvent(model, startDate, endDate);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Event");
            }

            try
            {
                EditEventFormModel eventModel = await this.eventService.GetEventById(id.Value);

                return View(eventModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, EditEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!id.HasValue)
            {
                return RedirectToAction("All", "Event");
            }

            bool isStartDateValid = DateTime.TryParse(model.StartDate, CultureInfo
                .InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            if (!isStartDateValid)
            {
                ModelState.AddModelError(nameof(model.StartDate), "Invalid start date format.");

                return View(model);
            }

            bool isEndDateValid = DateTime.TryParse(model.EndDate, CultureInfo
                .InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isEndDateValid)
            {
                ModelState.AddModelError(nameof(model.EndDate), "Invalid end date format.");

                return View(model);
            }

            try
            {
                await this.eventService.EditEventById(id.Value, model, startDate, endDate);

                return RedirectToAction("All", "Event");
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Event");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Event");
            }

            try
            {
                EditEventFormModel eventModel = await this.eventService.GetEventById(id.Value);

                return View(eventModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, EditEventFormModel model)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Event");
            }

            try
            {
                await this.eventService.DeleteEventById(id.Value);

                return RedirectToAction("All", "Event");
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Event");

            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allEvents = await this.eventService.AllActiveEvents();

            return View(allEvents);
        }
    }
}