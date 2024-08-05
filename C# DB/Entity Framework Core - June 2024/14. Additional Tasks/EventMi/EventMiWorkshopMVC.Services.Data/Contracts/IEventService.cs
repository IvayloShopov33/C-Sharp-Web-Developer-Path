using EventMiWorkshopMvc.Web.ViewModels.Event;

namespace EventMiWorkshopMVC.Services.Data.Contracts
{
    public interface IEventService
    {
        Task AddEvent(AddEventFormModel model, DateTime startDate, DateTime endDate);

        Task<EditEventFormModel> GetEventById(int id);

        Task EditEventById(int id, EditEventFormModel model, DateTime startDate, DateTime endDate);

        Task DeleteEventById(int id);

        Task<List<FullInfoEventFormModel>> AllActiveEvents();
    }
}