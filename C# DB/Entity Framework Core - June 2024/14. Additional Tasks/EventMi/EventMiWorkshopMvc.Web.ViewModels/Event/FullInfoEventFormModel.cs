namespace EventMiWorkshopMvc.Web.ViewModels.Event
{
    public class FullInfoEventFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;

        public string Place { get; set; } = null!;
    }
}