using System.Globalization;
using Microsoft.EntityFrameworkCore;

using EventMiWorkshopMvc.Web.ViewModels.Event;
using EventMiWorkshopMVC.Data;
using EventMiWorkshopMVC.Data.Models;
using EventMiWorkshopMVC.Services.Data.Contracts;

namespace EventMiWorkshopMVC.Services.Data
{
    public class EventService : IEventService
    {
        private readonly EventMiDbContext dbContext;

        public EventService(EventMiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEvent(AddEventFormModel model, DateTime startDate, DateTime endDate)
        {
            var @event = new Event
            {
                Name = model.Name,
                StartDate = startDate,
                EndDate = endDate,
                Place = model.Place,
                IsActive = true,
            };

            await this.dbContext.Events.AddAsync(@event);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<EditEventFormModel> GetEventById(int id)
        {
            var eventById = await this.dbContext.Events
                .Where(e => e.Id == id && e.IsActive!.Value)
                .Select(e => new EditEventFormModel
                {
                    Name = e.Name,
                    StartDate = e.StartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    EndDate = e.EndDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    Place = e.Place,
                })
                .FirstOrDefaultAsync();

            if (eventById == null)
            {
                throw new InvalidOperationException();
            }

            return eventById;
        }

        public async Task EditEventById(int id, EditEventFormModel model, DateTime startDate, DateTime endDate)
        {
            var eventToEdit = await this.dbContext.Events
                .FirstAsync(e => e.Id == id);

            if (!eventToEdit.IsActive!.Value)
            {
                throw new InvalidOperationException();
            }

            eventToEdit.Name = model.Name;
            eventToEdit.StartDate = startDate;
            eventToEdit.EndDate = endDate;
            eventToEdit.Place = model.Place;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteEventById(int id)
        {
            var eventToDelete = await this.dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventToDelete == null)
            {
                throw new ArgumentException();
            }

            if (!eventToDelete.IsActive!.Value)
            {
                throw new InvalidOperationException();
            }

            this.dbContext.Events.Remove(eventToDelete);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<FullInfoEventFormModel>> AllActiveEvents()
        {
            var allActiveEvents = await this.dbContext.Events
                .Where(e => e.IsActive!.Value)
                .Select(e => new FullInfoEventFormModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    StartDate = e.StartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    EndDate = e.EndDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    Place = e.Place,
                })
                .ToListAsync();

            return allActiveEvents;
        }
    }
}